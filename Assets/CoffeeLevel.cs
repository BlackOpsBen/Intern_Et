using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeLevel : MonoBehaviour
{
    [SerializeField] static float maxCoffeeLevel = 10f;
    public float coffeeLevel = maxCoffeeLevel;
    [SerializeField] float lossRate = 1f;
    [SerializeField] float lossAmount = 1f;
    [SerializeField] float angerThreshold = 0.3f;
    [SerializeField] Animator animator;

    private void Start()
    {
        StartCoroutine(loseCoffee());
    }

    private IEnumerator loseCoffee()
    {
        while (coffeeLevel > float.Epsilon)
        {
            coffeeLevel -= lossAmount;
            print(coffeeLevel); // TODO remove
            if (coffeeLevel < maxCoffeeLevel * angerThreshold)
            {
                animator.SetBool("isAngry", true);
            }
            yield return new WaitForSeconds(lossRate);
        }
        print("Out of coffee! Game over!"); // TODO remove
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CoffeeFly>())
        {
            coffeeLevel = maxCoffeeLevel;
            animator.SetBool("isAngry", false);
            animator.SetTrigger("Hit");
        }
    }
}
