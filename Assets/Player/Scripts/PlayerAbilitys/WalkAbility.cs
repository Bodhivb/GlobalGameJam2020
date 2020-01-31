using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAbility : Ability , IPlayerAbilitys {
	private PlayerController _playerController;
	public float speed = 1;

	public override void OnStart(){
		_playerController = GetComponent<PlayerController> ();
	}

	public override void EveryFrame(){
		float x = Input.GetAxis("Player" + _playerController.player.ToString() + "Horizontal");
		float z = Input.GetAxis("Player" + _playerController.player.ToString() + "Vertical");
		if (AbilityPermitted)
		{
			Vector3 forge = new Vector3 (0, 0, 0);
			if (_playerController.canWalkRight && x > 0)
			{
				forge.x += x;
			}
			if (_playerController.canWalkLeft && x < 0)
			{
				forge.x += x;
			}
			if (_playerController.canWalkForward && z > 0)
			{
				forge.z += z;
			}
			if (_playerController.canWalkBack && z < 0)
			{
				forge.z += z;
			}
			transform.Translate (forge * Time.deltaTime * speed);
		}
	}

	public override void BeforeAbility(){

	}

	public override void WhileAbility(){

	}

	public override void AfterAbility(){

	}
}

