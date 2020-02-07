using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    public Animator animator;
    bool isFacingLeft = false;

    float movementAxis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementAxis = Input.GetAxis("Horizontal");
        
        // Move the player left and right
        transform.position = transform.position + new Vector3(movementAxis * Time.deltaTime * moveSpeed, 0f, 0f);

        ToggleRunAnimation();

        // Player flip left
        if (movementAxis < float.Epsilon)
        {
            if (!isFacingLeft)
            {
                transform.Rotate(0f, 180f, 0f);
                isFacingLeft = true;
            }
        }
        else if (movementAxis > float.Epsilon)
        {
            if(isFacingLeft)
            {
                transform.Rotate(0f, 180f, 0f);
                isFacingLeft = false;
            }
        }

        // TODO Fix player always looking left after stopping movement

    }

    private void ToggleRunAnimation()
    {
        if (Input.GetButton("Horizontal"))
        {
            print("Running!");
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
