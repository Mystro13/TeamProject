using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStockUp : MonoBehaviour
{
   [SerializeField] private List<GameObject> stockItems;
   [SerializeField] private int capacity = 10;
   [SerializeField] private int ammoMaxStock = 1;
   [SerializeField] private int manaMaxStock = 1;
   [SerializeField] private int healthPotionMaxStock = 1;
   [SerializeField] private int permaHealthMaxStock = 1;
   [SerializeField] private GameObject ammoObject;
   [SerializeField] private GameObject manaObject;
   [SerializeField] private GameObject healthPotionObject;
   [SerializeField] private GameObject permaHealthObject;
   public bool hasStockedUp = false;
   public void StockUp()
   {
      hasStockedUp = true;
      stockItems = new List<GameObject>();
      ExecuteStockUpOn(ammoObject, ammoMaxStock);
      ExecuteStockUpOn(manaObject, manaMaxStock);
      ExecuteStockUpOn(healthPotionObject, healthPotionMaxStock);
      ExecuteStockUpOn(permaHealthObject, permaHealthMaxStock);
   }
   public void DropItems()
   {
      hasStockedUp = false;
      foreach (GameObject dropping in stockItems)
      {
         dropping.transform.position = gameObject.transform.position;
         dropping.transform.rotation = gameObject.transform.rotation;
         dropping.SetActive(true);
      }
      stockItems = new List<GameObject>();
   }
   void ExecuteStockUpOn(GameObject stockItemObject, int maximum)
   {
      if (stockItems.Count < capacity)
      {
         int count = Random.Range(0, maximum);
         if (count > 0)
         {
            GameObject clone = Instantiate(stockItemObject, transform.position, transform.rotation);
            StockItem stockItem = clone.GetComponent<StockItem>();
            if (stockItem)
            {
               stockItem.quantity = count;
               stockItems.Add(clone);
            }
         }
      }
   }
}
