using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaddersDriver : MonoBehaviour
{
    public float verticalSpeed = 6;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var script = other.GetComponentInParent<PlayerController>();

            if (Input.GetKey(KeyCode.W))
            {
                
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, verticalSpeed);

            }
            else if (Input.GetKey(KeyCode.S))
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -verticalSpeed);
            }
        }
        else
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

    }
}
