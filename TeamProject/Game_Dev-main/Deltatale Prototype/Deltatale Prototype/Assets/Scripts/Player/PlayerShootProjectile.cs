using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootProjectile : MonoBehaviour
{
   public float projectileSpeed = 30;
   public GameObject projectile;
   //float coolDown = 2;

   void Fire()
   {
      PlayerInteraction playerInteraction = gameObject.GetComponent<PlayerInteraction>();
      if (playerInteraction)
      {
         //if (playerInteraction.manaSlot.slotItem)  
         {
            GameObject swordGrip = GameObject.FindGameObjectWithTag("SwordGrip");
            if (swordGrip)
            {
               GameObject projectileClone = Instantiate(projectile, swordGrip.transform.position, swordGrip.transform.rotation);
               projectileClone.transform.position = new Vector3(projectileClone.transform.position.x, projectileClone.transform.position.y / 2, projectileClone.transform.position.z);
               projectileClone.GetComponent<Rigidbody>().velocity = swordGrip.transform.forward * projectileSpeed;
               //playerInteraction.manaSlot.RemoveItem();
               //coolDown = Time.time + projectileSpeed;
            }
         }
      }
   }

   void Update()
   {
      Keyboard keyboard = Keyboard.current;
      Mouse mouse = Mouse.current;
      //if (Time.time >= coolDown)
      {
         if (mouse.leftButton.ReadValue() > 0f)
         {
            Fire();
         }
      }
   }
}
