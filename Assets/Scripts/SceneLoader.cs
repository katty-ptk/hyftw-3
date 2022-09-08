using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadIntro() {
        SceneManager.LoadScene("Intro");
    }

   public void SkipIntro() {
        SceneManager.LoadScene("CharacterSelection");     
   }

    public void LoadPong() {
        SceneManager.LoadScene("Pong");
    }

    public void LoadChickenInvaders() {
        SceneManager.LoadScene("ChickenInvaders");
    }
    public void LoadMario()
    {
        SceneManager.LoadScene("MarioGame");
    }
}
