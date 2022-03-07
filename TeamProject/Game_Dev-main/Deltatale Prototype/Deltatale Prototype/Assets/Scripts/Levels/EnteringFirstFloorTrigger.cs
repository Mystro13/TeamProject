using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringFirstFloorTrigger : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag(Tags.Player.ToString()))
      {
         SceneLoader.Load(SceneLoader.Scene.FirstFloor);
      }
   }
}
