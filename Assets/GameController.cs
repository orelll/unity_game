using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using unity_game_master.Assets.DTOs;
using Newtonsoft.Json;

public class GameController : MonoBehaviour
{
    public GameObject PlayerGameObject;
    public GameObject GemSpawnerGameObject;
    public GameObject FrogSpawnerGameObject;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($@"Load game state is: {PlayGameController.LoadGameState}");
        SaveGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveGame()
    {
        var playerController = PlayerGameObject.GetComponentInChildren<PlayerController>();
        var gemsController = GemSpawnerGameObject.GetComponentInChildren<GemSpawnerController>();
        var frogsController = FrogSpawnerGameObject.GetComponentInChildren<FrogAreaController>();

        var gemsPositions = gemsController.GemsList.Select(x => new PointDTO { X = x.transform.position.x, Y = x.transform.position.y });
        var frogsPositions = frogsController.FrogsList.Select(x => new PointDTO { X = x.transform.position.x, Y = x.transform.position.y });

        var gameState = new GameStateDTO
        {
            HPState = playerController.Health,
            Position = new PointDTO
            {
                X = playerController.transform.position.x,
                Y = playerController.transform.position.y,
            },
            Gems = gemsPositions.ToList(),
            Frogs = frogsPositions.ToList()
        };

        var gameStateAsJson = JsonConvert.SerializeObject(gameState);
        
    }
}
