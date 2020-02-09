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
    [SerializeField] GameObject coffeeSound;
    public bool isDecaffeinated = false;

    private void Start()
    {
        StartCoroutine(loseCoffee());
    }

    private IEnumerator loseCoffee()
    {
        while (coffeeLevel > float.Epsilon)
        {
            coffeeLevel -= lossAmount;
            if (coffeeLevel < maxCoffeeLevel * angerThreshold)
            {
                animator.SetBool("isAngry", true);
            }
            yield return new WaitForSeconds(lossRate);
        }
        isDecaffeinated = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CoffeeFly>())
        {
            Instantiate(coffeeSound, transform.position, Quaternion.identity);
            coffeeLevel = maxCoffeeLevel;
            animator.SetBool("isAngry", false);
            animator.SetTrigger("Hit");
            StartCoroutine(disableEmployeeWalk());
        }
    }

    private IEnumerator disableEmployeeWalk()
    {
        GetComponent<EmployeeWalk>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        GetComponent<EmployeeWalk>().enabled = true;
    }

    
}
