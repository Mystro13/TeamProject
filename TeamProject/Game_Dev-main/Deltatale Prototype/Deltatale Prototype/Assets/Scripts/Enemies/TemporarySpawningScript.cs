using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporarySpawningScript : MonoBehaviour
{
   public bool enableSpawning = true;
   public SpawnEnemiesToPoints spawnEnemiesToPoints;
   private void OnTriggerEnter(Collider collider)
   {
      Debug.Log($"TEMPORARY SPAWNING collision");
      if (enableSpawning && collider.gameObject.CompareTag(Tags.Player.ToString()))
      {
         Debug.Log($"TEMPORARY SPAWNING");
         if (spawnEnemiesToPoints)
         {
            enableSpawning = false;
            spawnEnemiesToPoints.Execute();
         }
      }
   }
}
