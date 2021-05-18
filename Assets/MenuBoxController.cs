using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBoxController : MonoBehaviour
{
    public GameObject MenuGameObject;

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
}
