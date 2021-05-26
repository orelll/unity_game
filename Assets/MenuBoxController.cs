using UnityEngine;
using System.Linq;
using unity_game_master.Assets.DTOs;
public class MenuBoxController : MonoBehaviour
{
    public GameObject MenuGameObject;
    public GameObject GameControllerGameObject;

    private GameController _gameController;


    // Start is called before the first frame update
    void Start()
    {
        MenuGameObject.SetActive(false);
        _gameController = GameControllerGameObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsEscPressed)
        {
            MenuGameObject.SetActive(true);
        }

    }

    private bool IsEscPressed => Input.GetKeyDown(KeyCode.Escape);
}
