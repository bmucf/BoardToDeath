using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

public class NonPhysicsMovement : MonoBehaviour
{
    Vector3 movementDirection;

    public GameObject olliePivot;

    public float startBurst = 10f;
    public float maxSpeed = 30f;
    public float turnSpeed = 1f;
    public float restAngle = -35f;
    public float gravityForce = 9.81f;


    [SerializeField] private bool isMoving;
    [SerializeField] private bool isTurning;
    [SerializeField] private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //applies a constant downward force, to simulate falling
        transform.Translate(Vector3.down * gravityForce * Time.deltaTime, Space.World);

        OrientToGround();





        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))

        //{
        //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1.5f, Color.yellow);
        //    transform.LookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z - hit.distance), Vector3.up);
        //    isGrounded = true;
        //}
        //else
        //{
        //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1.5f, Color.white);
        //    Debug.Log("Did not Hit");
        //    isGrounded = false;
        //}




        //if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        //{
        //    transform.position += transform.up * 20;
        //}

        ////changes the rotation speed based on if the player is moving or not
        //if (!isMoving)
        //{
        //    turnSpeed = 0.25f;
        //}
        //else
        //{
        //    turnSpeed = 0.5f;
        //}


        ////moves the player forward
        //if (Input.GetKey(KeyCode.W))
        //{
        //    isMoving = true;
        //    gameObject.transform.position += transform.forward * startBurst * Time.deltaTime;
        //}
        //else
        //{
        //    isMoving = false;
        //}

        ////rotates the player left
        //if (Input.GetKey(KeyCode.A) && !isTurning)
        //{
        //    isTurning = true;
        //    gameObject.transform.RotateAround(pivotPoint.transform.position, Vector3.up, 1 * -turnSpeed);
        //}
        //else
        //{
        //    isTurning = false;
        //}

        ////rotates the player right
        //if (Input.GetKey(KeyCode.D) && !isTurning)
        //{
        //    isTurning = true;
        //    gameObject.transform.RotateAround(pivotPoint.transform.position, Vector3.up, 1 * turnSpeed);
        //}
        //else
        //{
        //    isTurning = false;
        //}
    }

    public void OrientToGround()
    {
        //detects whether there is a ground below
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.25f))
        {
            // Surface normal (the "up" direction of the ground)
            Vector3 surfaceNormal = hit.normal;

            // Build a rotation so that the object's "down" (-transform.up) matches the surface normal
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, surfaceNormal) * transform.rotation;

            // Smooth rotation to align
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);
        }
    }
}
