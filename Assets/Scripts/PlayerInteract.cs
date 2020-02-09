using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    float interactionThreshold = 0.95f;
    float verticalAxisRaw;
    bool doneInteracting = false;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        verticalAxisRaw = Input.GetAxisRaw("Vertical");

        if ( (verticalAxisRaw > interactionThreshold || Input.GetButtonDown("Fix")) && !doneInteracting)
        {
            doneInteracting = true;
        }
        if ( (verticalAxisRaw < 1 - interactionThreshold || Input.GetButtonUp("Fix")) && doneInteracting )
        {
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
                pc.Fix(gameManager);
            }
        }
    }
}
