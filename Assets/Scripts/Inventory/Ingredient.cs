using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ CreateAssetMenu( fileName = "Ingredient", menuName = "Ingredient" ) ]
public class Ingredient : ScriptableObject {
    [SerializeField] private string ingredientName, level;

    // GETTERS & SETTERS
    public string IngredientName {
        get { return ingredientName; }
    }

    // FUNCTIONS
    public string Level {
        get { return level; }
    }
}
