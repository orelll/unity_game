using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level1MenuController : MonoBehaviour
{
    private int _mainMenuAddress = 0;
    public GameObject FrontMenu;
    public GameObject ConfirmationMenu;

    public void JumptoConfrmation()
    {
        FrontMenu.SetActive(false);
        ConfirmationMenu.SetActive(true);
    }

    public void CancelExit()
    {
        FrontMenu.SetActive(true);
        ConfirmationMenu.SetActive(false);
    }

    public void ConfirmExit()
    {
        SceneManager.LoadScene(_mainMenuAddress);
    }

    public void HideMenu()
    {
        this.gameObject.SetActive(false);
    }

}
