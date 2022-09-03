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
}
