
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent; 
    Inventory inventory;

    InvetorySlots[] slots;                                             // when your creating the inventory slots they have to be name this 


    void Start()
    {
        inventory = Inventory.instance;                             // accessing the singleton in the inventory script 
        inventory.onItemChangeCallback += UpdateUI;                // doing a call back method which will update the inventory UI 

        slots = itemsParent.GetComponentsInChildren<InvetorySlots>();
    }

    
    void Update()
    {
        
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
         {
          if( i < inventory.items.Count)
           {
               slots[i].AddItem(inventory.items[i]);
           }
           else 
           {
               slots[i].ClearSlot();
           }
          
         }
        

    }
}
