using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAbility : Ability , IPlayerAbilitys {

	private PlayerController _playerController;
	Rigidbody rb;
	public float jumpForce;

	public override void OnStart(){
		_playerController = GetComponent<PlayerController> ();
		rb = GetComponent<Rigidbody> ();
	}

	public override void EveryFrame(){
		if (AbilityPermitted)
		{
			if (InputManager.Instance.jumpButton && _playerController.grounded)
			{
				BeforeAbility ();
			}
		}
	}

	public override void BeforeAbility(){
		WhileAbility ();
	}

	public override void WhileAbility(){
		rb.AddForce (new Vector3 (0, jumpForce, 0));
		AfterAbility ();
	}

	public override void AfterAbility(){
		
	}
}
