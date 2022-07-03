using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [System.Serializable]
    public class PlayerStats
    {
        public float Health = 10;
    }

    public PlayerStats playerStats = new PlayerStats();

    void Start()
    {
    }

    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            SoundManager.Instance.PlayPlayerHitSound();
            playerStats.Health -= 1f;
            Debug.Log("Player:" + playerStats.Health);
            if (playerStats.Health <= 0f)
            {
                GameMaster.KillPlayer(this);
                SoundManager.Instance.PlayPlayerDeadSound();
            }
        } else if(collider.gameObject.tag == "Heart")
        {
            playerStats.Health++;
            SoundManager.Instance.PlayeHealthPikUpSound();
        }
    }

    public void DamagePlayer(float damage)
    {
        //PlayerStats.Health -= damage;
        //Debug.Log("Player: " + PlayerStats.Health);
        //if (PlayerStats.Health <= 0)
        //{
        //    Debug.Log("Player has to die!");
        //    GameMaster.KillPlayer(this);
        //}
    }
}
