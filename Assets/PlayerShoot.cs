using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform tossPoint;
    public GameObject coffee;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            ThrowCoffee();
        }
    }

    private void ThrowCoffee()
    {
        Instantiate(coffee, tossPoint.position, tossPoint.rotation);
    }
}
