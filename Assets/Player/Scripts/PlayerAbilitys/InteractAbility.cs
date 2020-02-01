using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractAbility : Ability, IPlayerAbilitys
{
    private PlayerController _playerController;
    private PickUpAbility _pickUpAbility;

    StunAbility stunAbility;
    IInteractible inter;
    IInteractible pickUp;
    DefectiveObject defect;
    public override void OnStart()
    {
        _playerController = GetComponent<PlayerController>();
        _pickUpAbility = GetComponent<PickUpAbility>();
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
        if (defect != null)
        {
            if (_pickUpAbility.hasItem)
            {
                if (defect.repairItem == _pickUpAbility.pickUpItem.item)
                {
                    defect.Repair(_pickUpAbility.pickUpItem.item);
                    _pickUpAbility.DestroyItem();
                }
            }
        }
        if (!_pickUpAbility.hasItem)
        {
            if (stunAbility != null)
            {
                stunAbility.UnStun();
            }
        }
        if (inter != null)
        {
            inter.Interact();
            inter = null;
        }
        if (pickUp != null)
        {
            pickUp.Interact(this.gameObject);
        }
        AfterAbility();
    }

    public override void AfterAbility()
    {

    }

    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Defect"))
        {
            defect = c.GetComponent<DefectiveObject>();
        }
        if (c.CompareTag("Interactable"))
        {
            inter = c.GetComponent<IInteractible>();
        }
        if (c.CompareTag("PickUp"))
        {
            pickUp = c.GetComponent<IInteractible>();
        }
        if (c.CompareTag("Player"))
        {
            if (c.transform != this.transform)
                stunAbility = c.GetComponent<StunAbility>();
        }
    }
    void OnTriggerExit(Collider c)
    {
        if (c.CompareTag("Defect"))
        {
            if (defect != null)
                defect.CanceldRepair();
            defect = null;
        }
        if (c.CompareTag("Interactable"))
        {
            inter = null;
        }
        if (c.CompareTag("PickUp"))
        {
            pickUp = null;
        }
        if (c.CompareTag("Player"))
        {
            stunAbility = null;
        }
    }
}