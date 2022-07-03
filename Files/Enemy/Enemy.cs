using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float fireRate = 0;
    public int Damage = 10;
    public LayerMask whatIsWall;

    private float timeToFire = 0;
    Transform firePoint;

    [System.Serializable]
    public class EnemyStats
    {
        public float Health = 10;
    }   

    public float speed;
    public float stoppingDistance;
    public float fireForce = 1f;
    public float retreatDistance;

    public Transform player;
    public GameObject bullet;
    private Rigidbody2D rb;
    private float timeBtwShots;
    public float startTimeBtwShots;

    private float distance;
    private Vector2 enemyPos;
    private Vector2 targetPos;


    public Transform deathParticles;
    public float Health = 10f;
    public EnemyStats enemyStats = new EnemyStats();


    public static int TOTAL_ENEMIS_KILLED = 0;

    void Awake()
    {
        this.firePoint = transform.Find("FirePoint");
        if (this.firePoint == null)
        {
            Debug.LogError("NO FIREPOINT!");
        }
    }
   

    // Start is called before the first frame update
    void Start()
    {
        //this.firePoint = GameObject.FindGameObjectWithTag("FirePoint").transform;
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        this.rb = GetComponent<Rigidbody2D>();
        this.timeBtwShots = this.startTimeBtwShots;
    }

    void Update()
    {
        if(this.player != null && this.transform != null)
        {
            targetPos = player.position;
            enemyPos = transform.position;
        }
        this.distance = Vector2.Distance(enemyPos, targetPos);
        this.Shoot();
        //this.DamageEnemy(1); zashot....... vaka go snemuva, 
        if(enemyStats.Health <= 0)
        {
            //this.DamageEnemy(100);//vaka raboti
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.player != null)
        {
            if (Vector2.Distance(transform.position, this.player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, this.player.position, this.speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, this.player.position) < stoppingDistance &&
                Vector2.Distance(transform.position, this.player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            } else if(Vector2.Distance(transform.position, this.player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, this.player.position, -this.speed * Time.deltaTime);
            }
            this.CalculateAngle();
        }
    }

    private void CalculateAngle()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Bullet") 
        {
            enemyStats.Health -= 1f;
            Debug.Log("Enemy:"+enemyStats.Health);
            if(enemyStats.Health <= 0f)
            {
                TOTAL_ENEMIS_KILLED++;
                PlayerShooting.instance.increasePowerPlayer();
                ScoreMenagment.Instance.AddPoint();
                GameMaster.KillEnemy(this);
                SoundManager.Instance.PlayEnemyDeadSound();
            }
        }
    }

    public void DamageEnemy(float damage)
    {
        //EnemyStats.Health -= damage;
        //enemyStats.Health -= damage;
        //Debug.Log("Enemy: " + enemyStats.Health);
        //Debug.Log("Enemy: " + this.Health);
        if (enemyStats.Health <= 0)
        {
            Debug.Log("Enemy has to die!");
            //GameMaster.KillEnemy(this);
        }
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
        if(this.timeBtwShots <= 0)
        {
            if(this.player != null)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, this.player.position - transform.position,80,whatIsWall);
                //Debug.DrawLine(transform.position, this.player.position, Color.black, 1);
                if (hit.collider == null) return;
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    if (this.distance <= 70f)
                    {
                        SoundManager.Instance.PlayShootingSound();
                        Player p = hit.collider.GetComponent<Player>();
                        if(p != null)
                        {
                            //this.DamageEnemy(this.Damage);
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
        } else
        {
            this.timeBtwShots -= Time.deltaTime;
        }
    }
}
