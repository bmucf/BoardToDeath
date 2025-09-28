using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class NonPhysicsMovement : MonoBehaviour
{
    public int groundedSensors;
    public GameObject pivotPoint;
    public Collider[] surfaceSensors;

    

    public float startBurst = 10.0f;
    public float maxSpeed = 1.0f;
    public float turnSpeed = 1.0f;
    public float restAngle = -35f;
    public float gravityForce = 9.81f;


    [SerializeField] private bool isMoving;
    [SerializeField] private bool isTurning;
    [SerializeField] private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (Collider sensor in surfaceSensors)
        {
            RaycastHit hit;
            Vector3 origin = sensor.transform.position;
            Vector3 direction = transform.TransformDirection(Vector3.down);

            if (Physics.Raycast(origin, direction, out hit, Mathf.Infinity))
            {
                Vector3 groundDistance = new Vector3(transform.position.x, 0.25f, transform.position.z);

                Debug.DrawRay(origin, direction * hit.distance, Color.yellow);

                if (hit.distance == groundDistance.y)
                {
                    isGrounded = true;
                }
                if (hit.distance > groundDistance.y)
                {
                    transform.Translate(Vector3.down * gravityForce * Time.deltaTime);
                    isGrounded = false;
                }
                else
                {
                    Debug.Log("Too far.");
                }
            }
        }

        ////gravity
        //if (groundedSensors == 0)
        //{
           
        //}
        //else if (groundedSensors == 4 && transform.position.y > groundDistance)
        //{
        //    transform.position = new Vector3(transform.position.x, groundDistance, transform.position.z);
            
        //}

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += transform.up * 20;
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
            gameObject.transform.RotateAround(pivotPoint.transform.position, Vector3.up, 1 * -turnSpeed);
        }
        else
        {
            isTurning = false;
        }

        //rotates the player right
        if (Input.GetKey(KeyCode.D) && !isTurning)
        {
            isTurning = true;
            gameObject.transform.RotateAround(pivotPoint.transform.position, Vector3.up, 1 * turnSpeed);
        }
        else
        {
            isTurning = false;
        }
    }
}
