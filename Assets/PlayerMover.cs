using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    float movementAxis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementAxis = Input.GetAxis("Horizontal");
        transform.position = transform.position + new Vector3(movementAxis * Time.deltaTime * moveSpeed, 0f, 0f);
        if (movementAxis < 0)
        {

        }
    }
}
