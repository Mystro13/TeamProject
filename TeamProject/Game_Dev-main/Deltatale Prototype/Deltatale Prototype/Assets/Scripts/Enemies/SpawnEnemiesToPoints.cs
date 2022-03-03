using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesToPoints : MonoBehaviour
{
   public GameObject objectToSpawn;
   public GameObject objectParent;
   public Transform[] spawningPoints;
   bool enableSpawning;
   // Start is called before the first frame update
   void Start()
   {
      enableSpawning = true;
   }

   // Update is called once per frame
   void Update()
   {

   }
   public void Execute()
   {
      if (enableSpawning)
      {
         foreach (Transform spawnPoint in spawningPoints)
         {
            GameObject enemyClone = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation, objectParent.transform);
            enemyClone.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
         }
         enableSpawning = false;
      }
   }
}