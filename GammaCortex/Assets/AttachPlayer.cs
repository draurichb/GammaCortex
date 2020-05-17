using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayer : MonoBehaviour
{
    public GameObject Player;
    public Animation ElevatorAnimation;
    public float timeToGo = 2f;
    private float timeSwitch;
    private bool playerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = transform;
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player.transform.parent = null;
        timeSwitch = timeToGo;
        playerInside = false;
    }

    private void Start()
    {
        timeSwitch = timeToGo;
    }

    private void Update()
    {
        if (playerInside)
        {
            timeSwitch -= Time.deltaTime;
            if (timeSwitch <= 0)
            {
                if (this.transform.position.y == 0f)
                {
                    ElevatorAnimation.Play("ElevatorY");
                }
                if (this.transform.position.x == 8.16f)
                {
                    ElevatorAnimation.Play("Elevator-Y");
                }
            }
        }
    }
}
