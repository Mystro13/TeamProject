using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    public int maximumHealth = 1000;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
      health = maximumHealth;
    }

    //Update is called once per frame
    void Update()
    {
        UpdateHUD();

        if(health <=0)
        {
            GameObject.Destroy(gameObject);
        }

    }
   void UpdateHUD()
   {
      if (healthBar)
      {
         healthBar.fillAmount = (float)health / (float)maximumHealth;
      }
   }

   public void DepleteHealth()
    {
        health -= 1;
        if (health <= -1)
        {
            health = 0;
        }
    }

    public void TrapDamage(int blow)
    {
      health -= blow;
      if (health < 0)
      {
         health = 0;
      }
   }

   public void BoostHealth()
   {
      health += 1;
   }

   public void LoadData()
   {

   }

   public void SaveData()
   {

   }
}