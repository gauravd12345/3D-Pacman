using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackwardSensorCheck : MonoBehaviour
{
    public GameObject ghost;
    private BlinkyGhostMovement script;
    private Transform ghostTransform;

    public bool displayCheck;
    public float zOff = -0.5f;

    void Start(){
        script = ghost.GetComponent<BlinkyGhostMovement>();
        ghostTransform = ghost.GetComponent<Transform>();

    }
    
    // Update is called once per frame
    void Update()
    {
        
        
        Vector3 offset = new Vector3(0, 0, zOff);
        transform.position = ghostTransform.position + offset;
    }

    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.name == "Wall"){
            script.backwardSensor = true;
            if(displayCheck){
                Debug.Log(gameObject.name + " was activated");
            }

        }
    }

    void OnTriggerExit(Collider collision){
        if(collision.gameObject.name == "Wall"){
                script.backwardSensor = false;

        }
    }   
}
