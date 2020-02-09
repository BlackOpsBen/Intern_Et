using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    [SerializeField] Animator animator;
    public bool isFixed = false;
    [SerializeField] AudioSource fixSound;

    public void Fix(GameManager gameManager)
    {
        if (!isFixed)
        {
            fixSound.Play();
            isFixed = true;
            animator.SetBool("isFixed", true);
            if(gameManager)
            {
                gameManager.UpdatePCCounter();
            }
        }
    }
}
