using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAbility : Ability, IPlayerAbilitys
{
    private PlayerController _playerController;
    public float speed = 1;
    [SerializeField]
    Transform playerModel;
    public AudioSource walkSound;
    public AudioClip[] steps;
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
            {
                _playerController.animator.SetBool("Walking", true);
                if (!walkSound.isPlaying)
                {
                    walkSound.clip = steps[Random.Range(0, steps.Length)];
                    walkSound.Play();
                }
                playerModel.rotation = Quaternion.LookRotation(movement);
            }
            else
            {
                _playerController.animator.SetBool("Walking", false);
                walkSound.Pause();
            }

            if (!_playerController.canWalkForward && z > 0)
                movement.z = 0;
            if (!_playerController.canWalkBack && z < 0)
                movement.z = 0;
            if (!_playerController.canWalkRight && x > 0)
                movement.x = 0;
            if (!_playerController.canWalkLeft && x < 0)
                movement.x = 0;

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

