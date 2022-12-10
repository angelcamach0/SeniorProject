//import Unity libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls camera and shifts perspective to the location the player is currently at in the game world
public class CameraControl : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

   //When a camera cut transitions to another level do not destroy the current game object transitioning into a different scene
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    
    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
    }
}
