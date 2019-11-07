using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;

    void OnTriggerEnter(Collider other)
    {
       
        Debug.Log("Picking up" + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        if(wasPickedUp)
        Destroy(gameObject);
    }

   
}
