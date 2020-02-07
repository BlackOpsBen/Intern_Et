﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseElevator : MonoBehaviour
{
    Elevator elevator;

    [SerializeField] float elevatorStepTime = 0.1f;

    public PlayerMover playerMover;

    public SpriteRenderer spriteRenderer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!playerMover.isBusy)
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
    }

    private void GoUp()
    {
        if (elevator.goingUp)
        {
            print("Going UP from " + elevator.name);
            StartCoroutine(ElevateTo(elevator.goingUp));
        }
        else
        {
            print("Can't go up.");
        }
    }

    private IEnumerator ElevateTo(Elevator destination)
    {
        // Set player to isBusy (which prevents further movement/interaction)
        playerMover.isBusy = true;

        // Snap player in front of elevator
        transform.position = elevator.entryPoint.transform.position;

        // Open door
        elevator.door.SetActive(false);
        yield return new WaitForSeconds(elevatorStepTime);

        // Move player inside current elevator AND set player behind elevator entry so his head is covered
        spriteRenderer.sortingLayerName = "Background";
        spriteRenderer.sortingOrder = 2;
        transform.position = elevator.insidePoint.transform.position;
        yield return new WaitForSeconds(elevatorStepTime);

        // Close door
        elevator.door.SetActive(true);
        yield return new WaitForSeconds(elevatorStepTime);

        // Move player inside new elevator
        transform.position = destination.insidePoint.transform.position;
        yield return new WaitForSeconds(elevatorStepTime);

        // Open door
        destination.door.SetActive(false);
        yield return new WaitForSeconds(elevatorStepTime);

        // Move player outside new elevator AND set back to normal sorting layer/order
        spriteRenderer.sortingLayerName = "Foreground";
        spriteRenderer.sortingOrder = 2;
        transform.position = destination.entryPoint.transform.position;

        // and close door
        destination.door.SetActive(true);
        yield return new WaitForSeconds(elevatorStepTime);

        // Set player to !isBusy (which gives back control)
        playerMover.isBusy = false;
        yield return new WaitForSeconds(elevatorStepTime);
        print("Ready to move!");
    }

    private void GoDown()
    {
        if (elevator.goingDown)
        {
            print("Going DOWN from " + elevator.name);
            StartCoroutine(ElevateTo(elevator.goingDown));
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
