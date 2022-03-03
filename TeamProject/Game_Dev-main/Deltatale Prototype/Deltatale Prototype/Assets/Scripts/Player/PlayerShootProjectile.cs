using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootProjectile : MonoBehaviour
{
   public float projectileSpeed = 30;
   public GameObject projectile;
   float nextShot = 0.0f;
   float timeBetweenShots = 0.2f;

   void Fire()
   {
      PlayerInteraction playerInteraction = gameObject.GetComponent<PlayerInteraction>();
      if (playerInteraction)
      {
         //if (playerInteraction.manaSlot.slotItem)  
         {
            GameObject swordGrip = GameObject.FindGameObjectWithTag("SwordGrip");
            //Transform magicPoint = gameObject.transform;
            //foreach (Transform child in gameObject.transform)
            //{
            //   if (child.name == "MagicPoint")
            //   {
            //      magicPoint = child;
            //      break;
            //   }
            //}

            if (swordGrip)
            {
               Vector3 barrelEnd = transform.position + transform.forward * 1f + new Vector3(0, 2f, 0);
               foreach (Transform child in gameObject.transform.GetComponentsInChildren<Transform>())
               {
                  if (child.name == "MagicPoint")
                  {
                     //magicPoint = child;
                     barrelEnd = child.position;
                     break;
                  }
               }
               //if (magicPoint.name == "MagicPoint")
               //{
               //   barrelEnd = magicPoint.position;
               //}
               //GameObject projectileClone = Instantiate(projectile, swordGrip.transform.position, swordGrip.transform.rotation);
               GameObject projectileClone = Instantiate(projectile, barrelEnd, transform.rotation);
               //projectileClone.transform.position = new Vector3(projectileClone.transform.position.x, projectileClone.transform.position.y * 0.1f, projectileClone.transform.position.z);
               projectileClone.GetComponent<Rigidbody>().velocity = transform.forward * projectileSpeed;
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
      if (Time.time > nextShot)
      {         
         if (mouse.leftButton.ReadValue() > 0f)
         {
            nextShot = Time.time + timeBetweenShots;
            Fire();
         }
      }
   }
}
