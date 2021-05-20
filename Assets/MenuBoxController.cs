﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using unity_game_master.Assets.DTOs;
public class MenuBoxController : MonoBehaviour
{
    public GameObject MenuGameObject;

    public GameObject PlayerGameObject;
    public GameObject GemSpawnerGameObject;
    public GameObject FrogSpawnerGameObject;

    // Start is called before the first frame update
    void Start()
    {
        MenuGameObject.SetActive(false);
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

    private void SaveGame()
    {
        var playerController = PlayerGameObject.GetComponentInChildren<PlayerController>();
        var gemsController = PlayerGameObject.GetComponentInChildren<GemSpawnerController>();
        var frogsController = PlayerGameObject.GetComponentInChildren<FrogAreaController>();

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
    }
}
