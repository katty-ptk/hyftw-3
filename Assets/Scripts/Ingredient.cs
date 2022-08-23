using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ CreateAssetMenu( fileName = "Ingredient", menuName = "Ingredient" ) ]
public class Ingredient : ScriptableObject {
    public string ingredientName;
    [SerializeField] private int level;
}
