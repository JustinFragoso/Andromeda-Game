
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    /* By making this virtual we can driven different objects by using the item
      and defined for each one what we want to happen when the player uses the item */
    public virtual void Use()
    {
        // Use the item 
        // Something might happen 

        Debug.Log("Using" + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
