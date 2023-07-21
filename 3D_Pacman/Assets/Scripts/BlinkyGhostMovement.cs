using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkyGhostMovement : MonoBehaviour
{
    public Transform player;

    private float speed = 0.075f;
    private float ghostX;
    private float ghostZ;

    private float playerX;
    private float playerZ;

    // Update is called once per frame
    void Update()
    {
        getPos();

        
        string direction = checkDirections();
        float rotationVal = 0;
        
        Vector3 ghostPos = new Vector3(0, 0, 0);
        if(direction.Equals("RIGHT")){
            ghostPos.x += speed;
            rotationVal = 90;
        }
        else if(direction.Equals("LEFT")){
            ghostPos.x -= speed;
            rotationVal = -90;

        }
        else if(direction.Equals("BACKWARD")){
            ghostPos.z -= speed;
            
        }
        else{
            ghostPos.z += speed;
        }

        transform.position += ghostPos;
        
        Vector3 rotationVector = new Vector3(0, rotationVal, 0);
        transform.rotation = Quaternion.Euler(rotationVector);
    }

    private void getPos(){
        ghostX = transform.position.x;
        ghostZ = transform.position.z;

        playerX = player.position.x;
        playerZ = player.position.z;

    }

    private float calculateEuclidian(float g_x, float g_z, float p_x, float p_z){
        float deltaX = p_x - g_x;
        float deltaY = p_z - g_z;

        float euclidianDistance = (deltaX * deltaX) + (deltaY * deltaY);
        return euclidianDistance;


    }

    private string checkDirections(){
        
        
        float ifRight = calculateEuclidian(ghostX + speed, ghostZ, playerX, playerZ);
        float ifLeft = calculateEuclidian(ghostX - speed, ghostZ, playerX, playerZ);
        float ifForward = calculateEuclidian(ghostX, ghostZ + speed, playerX, playerZ);
        float ifBackward = calculateEuclidian(ghostX, ghostZ - speed, playerX, playerZ);

        string dir = "FORWARD";
        

        if(ifRight < ifLeft && ifRight < ifForward && ifRight < ifBackward){
            dir = "RIGHT";


        }
        else if(ifLeft < ifRight && ifLeft < ifForward && ifLeft < ifBackward){
            dir = "LEFT";


        }
        else if(ifBackward < ifRight && ifBackward < ifLeft && ifBackward < ifForward){
            dir = "BACKWARD";

        }

        Debug.Log(ifRight + " " + ifLeft + " " + ifForward + " " + dir);
        return dir;

        
        

    }
}
