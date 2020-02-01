﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopAbility : Ability, IPlayerAbilitys
{
    private PlayerController _playerController;


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
            }
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