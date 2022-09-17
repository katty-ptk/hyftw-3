using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PAUSE : MonoBehaviour
{
    [SerializeField] GameObject pausemenu;
    public void pause()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
    }
    /* private void save()
     {

     }*/
    public void home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void settings()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void quit()
    {
Debug.Log("Quitting");
pausemenu.SetActive(false);

    }
}
