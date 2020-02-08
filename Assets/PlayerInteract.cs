using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    float interactionThreshold = 0.95f;
    float verticalAxisRaw;
    bool doneInteracting = false;

    private void Update()
    {
        verticalAxisRaw = Input.GetAxisRaw("Vertical");
        print(verticalAxisRaw);

        if ( (verticalAxisRaw > interactionThreshold || Input.GetButtonDown("Fix")) && !doneInteracting)
        {
            print("Interaction done.");
            doneInteracting = true;
        }
        if ( (verticalAxisRaw < 1 - interactionThreshold || Input.GetButtonUp("Fix")) && doneInteracting )
        {
            print("Interaction refreshed!");
            doneInteracting = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PC>())
        {
            PC pc = collision.GetComponent<PC>();
            if ((Input.GetAxisRaw("Vertical") > float.Epsilon || Input.GetButtonDown("Fix")) && !doneInteracting)
            {
                pc.Fix();
            }
        }
    }
}
