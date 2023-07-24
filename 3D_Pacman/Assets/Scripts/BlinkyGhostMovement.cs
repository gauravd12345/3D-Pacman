using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkyGhostMovement : MonoBehaviour{
    public Transform player;


    public float speed = 0.1f;
    private float ghostX;
    private float ghostZ;

    private string dir = "";
    private float playerX;
    private float playerZ;
    private float rotationVal;


    public bool rightSensor = false;
    public bool leftSensor = false;
    public bool forwardSensor = false;
    public bool backwardSensor = false;

    // Update is called once per frame
    void Update()
    {
        getPos();

        //Debug.Log(rightSensor + " " + leftSensor + forwardSensor + backwardSensor + dir);

        string direction = checkDirections();
        rotationVal = 0;
        

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
            rotationVal = 180;
        }
        else{
            ghostPos.z += speed;
            rotationVal = 0;

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

    private string[] checkMoveList(){
        string[] moveList = {"RIGHT", "LEFT", "FORWARD", "BACKWARD"}; 

        if(dir.Equals("LEFT")){
            moveList[0] = "";
        }
        if(dir.Equals("RIGHT")){
            moveList[1] = "";
        }
        if(dir.Equals("BACKWARD")){
            moveList[2] = "";
        }
        if(dir.Equals("FORWARD")){
            moveList[3] = "";
        }


        if(rightSensor){
            moveList[0] = "";

        }
        if(leftSensor){
            moveList[1] = "";

        }
        if(forwardSensor){
            moveList[2] = "";

        }

        if(backwardSensor){
            moveList[3] = "";

        }
        


        return moveList;
    }

    private bool checkArray(string[] moveList, string move){
        bool contained = false;
        for (int i = 0; i < moveList.Length; i++){
            

            if(moveList[i].Equals(move)){

                contained = true;

            }

        }

        return contained;
    }


    private string checkDirections(){
        string[] moveList = checkMoveList();
        
        

        

        string arrElements = "";

        for (int i = 0; i < moveList.Length; i++){

            arrElements += moveList[i] + " ";


        }
        
        //Debug.Log(arrElements + " Direction: " + dir);
        dir = returnSmallest(moveList);


        
        return dir;

        
        

    }

    private string returnSmallest(string[] moveList){

        string direction = "FORWARD";

        float ifRight = calculateEuclidian(ghostX + speed, ghostZ, playerX, playerZ);
        float ifLeft = calculateEuclidian(ghostX - speed, ghostZ, playerX, playerZ);
        float ifForward = calculateEuclidian(ghostX, ghostZ + speed, playerX, playerZ);
        float ifBackward = calculateEuclidian(ghostX, ghostZ - speed, playerX, playerZ);


        for(int i = 0; i < moveList.Length; i++){
            if(moveList[i].Equals("")){
                if(i == 0){
                    ifRight *= 10f;

                }
                else if(i == 1){
                    ifLeft *= 10f;

                }
                else if(i == 2){
                    ifForward *= 10f;

                }
                else{
                    ifBackward *= 10f;

                }
            }
        }

        //Debug.Log(ifRight < ifLeft && ifRight < ifForward && ifRight < ifBackward);

        if(checkArray(moveList, "RIGHT")){
            if(ifForward == ifRight){
                direction = "FORWARD";

            }
            else if(ifLeft == ifRight){
                direction = "LEFT";

            }
            else if(ifBackward == ifRight){
                direction = "BACKWARD";
                
            }
            
            if(ifRight < ifLeft && ifRight < ifForward && ifRight < ifBackward){
                direction = "RIGHT";
            }
            
            
        }
        if(checkArray(moveList, "LEFT")){
            if(ifForward == ifLeft){
                direction = "FORWARD";

            }
            else if(ifBackward == ifLeft){
                direction = "LEFT";

            }
            else if(ifRight == ifLeft){
                direction = "LEFT";
                
            }

            if(ifLeft < ifRight && ifLeft < ifForward && ifLeft < ifBackward){
                direction = "LEFT";
            }
            
            
        }


        if(checkArray(moveList, "BACKWARD")){       
            if(ifForward == ifBackward){
                direction = "FORWARD";

            }
            else if(ifLeft == ifBackward){
                direction = "LEFT";

            }
            else if(ifRight == ifBackward){
                direction = "BACKWARD";

            }
            
            if(ifBackward < ifForward && ifBackward < ifRight && ifBackward < ifLeft){
                direction = "BACKWARD";

            }   



        }

        
        //Debug.Log("RIGHT: " + ifRight + " LEFT: " + ifLeft + " FORWARD: " + ifForward + " BACKWARD: " + ifBackward + " Direction: " + dir);
        return direction;


    }



}
