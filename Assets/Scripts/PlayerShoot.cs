using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] float throwInterval = 0.2f;
    [SerializeField] Animator animator;

    public Transform tossPoint;
    public GameObject coffee;
    bool isThrowing = false;
    public bool isBusy = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Shoot") && !isBusy)
        {
            if (!isThrowing)
            {
                StartCoroutine(ThrowCoffee());
            }
            else
            {
                print("Can't throw yet.");
            }
        }
        if (Input.GetButtonUp("Shoot"))
        {
            animator.SetBool("isThrowing", false);
        }
    }

    private IEnumerator ThrowCoffee()
    {
        isThrowing = true;
        animator.SetBool("isThrowing", true);
                                                                        // TODO add kickback/recoil
        Instantiate(coffee, tossPoint.position, tossPoint.rotation);
        yield return new WaitForSeconds(throwInterval);
        isThrowing = false;
    }
}
