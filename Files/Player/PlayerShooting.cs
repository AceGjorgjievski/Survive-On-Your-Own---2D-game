using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : Player
{
    public GameObject bullet;
    public Transform firePoint;
    public LayerMask whatIsWall;
    private Enemy enemy;

    public float fireForce = 1f;
    public float startTimebtwShots = 0.25f;
    private float timeBtwShots;

    public static PlayerShooting instance;

    void Awake()
    {
        //hit.collider
        instance = this;
    }

    void Start()
    {
        this.timeBtwShots = this.startTimebtwShots;
    }

    public void Fire()
    {
        SoundManager.Instance.PlayShootingSound();
        GameObject item = Instantiate(this.bullet,this.firePoint.position,this.firePoint.rotation);
        item.GetComponent<Rigidbody2D>().AddForce(this.firePoint.up * this.fireForce,ForceMode2D.Impulse);
        Destroy(item,2f);
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if (this.timeBtwShots <= 0f)
            {
                this.timeBtwShots = this.startTimebtwShots;
                this.Fire();
            } else
            {
                this.timeBtwShots -= Time.deltaTime;
            }
        }
    }

    public void increasePowerPlayer()
    {
        if(Enemy.TOTAL_ENEMIS_KILLED %3 == 0)
        {
            if(this.fireForce >= 300)
            {
                this.fireForce = 300f;
                if(this.startTimebtwShots <= 0.06)
                {
                    this.startTimebtwShots = 0.05f;
                } else
                {
                    this.startTimebtwShots -= 0.05f;
                }
            } else
            {
                this.fireForce += 35f;
                if(this.startTimebtwShots <= 0.1)
                {
                    this.startTimebtwShots = 0.05f;
                } else
                {
                    this.startTimebtwShots -= 0.05f;
                }
            }
        }
        
    }

}
