using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractAbility : Ability, IPlayerAbilitys
{
    private PlayerController _playerController;
    IInteractible inter;
    public override void OnStart()
    {
        _playerController = GetComponent<PlayerController>();
    }

    public override void EveryFrame()
    {
        if (AbilityPermitted)
        {
            if (Input.GetButtonDown("Player" + _playerController.player.ToString() + "Intersect")) 
            {
                BeforeAbility();
            }
        }
    }

    public override void BeforeAbility()
    {
        WhileAbility();
    }

    public override void WhileAbility()
    {
        if (inter != null)
        {
            inter.Interact();
        }
        AfterAbility();
    }

    public override void AfterAbility()
    {

    }

    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Interactable"))
        {
            inter = c.GetComponent<IInteractible>();
        }
    }
    void OnTriggerExit(Collider c)
    {
        if (c.CompareTag("Interactable"))
        {
            inter = null;
        }
    }
}