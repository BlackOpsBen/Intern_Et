using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Elevator goingUp;
    public Elevator goingDown;
    public GameObject door;
    public GameObject entryPoint;
    public GameObject insidePoint;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void Start()
    {
        if (!goingDown && !goingUp)
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("Elevator_Base_None");
        }
        else if (goingDown && goingUp)
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("Elevator_Base");
        }
        else if (goingDown && !goingUp)
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("Elevator_Base_Down");
        }
        else if (!goingDown && goingUp)
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("Elevator_Base_Up");
        }
    }
}
