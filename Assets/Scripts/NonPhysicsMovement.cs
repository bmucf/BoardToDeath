using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

public class NonPhysicsMovement : MonoBehaviour
{
    Vector3 movementDirection;

    public GameObject olliePivot;
    public Collider[] wheels;

    public float startBurst = 10f;
    public float maxSpeed = 30f;
    public float turnSpeed = 1f;
    public float restAngle = -35f;
    public float gravityForce = 9.81f;
    Vector3 gravPull = Vector3.down;

    [SerializeField] private bool isMoving;
    [SerializeField] private bool isTurning;
    [SerializeField] private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //applies a constant downward force, to simulate falling
        transform.Translate(gravPull * gravityForce * Time.deltaTime, Space.World);

        CheckIfOnGround();

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += transform.up * 5;
        }

        //changes the rotation speed based on if the player is moving or not
        if (!isMoving)
        {
            turnSpeed = 0.25f;
        }
        else
        {
            turnSpeed = 0.5f;
        }


        //moves the player forward
        if (Input.GetKey(KeyCode.W))
        {
            isMoving = true;
            gameObject.transform.position += transform.forward * startBurst * Time.deltaTime;
        }
        else
        {
            isMoving = false;
        }

        //rotates the player left
        if (Input.GetKey(KeyCode.A) && !isTurning)
        {
            isTurning = true;
            gameObject.transform.RotateAround(olliePivot.transform.position, Vector3.up, 1 * -turnSpeed);
        }
        else
        {
            isTurning = false;
        }

        //rotates the player right
        if (Input.GetKey(KeyCode.D) && !isTurning)
        {
            isTurning = true;
            gameObject.transform.RotateAround(olliePivot.transform.position, Vector3.up, 1 * turnSpeed);
        }
        else
        {
            isTurning = false;
        }

        for (int i = 0; i < wheels.Length; i++)
        {
            
        }
    }

    public void CheckIfOnGround()
    {
        //detects whether there is a ground below
        RaycastHit hit;

        if (Physics.Raycast(transform.position, gravPull, out hit, 0.17f))
        {
            Vector3 surfaceNormal = hit.normal; //stores normals of surface hit by raycast
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, surfaceNormal) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);

            gravityForce = 0;
            isGrounded = true;
        }
        else
        {
            gravityForce = 9.81f;
            isGrounded = false;
        }
    }
}
