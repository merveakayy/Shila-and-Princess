using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public Slider slider;
    private int health = 100;
void Start()
{
    slider.value = health;
}
   public void GetDamage()
   {
        health -= 10;
        slider.value = health;
   }
}
