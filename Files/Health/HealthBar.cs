﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Player player;
    [SerializeField] 
    private Image totalHealthBar;
    [SerializeField] 
    private Image currentHealthBar;



    // Start is called before the first frame update
    void Start()
    {
        totalHealthBar.fillAmount = player.playerStats.Health / 10;
        currentHealthBar.fillAmount = player.playerStats.Health / 10; 
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = player.playerStats.Health / 10;
    }
}
