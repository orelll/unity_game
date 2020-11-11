using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerBody;
    float horizontalMovement;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello start");
    }

    // Update is called once per frame
    void Update()
    {
      CheckInput();
    }

    void CheckInput(){
        horizontalMovement = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer(){
        playerBody.velocity = new Vector2(horizontalMovement , playerBody.velocity.y);
    }
}
