using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePickup : MonoBehaviour
{
    public int cashValue = 1;
    private void OnTriggerEnter2D(Collider2D other)
    
    {

        if(other.tag  == "Player")
        {
            IInventory inventory = other.GetComponent<IInventory>();

            if(inventory != null )
            {
                inventory.Collectable = inventory.Collectable + cashValue;
                print("Player Inventory has " + inventory.Collectable + "money in it.");
                gameObject.SetActive(false);
            }

        }
    }
}
