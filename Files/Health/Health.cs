using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float startingHealth;
    public float currentHealth { get; private set; }

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        if(currentHealth <= 0)
        {
            
        }
    }

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.E))
        //{
        //    TakeDamage(1);
        //}
    }
}
