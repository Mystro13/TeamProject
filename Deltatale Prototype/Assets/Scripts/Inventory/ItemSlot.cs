using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
   public GameObject slotItem;
   public Text slotText;
   public int slotMaximum = 1;
   StockItem slotStockItem;
   // Start is called before the first frame update
   void Start()
   {
      slotStockItem = slotItem.GetComponent<StockItem>();
      slotStockItem.quantity = 0;
   }

   // Update is called once per frame
   void Update()
   {
      UpdateSlot();
   }

   public void UpdateSlot()
   {
      //this.GetComponent<Image>().sprite = slotStockItem.icon;
      //this.GetComponentInChildren<Text>().text = "" + slotStockItem.quantity;
   }

   public bool AddItem(GameObject itemObject)
   {
      bool result = false;
      StockItem stockItem = itemObject.GetComponent<StockItem>();
      if (stockItem && slotStockItem.ItemType.Equals(slotStockItem.ItemType))
      {
         slotStockItem.quantity += stockItem.quantity;
         result = true;
      }
      return result;
   }
   public bool RemoveItem()
   {
      bool result = false;
      if (slotStockItem.quantity > 0)
      {
         slotStockItem.quantity -= 1;
         result = true;
      }
      return result;
   }

   public void LoadData()
   {
      
   }

   public void SaveData()
   {

   }
}
