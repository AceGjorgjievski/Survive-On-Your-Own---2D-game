using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static bool PLAYER_ALIVE = true;
    public static bool ENEMY_ALIVE = true;
    public static GameMaster gm;

    [SerializeField]
    private GameObject gameOverUI;


    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
      
    public static void KillPlayer(Player player)
    {
        gm._KillPlayer(player);
    }

    public void _KillPlayer(Player player)
    {
        if (PLAYER_ALIVE)
        {
            Destroy(player.gameObject);
            Debug.Log("PLAYER DEAD");
            PLAYER_ALIVE = false;
            Enemy.TOTAL_ENEMIS_KILLED = 0;
            gameOverUI.SetActive(true);
        }
    }

    public static void KillEnemy(Enemy enemy)
    {
        gm._KillEnemy(enemy);
        //Instantiate(enemy.deathParticles, enemy.transform.position, Quaternion.identity);
        //Destroy(enemy.deathParticles,3f);
        //Destroy(enemy.gameObject);
        //Debug.Log("DONE! - ENEMY");
    }

    public void _KillEnemy(Enemy enemy)
    {
        Instantiate(enemy.deathParticles, enemy.transform.position, Quaternion.identity);
        //Destroy(deathParticles, 3f);
        Destroy(enemy.gameObject);

        Debug.Log("Killed: " + ++Enemy.TOTAL_ENEMIS_KILLED);
       // WaveUI.ShowScore(Enemy.TOTAL_ENEMIS_KILLED);
        Debug.Log("DONE! - ENEMY");
    }
}
