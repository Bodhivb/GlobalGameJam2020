using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAbility : Ability, IPlayerAbilitys
{
    private PlayerController _playerController;

    [SerializeField]
    Transform objectPos;
    [SerializeField]
    Transform objectPosM;
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
            PickUpItem rb = item.GetComponent<PickUpItem>();
            if (rb != null)
                rb.pickedUp = true;
            pickUpItem = item;
            pickUpItem.transform.rotation = Quaternion.identity;
            pickUpItem.transform.eulerAngles = -pickUpItem.transform.right * 90;
            hasItem = true;
            if (item.name == "Bucket")
            {
                item.transform.parent = objectPos;
                item.transform.position = objectPos.position;
            }
            else
            {
                item.transform.parent = objectPosM;
                if (item.name == "Mop")
                {
                    item.transform.localPosition = new Vector3(0.165f, -1.15f, -0.09f);
                    item.transform.localEulerAngles = new Vector3(-79.45f, -2.135f, 9.7f);
                }
                else
                {
                    item.transform.position = objectPosM.position;
                }
            }
            hasItemType = item.itemType;
        }
    }
    public void DropItem()
    {
        if (hasItem)
        {
            PickUpItem rb = pickUpItem.GetComponent<PickUpItem>();
            pickUpItem.transform.parent = null;
            if (rb != null)
            {
                rb.pickedUp = false;
                pickUpItem.transform.rotation = Quaternion.identity;
                pickUpItem.transform.eulerAngles = -pickUpItem.transform.right * 90;
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