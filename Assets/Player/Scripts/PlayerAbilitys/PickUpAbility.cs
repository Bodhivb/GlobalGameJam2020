using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAbility : Ability, IPlayerAbilitys
{
    private PlayerController _playerController;

    [SerializeField]
    Transform objectPos;
    public PickUpItem pickUpItem;
    public bool hasItem = false;
    public PickUpItem.ItemType hasItemType;
    bool playstation;
    public override void OnStart()
    {
        _playerController = GetComponent<PlayerController>();

        playstation = "Wireless Controller" == Input.GetJoystickNames()[_playerController.player - 1];
    }

    public override void EveryFrame()
    {
        if (AbilityPermitted)
        {
            if (playstation)
            {
                if (Input.GetButtonDown("Player" + _playerController.player.ToString() + "DropP"))
                {
                    DropItem();
                }
            }
            else
            {
                if (Input.GetButtonDown("Player" + _playerController.player.ToString() + "Drop"))
                {
                    DropItem();
                }
            }
        }
    }
    public void PickUpItem(PickUpItem item)
    {
        if (AbilityPermitted && !hasItem)
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if (rb != null)
                Destroy(rb);
            pickUpItem = item;
            hasItem = true;
            item.transform.parent = objectPos;
            item.transform.position = objectPos.position;
            hasItemType = item.itemType;
        }
    }
    public void DropItem()
    {
        if (hasItem)
        {
            hasItem = false;
            pickUpItem.transform.parent = null;
            Rigidbody rb = pickUpItem.gameObject.AddComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            pickUpItem.transform.rotation = Quaternion.identity;
            pickUpItem = null;
        }
    }
    public void DestroyItem()
    {
        if (hasItem)
        {
            hasItem = false;
            if (pickUpItem != null)
            {
                pickUpItem.transform.parent = null;
                Destroy(pickUpItem.gameObject);
            }
            pickUpItem = null;
        }
    }
    public override void BeforeAbility()
    {

    }

    public override void WhileAbility()
    {

    }

    public override void AfterAbility()
    {

    }
}