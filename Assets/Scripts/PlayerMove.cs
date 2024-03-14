using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform camera;
    [Header("Movement")]
    [Tooltip("Speed")]
    [SerializeField]
    private float speed;
    [Tooltip("Ground Drag")]
    [SerializeField]
    private float groundDrag;
    [Tooltip("Jump Force")]
    [SerializeField]
    private float jForce;
    [Tooltip("Air Multiplier")]
    [SerializeField]
    private float aMultiplier;

    bool grounded;
    
    //movement
    float hInput;
    float vInput;
    Vector3 moveDirection;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        hInput = 0;
        vInput = 0;

        //forward
        if (Input.GetKey(KeyCode.W))
        {
            vInput = 1;
        }
        //backward
        else if (Input.GetKey(KeyCode.S))
        {
            vInput = -1;
        }
        //right
        if (Input.GetKey(KeyCode.D))
        {
            hInput = 1; 
        }
        //left
        else if (Input.GetKey(KeyCode.A))
        {
            hInput = -1; // Left movement along the x-axis
        }

        //jump 
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }

        SpeedControl();

        //moves player
        MovePlayer();
        
        //applies drag
        if (grounded) 
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }
    void LateUpdate ()
    {
        //orientates player to camera
        Vector3 eulerRotation = new Vector3(transform.eulerAngles.x, camera.transform.eulerAngles.y, transform.eulerAngles.z);
        transform.rotation = Quaternion.Euler(eulerRotation);
    }

    private void MovePlayer()
    {
        Vector3 forwardDirection = camera.forward; 
        forwardDirection.y = 0; 

        moveDirection = forwardDirection * vInput + camera.right * hInput;

        if (grounded)
            rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);

        else if (!grounded) 
            rb.AddForce(moveDirection.normalized *speed * aMultiplier, ForceMode.Force);
    }

    private void SpeedControl ()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jForce, ForceMode.Impulse);
        grounded = false;
    }
    //checks if player is on ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            grounded = true;
        }
    }
}
