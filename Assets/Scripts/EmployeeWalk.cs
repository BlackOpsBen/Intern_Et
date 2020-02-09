using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeWalk : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float walkInterval = 1f;
    [SerializeField] float walkSpeed = 1f;
    bool isFacingLeft = true;
    int direction = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RandomlyWalk());
    }

    private void Update()
    {
        if (animator.GetBool("isAngry") == false)
        {
            transform.position = transform.position + new Vector3(direction * Time.deltaTime * walkSpeed, 0f, 0f);
        }
        else
        {
            StopWalking();
        }
    }

    private IEnumerator RandomlyWalk()
    {
        while(true) // Do forever...
        {
            // Determin true or false
            // if true, Start walking
            if (UnityEngine.Random.Range(0,2) == 1)
            {
                StartWalking();
            }
            // else, Stop walking
            else
            {
                StopWalking();
            }
            // Wait X seconds
            yield return new WaitForSeconds(walkInterval);
        }

    }

    private void StartWalking()
    {
        // Start Walk Animation
        animator.SetBool("isWalking", true);

        // Determine Left or Right (-1 = Left, +1 = Right)
        direction = UnityEngine.Random.Range(0, 2)*2-1;

        if (direction == 1 && isFacingLeft)
        {
            transform.Rotate(0f, 180f, 0f);
            isFacingLeft = false;
        }
        else if (direction == -1 && !isFacingLeft)
        {
            transform.Rotate(0f, 180f, 0f);
            isFacingLeft = true;
        }
        
    }

    private void StopWalking()
    {
        animator.SetBool("isWalking", false);
        direction = 0;
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if(collision.tag == "MoveStop")
    //    {
    //        print("Emplyee hit wall!");
    //        direction = direction * -1;
    //        isFacingLeft = !isFacingLeft;
    //    }
    //}
}
