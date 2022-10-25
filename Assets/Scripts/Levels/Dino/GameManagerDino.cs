using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerDino : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas;
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
   public void GameOver()
   {
    Time.timeScale = 0;
    canvas.SetActive(true);

   }
}
