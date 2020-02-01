using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunAbility : Ability, IPlayerAbilitys
{
	private PlayerController _playerController;
	[SerializeField]
	float timeStunned = 1.0f;
	[SerializeField]
	SphereCollider reviveCollider;
	float timer;
	bool stunned = false;
	public Ability[] abilities;
	public override void OnStart()
	{
		reviveCollider.enabled = false;
		_playerController = GetComponent<PlayerController>();
	}

	public void Stun()
	{
		if (!stunned)
		{
			_playerController.animator.SetBool("Die", true);
			if (_playerController == null)
				_playerController = GetComponent<PlayerController>();

			PlayerManager.instance.OnPlayerStarve(_playerController.player);
		}

		reviveCollider.enabled = true;
		timer = timeStunned;
		stunned = true;
		this.gameObject.layer = 8;
		foreach(Ability a in abilities)
		{
			a.AbilityPermitted = false;
		}
	}

	public void UnStun()
	{
		_playerController.animator.SetBool("Die", false);
		this.gameObject.layer = 0;
		reviveCollider.enabled = false;
		stunned = false;
		foreach (Ability a in abilities)
		{
			a.AbilityPermitted = true;
		}
	}
	public override void EveryFrame()
	{
		if (AbilityPermitted)
		{
			
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

