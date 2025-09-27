using UnityEngine;

public class NonPhysicsMovement : MonoBehaviour
{
    public float startBurst = 10.0f;
    public float maxSpeed = 1.0f;
    float speed;
    [SerializeField] bool isMoving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            isMoving = true;
            Debug.Log(isMoving);
            gameObject.transform.position += transform.forward * startBurst * Time.deltaTime;
        }
        else
        {
            isMoving = false;
            Debug.Log(isMoving);
        }



    }
}
