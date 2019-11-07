
using UnityEngine;
using UnityEngine.UI;

public class InvetorySlots : MonoBehaviour
{
    public Image icon;
    //public Button removeButton;

    Item item;               // Keep track of item in the inventory UI slot 

    public void AddItem(Item newItem)
    {
        item = newItem;           
        icon.sprite = item.icon;
        icon.enabled = true;
        //removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.enabled = false;
        //removeButton.interactable = false;

    }

   /* public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }
    */

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }
}
