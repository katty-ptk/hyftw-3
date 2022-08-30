using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ CreateAssetMenu( fileName = "Inventory", menuName = "Inventory" ) ] // asta face ca in Unity sa putem crea instante ale clasei asteia
public class Inventory : ScriptableObject {
    [SerializeField] private  List<Ingredient> ingredients = new List<Ingredient>(); // inventarul va avea o lista cu ingrediente; ele vor fi create tot dintr-o clasa ( Ingredient.cs ), si vor fi Scriptable Objects

    // GETTERS & SETTERS

    // asta este o proprietate prin care lista cu ingredientele se va putea folosi in alte fisiere
    public List<Ingredient> Inv {
        get { return ingredients; }

        set { ingredients = value; }
    }

    // FUNCTIONS

    // metoda ( functia ) principala pentru adaugarea unui ingredient in inventar
    public void addIngredient( Ingredient ingredient, Transform container, Sprite potionSprite ) {       
        foreach (Transform child in container) {
            if (!child.GetChild(0).GetComponent<SpriteRenderer>().sprite) {  // daca slotul este gol
                child.GetChild(0).GetComponent<SpriteRenderer>().sprite = potionSprite; // se adauga ingredientul in slot-ul respectiv printr-un sprite primit ca parametru
                break;
            }
        }
    }
}
