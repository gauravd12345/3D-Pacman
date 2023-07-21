using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRigidBody;
    public Transform camera;

    public float speed;
    public float revolutionTime;
    public float maxRotationAngle;

    private float horizontalInput;
    private float verticalInput;
    private float rotationVal;

    void Start() {
        playerRigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update(){

        // Gets the horizontal and vertical inputs
        GetInput();

        Vector3 c_z;
        Vector3 c_x = camera.forward * verticalInput;
        if (verticalInput != 0) {
            c_z = camera.right * horizontalInput * Mathf.Cos(camera.eulerAngles.y * Mathf.Deg2Rad);
        }
        else {
            c_z = new Vector3(0, 0, 0);
        }

        playerRigidBody.velocity = ((c_x + c_z) * speed);

        
        float rotationCheck = (horizontalInput * maxRotationAngle * Time.deltaTime) / revolutionTime;
        rotationVal += rotationCheck;

        
        Vector3 rotationVector = new Vector3(0, rotationVal, 0);
        transform.rotation = Quaternion.Euler(rotationVector);
        
        
        
    }

    private void GetInput(){
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    
}
