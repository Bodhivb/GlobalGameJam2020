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
    public override void OnStart()
    {
        _playerController = GetComponent<PlayerController>();
    }

    public override void EveryFrame()
    {
        if (AbilityPermitted)
        {
            if (Input.GetButtonDown("Player" + _playerController.player.ToString() + "Drop"))
            {
                DropItem();
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
            pickUpItem.gameObject.AddComponent<Rigidbody>();
            pickUpItem = null;
        }
    }
    public void DestroyItem()
    {
        if (hasItem)
        {
            hasItem = false;
            pickUpItem.transform.parent = null;
            Destroy(pickUpItem.gameObject);
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