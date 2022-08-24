using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ CreateAssetMenu( fileName = "Ingredient", menuName = "Ingredient" ) ]
public class Ingredient : ScriptableObject {
    [SerializeField] private string ingredientName;
    [SerializeField] private int level;

    // GETTERS & SETTERS
    public string IngredientName {
        get { return ingredientName; }
    }

    // FUNCTIONS
    public int Level {
        get { return level; }
    }
}
