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
        if (Input.GetJoystickNames().Length >= _playerController.player)
        {
            playstation = "Sony Computer Entertainment Wireless Controller" == Input.GetJoystickNames()[_playerController.player - 1];
            if (!playstation)
                playstation = "Wireless Controller" == Input.GetJoystickNames()[_playerController.player - 1];
        }
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
        if (item == null)
            return;
        if (hasItem && pickUpItem == null)
            hasItem = false;
        if (AbilityPermitted && !hasItem)
        {
            Bucket rb = item.GetComponent<Bucket>();
            if (rb != null)
                rb.dropped = false;
            pickUpItem = item;
            pickUpItem.transform.rotation = Quaternion.identity;
            pickUpItem.transform.eulerAngles = -pickUpItem.transform.right * 90;
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
            Bucket rb = pickUpItem.GetComponent<Bucket>();
            pickUpItem.transform.parent = null;
            if (rb != null)
            {
                rb.dropped = true;
                pickUpItem.transform.rotation = Quaternion.identity;
                pickUpItem.transform.eulerAngles = -pickUpItem.transform.right*90;
            }
            pickUpItem = null;
            hasItem = false;
        }
    }
    public void DestroyItem()
    {
        if (hasItem)
        {
            if (pickUpItem != null)
            {
                pickUpItem.transform.parent = null;
                Destroy(pickUpItem.gameObject);
            }
            pickUpItem = null;
            hasItem = false;
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