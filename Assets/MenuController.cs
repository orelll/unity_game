using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //Play Game
    public void PlayGame(){
        Debug.Log("Starting game");
        var currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }

    //Settings

    //Exit
    public void MoveToExit(){
        
    }

}
