using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    public Vector3 cameraPos;
    
    
    private float horizontalInput;
    private float verticalInput;

    // Update is called once per frame
    void Start() {

        // Reset's the camera's position 
        transform.position = new Vector3(0, 0, 0);
        cameraPos.y -= player.position.y;
        
    }


    void Update(){
        GetInput();
        

        Vector3 p_x = player.forward * cameraPos.z;
        Vector3 p_z = player.right * cameraPos.x;
        
        Vector3 localOffset = (p_x + p_z) + new Vector3(0, cameraPos.y, 0);


        transform.position = player.position + localOffset;
        transform.rotation = player.rotation;

    }

    private void GetInput(){
        horizontalInput = Input.GetAxis("Horizontal");
    }

    
}
