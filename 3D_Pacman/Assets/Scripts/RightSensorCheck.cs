using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSensorCheck : MonoBehaviour
{

    public GameObject ghost;
    private BlinkyGhostMovement script;
    private Transform ghostTransform;
    public bool displayCheck;

    public float xOff = 0.5f;

    void Start(){
        script = ghost.GetComponent<BlinkyGhostMovement>();
        ghostTransform = ghost.GetComponent<Transform>();

    }
    
    // Update is called once per frame
    void Update()
    {
        
        
        Vector3 offset = new Vector3(xOff, 0, 0);
        transform.position = ghostTransform.position + offset;
    }

    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.name == "Wall"){
            script.rightSensor = true;
            if(displayCheck){
                Debug.Log(gameObject.name + " was activated");
            }

        }
    }

    void OnTriggerExit(Collider collision){
        if(collision.gameObject.name == "Wall"){
                script.rightSensor = false;

        }
    }   
}
