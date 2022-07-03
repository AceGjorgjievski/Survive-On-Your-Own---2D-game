using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float fireRate = 0;
    public int Damage = 10;

    private float timeToFire = 0;
    private Transform firePoint;

    public float speed;
    public float stoppingDistance;
    public float fireForce = 1f;

    public Transform player;
    public GameObject bullet;
    private Rigidbody2D rb;
    private float timeBtwShots;
    public float startTimeBtwShots;

    public LayerMask whatIsWall;
    private float distance;
    private Vector2 enemyPos;
    private Vector2 targetPos;



    // Start is called before the first frame update
    void Awake()
    {
        this.firePoint = transform.Find("FirePoint");
        if(this.firePoint == null)
        {
            Debug.LogError("No FIREPOINT FOUND !");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.player != null && this.transform != null)
        {
            targetPos = player.position;
            enemyPos = transform.position;
        }
        this.distance = Vector2.Distance(enemyPos, targetPos);
        //this.Shoot();
    }

    public void typeOfShooting()
    {
        if (this.fireRate == 0)//single burrst
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.Shoot();
            }
        }
        else//automatic
        {
            if (Input.GetMouseButton(0) && Time.time > this.timeToFire)
            {
                this.timeToFire = Time.time + 1 / this.fireRate;
                this.Shoot();
            }
        }
    }

    private void Shoot()
    {
        if (this.timeBtwShots <= 0)
        {
            if (this.player != null)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, this.player.position - transform.position,15,this.whatIsWall);
                //Debug.DrawLine(transform.position, this.player.position, Color.black, 1);
                if (hit.collider == null) return;
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    if (this.distance <= 30f)
                    {
                        Player p = hit.collider.GetComponent<Player>();
                        if (p != null)
                        {
                            p.DamagePlayer(this.Damage);
                        }
                        GameObject item = Instantiate(this.bullet, this.firePoint.position, this.firePoint.rotation);
                        if (item == null)
                        {
                            Debug.LogError("NO ITEM!");
                        }
                        item.GetComponent<Rigidbody2D>().AddForce(this.firePoint.up * this.fireForce, ForceMode2D.Impulse);
                        Destroy(item, 3);
                    }
                }
            }
            this.timeBtwShots = this.startTimeBtwShots;
        }
        else
        {
            this.timeBtwShots -= Time.deltaTime;
        }
    }
}
