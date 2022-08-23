using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{

    // Inventory -> tipul variabilei "inventory". 
        // vine din clasa Inventory care este declarata in scriptul Inventory.cs ( folosit pentru crearea de Scriptable Objects )
    [SerializeField] private Inventory inventory;
    public Transform container;
    public Sprite potionSprite;

    public void addIngredient() {
        inventory.addIngredient(inventory.ingredients[0], container, potionSprite);
    }
}
