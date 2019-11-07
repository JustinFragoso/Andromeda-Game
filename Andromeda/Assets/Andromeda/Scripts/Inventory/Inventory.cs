using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

     void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found");
            return;
        }
        instance = this;
    }
    #endregion


    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallback;                                   // we trigger this when something is changin in are inventory 

    public int space = 7;                                                     // the amount of spaces the player has in their inventory 
    public List<Item> items = new List<Item>();                              // a list of items that we have within are inventory 


    /* Internal Econmy 
     * Adds an item to the players inventory*/

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough room");
                return false ;
            }

            items.Add(item);

            if(onItemChangeCallback != null)
            {
                onItemChangeCallback.Invoke();                          // when this event is triggerd we want are UI to update 
            }
       
        }
        return true;
    }

    // Removes an item from the player inventory 
    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangeCallback != null)
        {
            onItemChangeCallback.Invoke();                          // when this event is triggerd we want are UI to update 
        }
    }

}
