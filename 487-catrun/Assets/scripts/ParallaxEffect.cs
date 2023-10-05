using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera cam;
    public Transform followTarget;

    //starting position for the paralax game object
    Vector2 startingPosition;

    //starting Z value of the parallax game object
    float startingZ;

    //distance that the camera has moved from the starting position of the parallax 
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;

    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;
    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    //the further the object from the player the faster the parallax object effect will move
    //closer Z value is to target, the slower it will move
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
        
    }

    // Update is called once per frame
    void Update()
    {
        //when the target moves, move the parallax object the same distance * the multiplier
        Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;

        //the X and Y position changed based on target travel speed * parallaxFactor
        //Z stays consistent
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
