using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public GameObject selectedskin;
    public GameObject player;
    private Sprite playersprite;
    void Start()
    {
        playersprite = selectedskin.GetComponent<SpriteRenderer>().sprite;
        player.GetComponent<SpriteRenderer>().sprite = playersprite;
    }

    /*
        pov: it's the 2000s and all the kids go crazy about the arcade games.
        but in the best place with arcade game machines there is a machine that takes you to a new world
        you only have to press a button
        THE button…
    */
}
