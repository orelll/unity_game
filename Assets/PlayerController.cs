using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public LayerMask gorundLayer;
    public Transform groundChecker;
    
    public float playerSpeed = 1;
    public float jumpForce;

    bool jumpPressed;
    float horizontalMovement;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello start");
        playerSpeed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
      CheckInput();
    }

    void CheckInput(){
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        jumpPressed = Input.GetKeyDown(KeyCode.Space);
    }

    void FixedUpdate()
    {
        MovePlayer();
    }
    

    void MovePlayer(){
        var playerPosition = horizontalMovement * playerSpeed * Time.deltaTime;
        var yMovement = playerBody.velocity.y;

        if(jumpPressed && IsGrounded())
        {
            yMovement += jumpForce; // yMovement = yMovement + jumpForce;
        }

        playerBody.velocity = new Vector2(playerPosition , yMovement);
    }

    bool IsGrounded()
    {
        return true;
    }
}
