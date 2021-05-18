using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameController : MonoBehaviour
{
    private int _mainMenuAddress = 0;
    private string _level1Scene = "Level1Scene";

    public void StartNewGame()
    {
        SceneManager.LoadScene(_level1Scene);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(_level1Scene);
    }

    public void MoveBack()
    {
        SceneManager.LoadScene(_mainMenuAddress);
    }
}
