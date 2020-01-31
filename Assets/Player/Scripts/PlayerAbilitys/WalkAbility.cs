using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAbility : Ability, IPlayerAbilitys
{
    private PlayerController _playerController;
    public float speed = 1;

    public override void OnStart()
    {
        _playerController = GetComponent<PlayerController>();
    }

    public override void EveryFrame()
    {
        float x = Input.GetAxis("Player" + _playerController.player.ToString() + "Horizontal");
        float z = Input.GetAxis("Player" + _playerController.player.ToString() + "Vertical");
        if (AbilityPermitted)
        {
            Vector3 movement = new Vector3(x, 0.0f, z);
            if (x != 0 || z != 0)
                transform.rotation = Quaternion.LookRotation(movement);
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
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

