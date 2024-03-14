using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    [Tooltip("Start Scale")]
    [SerializeField]
    public Vector3 sScale = new Vector3(1, 1, 1);
    [Tooltip("End Scale")]
    [SerializeField]
    public Vector3 eScale = new Vector3(2, 2, 2);
    [Tooltip("Scale Speed")]
    [SerializeField]
    public float sSpeed = 1;

    private float timeElapsed = 0;

    void Update()
    {
        /*calculates the interpolation parameter using the timeElapsed 
        and scale speed*/
        float t = Mathf.PingPong(timeElapsed * sSpeed, 1);

        //interpolates between the start and end scale
        Vector3 newScale = Vector3.Lerp(sScale, eScale, t);

        //updates the scale of the object
        transform.localScale = newScale;

        //increments the timeElapsed
        timeElapsed += Time.deltaTime;
    }
}
