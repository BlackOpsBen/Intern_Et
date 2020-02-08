using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PC>())
        {
            PC pc = collision.GetComponent<PC>();
            if (Input.GetAxisRaw("Vertical") > float.Epsilon || Input.GetButtonDown("Fix"))
            {
                pc.Fix();
            }
        }
    }
}
