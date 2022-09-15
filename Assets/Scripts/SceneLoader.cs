using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private string option;

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

    public void SetOption( string type ) {
        if (type == "new")
            option = "new";
        else
            option = "previous";
    }

    public void NewOrPreviousGame() {
        switch( option ) {
            case "new":
                LoadIntro();
                break;

            case "previous":
                Debug.Log("No previous game yet, sorry:(");
                break;
        }
    }
}
