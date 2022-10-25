using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas;
    public GameObject bird;

    public Animator anim;
    public float  timer = 1f;
    public Fly script;
    void StopTime ()
    {
        Time.timeScale = 0;
    }
    public void GameOver()
    {
        //bird.GetComponent<Rigidbody2D>().
        //script.enabled = false;
        //anim.SetBool("dead", true);
        canvas.SetActive(true);
        Invoke("StopTime",timer);
        Debug.Log("ai murit");
        SceneManager.LoadScene("ChickenInvaders");
    }
    
}
