using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    [SerializeField] Animator animator;
    public bool isFixed = false;

    public void Fix()
    {
        isFixed = true;
        animator.SetBool("isFixed", true);
    }
}
