using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{
    public Material stillForwardMat;
    public Material stillBackwardMat;
    public Material stillLeftMat;
    public Material stillRightMat;
    public Material[] runLeftMats;
    public Material[] runRightMats;
    public Material[] runForwardMats;
    public Material[] runBackMats;

    private Renderer planeRenderer;
    private int currentRunIndex;
    private int frameCounter;
    private int frameDelay = 10;

    private void Start()
    {
        planeRenderer = GetComponent<Renderer>();
        // Set the initial material
        planeRenderer.material = stillForwardMat;
    }

    private void Update()
    {
        StartCoroutine(Run());
    }

    //make coroutine
    private IEnumerator Run () {
        //left
        if (Input.GetKey(KeyCode.A) == true /*&& Input.GetKey(KeyCode.W) == false 
            || Input.GetKey(KeyCode.S) == false || Input.GetKey(KeyCode.D) == false*/) {
            currentRunIndex = 0;
            frameCounter = 0;
            planeRenderer.material = runLeftMats[currentRunIndex];
            while (Input.GetKey(KeyCode.A)){
                frameCounter++;
                yield return null;
                //wait until next frame thing
                Debug.Log(currentRunIndex);
                if (frameCounter >= frameDelay)
                {
                    frameCounter = 0;
                    // Change to the next run material
                    currentRunIndex += 1;
                    if (currentRunIndex > runLeftMats.Length-1){
                        currentRunIndex = 0;
                    }
                    planeRenderer.material = runLeftMats[currentRunIndex];
                }
            }
            planeRenderer.material = stillLeftMat;
        }

        //right
        else if (Input.GetKey(KeyCode.D) == true)
        {
            currentRunIndex = 0;
            frameCounter = 0;
            planeRenderer.material = runRightMats[currentRunIndex];
            while (Input.GetKey(KeyCode.D)){
                frameCounter++;
                yield return null;
                //wait until next frame thing
                Debug.Log(currentRunIndex);
                if (frameCounter >= frameDelay)
                {
                    frameCounter = 0;
                    // Change to the next run material
                    currentRunIndex += 1;
                    if (currentRunIndex > runRightMats.Length-1){
                        currentRunIndex = 0;
                    }
                    planeRenderer.material = runRightMats[currentRunIndex];
                }
            }
            planeRenderer.material = stillRightMat;
        }

        //up
        else if (Input.GetKey(KeyCode.W) == true)
        {
            currentRunIndex = 0;
            frameCounter = 0;
            planeRenderer.material = runForwardMats[currentRunIndex];
            while (Input.GetKey(KeyCode.W)){
                frameCounter++;
                yield return null;
                //wait until next frame thing
                Debug.Log(currentRunIndex);
                if (frameCounter >= frameDelay)
                {
                    frameCounter = 0;
                    // Change to the next run material
                    currentRunIndex += 1;
                    if (currentRunIndex > runForwardMats.Length-1){
                        currentRunIndex = 0;
                    }
                    planeRenderer.material = runForwardMats[currentRunIndex];
                }
            }
            planeRenderer.material = stillForwardMat;
        }

        //down
        else if (Input.GetKey(KeyCode.S) == true)
        {
            currentRunIndex = 0;
            frameCounter = 0;
            planeRenderer.material = runBackMats[currentRunIndex];
            while (Input.GetKey(KeyCode.S)){
                frameCounter++;
                yield return null;
                //wait until next frame thing
                Debug.Log(currentRunIndex);
                if (frameCounter >= frameDelay)
                {
                    frameCounter = 0;
                    // Change to the next run material
                    currentRunIndex += 1;
                    if (currentRunIndex > runBackMats.Length-1){
                        currentRunIndex = 0;
                    }
                    planeRenderer.material = runBackMats[currentRunIndex];
                }
            }
            planeRenderer.material = stillBackwardMat;
        }
        yield break;
    }
}
