using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private Player player = new Player();
    private Enemy enemy = new Enemy();

    public void OnTriggerEnter2D(Collider2D collider)
    {
        switch(collider.gameObject.tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Enemy":
                Debug.Log("Player hits an enemy");
                enemy.DamageEnemy(1f);
                Destroy (gameObject);
                break;
            case "Player":
                Debug.Log("Enemy hits a player");
                player.DamagePlayer(1f);
                Destroy(gameObject);
                break;
        }
    }
}
