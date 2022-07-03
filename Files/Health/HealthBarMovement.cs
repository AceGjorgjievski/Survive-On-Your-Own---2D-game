using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarMovement : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        this.slider.maxValue = health;
        this.slider.value = health;

        this.fill.color = this.gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
       this.slider.value = health;
       this.fill.color = this.gradient.Evaluate(this.slider.normalizedValue);
    }
}
