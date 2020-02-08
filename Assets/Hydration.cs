using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydration : MonoBehaviour
{
    [SerializeField] static float maxHydration = 10f;
    [SerializeField] float hydrationLevel = maxHydration;
    [SerializeField] float lossAmount = 1f;
    [SerializeField] float lossRate = 1f;

    private void Start()
    {
        StartCoroutine(loseHydration());
    }

    private IEnumerator loseHydration()
    {
        while (hydrationLevel > float.Epsilon)
        {
            hydrationLevel -= lossAmount;
        }
        yield return new WaitForSeconds(lossRate);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "WaterCooler")
        {
            print("Water refilled!");
        }
    }
}
