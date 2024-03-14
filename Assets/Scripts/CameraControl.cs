using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform player; // The object to orbit around
    [Tooltip("Distance from player")]
    [SerializeField]
    public float distance = 10;
    [Tooltip("Rotation Speed")]
    [SerializeField]
    public float rSpeed = 50;

    private float currentX = 0f;
    private float currentY = 0f;

    void Start()
    {
        // Set initial position
        transform.position = player.position + new Vector3(0, 0, -distance);
    }

    void Update()
    {
        float hInput = 0;
        float vInput = 0;

        if (currentX <= 60) 
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                vInput = 1;
            }
        }
        if (currentX >= 0) 
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                vInput = -1;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            hInput = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hInput = -1;
        }

        // Update current angles based on input
        currentX += vInput * rSpeed * Time.deltaTime;
        currentY += hInput * rSpeed * Time.deltaTime;

        // Calculate the new position based on angles
        Quaternion rotation = Quaternion.Euler(currentX, currentY, 0);
        Vector3 newPosition = player.position + rotation * new Vector3(0f, 0f, -distance);

        // Apply the new position and look at the target
        transform.position = newPosition;
        transform.LookAt(player);
    }
}
