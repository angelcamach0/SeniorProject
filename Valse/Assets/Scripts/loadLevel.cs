//import Unity libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script designed to load level and transtiion into another scene within Unity during gameplay in Valse
public class loadLevel : MonoBehaviour
{

    public int iLevelToLoad;
    public string sLevelToLoad;

    public bool useIntegerToLoadLevel = false;

    //If player collides with a scene level transition then display the next level in the build settings tab (or hierarchy)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name == "PlayerCat")
        {
            LoadScene();
        }
    }

//function that loads scene transtions (Level1->Level2->Level3)
    void LoadScene()
    {
        if (useIntegerToLoadLevel)
        {
            SceneManager.LoadScene(iLevelToLoad);
        }
        else
        {
            SceneManager.LoadScene(sLevelToLoad);
        }
    }

}