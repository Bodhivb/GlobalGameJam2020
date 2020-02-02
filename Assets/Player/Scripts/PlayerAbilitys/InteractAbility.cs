using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractAbility : Ability, IPlayerAbilitys
{
    private PlayerController _playerController;
    private PickUpAbility _pickUpAbility;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite xboxA;
    [SerializeField] Sprite xboxAR;
    [SerializeField] Sprite playA;
    [SerializeField] Sprite playAR;
    [SerializeField] Sprite pcE;
    [SerializeField] Sprite pcER;

    StunAbility stunAbility;
    IInteractible inter;
    IInteractible pickUp;
    DefectiveObject defect;
    bool playstation;
    bool redPicture;
    int frames = 0;
    [SerializeField] Item water;

    public override void OnStart()
    {
        _playerController = GetComponent<PlayerController>();
        _pickUpAbility = GetComponent<PickUpAbility>();
        spriteRenderer.enabled = false;
        if (Input.GetJoystickNames().Length >= _playerController.player)
        {
            Debug.Log(Input.GetJoystickNames()[_playerController.player - 1]);
            playstation = "Sony Computer Entertainment Wireless Controller" == Input.GetJoystickNames()[_playerController.player - 1];
            if (!playstation)
                playstation = "Wireless Controller" == Input.GetJoystickNames()[_playerController.player - 1];

            if (playstation)
            {
                Debug.Log("playstation control");
                spriteRenderer.sprite = playA;
            }
            else
            {
                Debug.Log("xbox control");
                spriteRenderer.sprite = xboxA;
            }
        } else
        {
            Debug.Log("pc control");
            spriteRenderer.sprite = pcE;
        }
    }

    public override void EveryFrame()
    {
        if (AbilityPermitted)
        {
            if (spriteRenderer.enabled)
            {
                if (frames > 30)
                {
                    frames = 0;
                    if (redPicture)
                    {
                        redPicture = false;
                        if (spriteRenderer.sprite.name.ToString() == xboxAR.name.ToString())
                        {
                            spriteRenderer.sprite = xboxA;
                        }
                        else if (spriteRenderer.sprite.name.ToString() == playAR.name.ToString())
                        {
                            spriteRenderer.sprite = playA;
                        }
                        else if (spriteRenderer.sprite.name.ToString() == pcER.name.ToString())
                        {
                            spriteRenderer.sprite = pcE;
                        }
                    }
                    else
                    {
                        redPicture = true;

                        if (spriteRenderer.sprite.name.ToString() == xboxA.name.ToString())
                        {
                            spriteRenderer.sprite = xboxAR;
                        }
                        else if (spriteRenderer.sprite.name.ToString() == playA.name.ToString())
                        {
                            spriteRenderer.sprite = playAR;
                        }
                        else if (spriteRenderer.sprite.name.ToString() == pcE.name.ToString())
                        {
                            spriteRenderer.sprite = pcER;
                        }
                    }
                }
                frames++;
            }

            if (playstation)
            {
                if (Input.GetButtonDown("Player" + _playerController.player.ToString() + "IntersectP"))
                {
                    BeforeAbility();
                }
            }
            else
            {
                if (Input.GetButtonDown("Player" + _playerController.player.ToString() + "Intersect"))
                {
                    BeforeAbility();
                }
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
                    defect.Repair(_pickUpAbility.pickUpItem.item, _playerController.player);
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
            pickUp = null;
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
            if (defect.objectHealth == DefectiveObject.ObjectHealth.defect)
            {
               if (_pickUpAbility.pickUpItem != null && _pickUpAbility.pickUpItem.item == defect.repairItem) {
                    spriteRenderer.enabled = true;
                }
            }
        }

        if (c.CompareTag("Interactable"))
        {
            if (_pickUpAbility.pickUpItem != null && _pickUpAbility.pickUpItem.item == water)
                spriteRenderer.enabled = true;

            inter = c.GetComponent<IInteractible>();
        }
        if (c.CompareTag("PickUp"))
        {
            if (pickUp == null && !_pickUpAbility.hasItem)
                spriteRenderer.enabled = true;

            pickUp = c.GetComponent<IInteractible>();
        }
        if (c.CompareTag("Player"))
        {
            if (c.transform != this.transform)
            {
                spriteRenderer.enabled = true;
                stunAbility = c.GetComponent<StunAbility>();
            }
        }
    }

    void OnTriggerStay(Collider c)
    {
        if (c.CompareTag("Interactable") && inter == null)
        {
            spriteRenderer.enabled = true;
            inter = c.GetComponent<IInteractible>();
        }
    }
    void OnTriggerExit(Collider c)
    {
        if (c.CompareTag("Defect"))
        {
            if (defect != null)
            {
                spriteRenderer.enabled = false;
                defect.CanceldRepair();
                defect = null;
            }
        }
        if (c.CompareTag("Interactable"))
        {
            if (inter == c.GetComponent<IInteractible>())
            {
                spriteRenderer.enabled = false;
                inter = null;
            }
        }
        if (c.CompareTag("PickUp"))
        {
            spriteRenderer.enabled = false;
            pickUp = null;
        }
        if (c.CompareTag("Player"))
        {
            spriteRenderer.enabled = false;
            stunAbility = null;
        }
    }
}