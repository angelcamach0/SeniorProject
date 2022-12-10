//import Unity libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creates ground and ceiling making static colliders both beneath and overhead the player starting location to prevent users from moving off the current gameScene
public class GroundCollider : MonoBehaviour
{
    //create a BoxCollider for ground level that enables characters to not move off screen either horizontally or vertically
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

    // Start is called before the first frame update
    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
    }
        

    // Update is called once per frame
    void Update()
    {
         if (transform.position.x < -groundHorizontalLength)
        {
            RepositionBackground();
        }
    }

     //Reposition ground level during each frame in respect to character and enemy movement
     private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}

