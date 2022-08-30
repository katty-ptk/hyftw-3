using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{

    // Inventory -> tipul variabilei "inventory". 
        // vine din clasa Inventory care este declarata in scriptul Inventory.cs ( folosit pentru crearea de Scriptable Objects )
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform container;
    [SerializeField] private Sprite potionSprite;

    // GETTERS & SETTERS
    public Inventory Inventory {
        get { return inventory; }
    }

    // FUNCTIONS
    public void addIngredient() {
        inventory.addIngredient(inventory.Inv[0], container, potionSprite);
    }
}
