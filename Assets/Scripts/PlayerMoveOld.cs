using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveOld : MonoBehaviour
{
    public Transform camera;

    
    [Tooltip("Speed")]
    [SerializeField]
    private float speed = 5;
    [Tooltip("Jump Force")]
    [SerializeField]
    private float jForce = 1;
    float hInput;
    float vInput;
    private Rigidbody rb;
    private bool isOnGround = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        // Check for input keys
        if (Input.GetKey(KeyCode.W))
        {
            vInput = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vInput = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            hInput = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            hInput = -1;
        }

        Vector3 movement = new Vector3(hInput, 0, vInput);
        //change to something else, this causing it to be warped to into walls
        //try add addforce or rigidbody velocity
        transform.Translate(movement * speed * Time.deltaTime);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jForce, ForceMode.Impulse);
            isOnGround = false;
        }

        Vector3 eulerRotation = new Vector3(transform.eulerAngles.x, camera.transform.eulerAngles.y, transform.eulerAngles.z);

        transform.rotation = Quaternion.Euler(eulerRotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
        }
    }
}
