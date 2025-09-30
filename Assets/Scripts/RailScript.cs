using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class RailScript : MonoBehaviour
{
    PlayerMovement PlayerMovement;

    public Transform triggerA;
    public Transform triggerB;
    public GameObject player;

    //[Header("Movement Settings")]
    //public float reachThreshold = 0.2f;
    //public float throwForce = 10f;

    //private GameObject player;
    //private Transform targetTrigger;
    //private bool moving = false;

    private void Start()
    {
        player
    }

    void Update()
    {
        if (player.GetComponent<Collider>().bounds.Intersects(triggerA.GetComponent<Collider>().bounds));
        {
            player.transform.position = triggerB.position;
        }
    }
}
