//import Unity libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Main menu script which includes resume game, options menu, and quit application features
public class MainMenu : MonoBehaviour
{
    //Enable resume option to start at Level 1 and launch the player from the start of that scene in Unity
    //Launches scenes in chrnological order and starting from index[0] (Main Menu) all the way up to index[3] (Level 3)
    public void Play() {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   //Quits application at the beginning when main menu scene is started after the play button is clicked in the game scene
    public void Quit() {
        Debug.Log("Player Quit");
        Application.Quit();
    }
}
