using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : MonoBehaviour
{
   public GameObject swordGrip;
   public void Execute()
   {
      GetComponent<Rigidbody>().useGravity = false;
      DetachFromParent();
      AttachToParent(swordGrip);
      EnableSword();
   }
   void AttachToParent(GameObject newParent)
   {
      transform.position = newParent.transform.position;
      transform.parent = newParent.transform; 
   }
   void DetachFromParent()
   {
      transform.parent = null;
   }
   void EnableSword()
   {
      AimSwordScript aimSwordScript = gameObject.GetComponent<AimSwordScript>();
      if(aimSwordScript)
      {
         aimSwordScript.EnableSword();
      }
   }
}
