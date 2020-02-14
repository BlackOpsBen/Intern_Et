using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDuplicates : MonoBehaviour
{
    private void Awake()
    {
        int numObjects = FindObjectsOfType<NoDuplicates>().Length;
        if (numObjects > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
