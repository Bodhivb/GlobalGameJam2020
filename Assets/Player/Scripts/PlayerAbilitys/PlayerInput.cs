using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    WalkAbility walkAbility;
    PickUpAbility pickUpAbility;
    InteractAbility interactAbility;
    public bool left, right, up, down;
    private void Start()
    {
        walkAbility = GetComponent<WalkAbility>();
        pickUpAbility = GetComponent<PickUpAbility>();
        interactAbility = GetComponent<InteractAbility>();
    }

    private void Update()
    {
        walkAbility.Walk(left, right, up, down);
    }
    public void HandleInputButtonInput(string input)
    {
        switch (input)
        {
            case "right":
                right = true;
                break;
            case "left":
                left = true;
                break;
            case "up":
                up = true;
                break;
            case "down":
                down = true;
                break;
            case "right-up":
                right = false;
                break;
            case "left-up":
                left = false;
                break;
            case "up-up":
                up = false;
                break;
            case "down-up":
                down = false;
                break;
            case "drop":
                pickUpAbility.DropItem();
                break;
            case "interact":
                interactAbility.BeforeAbility(); 
                break;
        }
    }
}
