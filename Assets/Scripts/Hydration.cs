using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydration : MonoBehaviour
{
    static float maxHydration = 10f;
    public float hydrationLevel = maxHydration;
    [SerializeField] float lossAmount = 1f;
    [SerializeField] float lossRate = 1f;
    [SerializeField] float thirstThreshold = 0.3f;
    [SerializeField] GameObject refillFX;
    [SerializeField] GameObject refillSound;
    public bool isHydrated = true;

    private void Start()
    {
        StartCoroutine(loseHydration());
    }

    private IEnumerator loseHydration()
    {
        while (hydrationLevel > float.Epsilon)
        {
            hydrationLevel -= lossAmount;
            if (hydrationLevel < maxHydration * thirstThreshold)
            {
                // Implement feedback to player that hydration is dangerously low.
                print("You are dangerously dehydrated! (Need to implement visual feedback.)"); // TODO remove
            }
            yield return new WaitForSeconds(lossRate);
        }
        isHydrated = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WaterCooler")
        {
            Instantiate(refillFX, collision.transform.position, Quaternion.identity);
            hydrationLevel = maxHydration;
        }
    }

    public float GetMaxHydration()
    {
        return maxHydration;
    }
}
