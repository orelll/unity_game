using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject FrontMenu;
    public GameObject ConfirmationMenu;

    private string _playGameScene = "PlayGameScene";


    //Play Game
    public void PlayGame(){
        Debug.Log("Starting game");
       
        SceneManager.LoadScene(_playGameScene);
    }
    public void MoveToExit(){
        FrontMenu.SetActive(false);
        ConfirmationMenu.SetActive(true);
    }   
    
    public void CancelExit(){
        FrontMenu.SetActive(true);
        ConfirmationMenu.SetActive(false);
    }     
    
    public void ConfirmExit(){
        Debug.Log("closing!");
        Application.Quit();
    }

}
