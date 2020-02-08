﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    public Animator animator;
    bool isFacingLeft = false;

    public bool isBusy = false;

    float movementAxis;
    float movementAxisRaw;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementAxis = Input.GetAxis("Horizontal");
        movementAxisRaw = Input.GetAxisRaw("Horizontal");
        
        // Move the player left and right
        if (!isBusy)
        {
            transform.position = transform.position + new Vector3(movementAxis * Time.deltaTime * moveSpeed, 0f, 0f);
        }

        ToggleRunAnimation();

        // New flip behavior
        if (movementAxisRaw < -0.1f)
        {
            if (!isFacingLeft)
            {
                transform.Rotate(0f, 180f, 0f);
                isFacingLeft = true;
            }
        }
        else if (movementAxisRaw > 0.1f)
        {
            if (isFacingLeft)
            {
                transform.Rotate(0f, 180f, 0f);
                isFacingLeft = false;
            }
        }

        // TODO add forward momentum when stopping running.

    }

    private void ToggleRunAnimation()
    {
        if (Input.GetButton("Horizontal"))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
