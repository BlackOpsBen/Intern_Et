using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseElevator : MonoBehaviour
{
    Elevator elevator;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Elevator>())
        {
            elevator = collision.gameObject.GetComponent<Elevator>();

            if (Input.GetAxisRaw("Vertical") == 1)
            {
                GoUp();
            }
            else if (Input.GetAxisRaw("Vertical") == -1)
            {
                GoDown();
            }
        }
    }

    private void GoUp()
    {
        if (elevator.goingUp)
        {
            print("Going UP from " + elevator.name);
        }
        else
        {
            print("Can't go up.");
        }
    }

    private void GoDown()
    {
        if (elevator.goingDown)
        {
            print("Going DOWN from " + elevator.name);
        }
        else
        {
            print("Can't go down.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Elevator>())
        {
            elevator = null;
        }
    }

    private void Update()
    {
        
    }
}
