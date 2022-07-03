using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public Enemy enemy;
        public int count;
        public float spawnRate;
        public float FireForce = 40f;
    }

    public Wave[] waves;
    private int nextWave = 0;
    public int NextWave
    {
        get { return nextWave; }
    }

    public float timeBetweenWaves = 5f;
    private float waveCountdown;
    public float WaveCountdown
    {
        get { return waveCountdown; }
    }

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;
    public SpawnState State
    {
        get { return state; }
    }
    public Transform[] SpawnPoints;

    void Start()
    {
        this.waveCountdown = this.timeBetweenWaves;
        if (this.SpawnPoints.Length == 0) return;
    }

    void Update()
    {
        if(this.state == SpawnState.WAITING)
        {
            if(!this.EnemyIsAlive())
            {
                //TEXT: new round - WAVE COMPLETED
                this.WaveCompleted();
                return;
            } else
            {
                return;
            }
        }


        if(this.waveCountdown <= 0)
        {
            if(this.state != SpawnState.SPAWNING)
            {
                StartCoroutine(this.SpawnWave(this.waves[this.nextWave]));
            }
        } else
        {
            this.waveCountdown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        //TEXT: COUNTER FOR WAVES.. ?

        this.state = SpawnState.SPAWNING;   
        for(int i=0; i<_wave.count; i++)
        {
            _wave.enemy.fireForce = _wave.FireForce;
            this.SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.spawnRate);
        }

        this.state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Enemy _enemy)
    {
        //spawn enemy...
        Transform _spawnPoint = this.SpawnPoints[Random.Range(0,this.SpawnPoints.Length-1)];
        Instantiate(_enemy, _spawnPoint.position, _spawnPoint.rotation);
    }

    void WaveCompleted()
    {
        this.state = SpawnState.COUNTING;
        this.waveCountdown = this.timeBetweenWaves;

        if(this.nextWave+1> this.waves.Length - 1)
        {
            this.nextWave = this.waves.Length - 1;
            // this.nextWave = this.waves.Length-1  - za da bide so najgolem wave num all the time
            //i myb so vremeto pokratko za spaws
        } else
        {
            this.nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        this.searchCountdown -= Time.deltaTime;
        if(this.searchCountdown <= 0)
        {
            this.searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) return false;
        }
        return true;
    }
}
