using UnityEngine;

public class Parallax: MonoBehaviour
{
    private float startPos, length; //Stores starting position of the background
    public GameObject cam;
    public float parallaxEffect; //Speed at which the background moves

    void Start()
    {
        startPos = transform.position.x; //Sets startpos to the inital position
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void LateUpdate()
    {
        float distance = cam.transform.position.x * parallaxEffect; //Calculates how far the camera should move
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z); // Actually moves the background based on that distance

        //Infinite scrolling
        float movement = cam.transform.position.x * (1 - parallaxEffect); // Calculates when the camera has gone far enough that the background should loop

        if (movement > startPos + length) // This checks if camera has moved more than one background-width to the right
        {
            startPos += length; //Moves background ahead to continue scrolling
        }
        else if (movement < startPos - length)// This checks if camera has moved more than one background-width to the left
        {
            startPos -= length;
        }
    }
}
