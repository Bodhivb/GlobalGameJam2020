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
	public bool stunned { get; private set; }
	public Ability[] abilities;
	Rigidbody rb;
	public override void OnStart()
	{
		stunned = false;
		reviveCollider.enabled = false;
		_playerController = GetComponent<PlayerController>();
		rb = GetComponent<Rigidbody>();

	}

	public void Stun()
	{
		if (!stunned)
		{
			_playerController.animator.SetBool("Die", true);
			if (_playerController == null)
				_playerController = GetComponent<PlayerController>();
			rb.constraints = RigidbodyConstraints.FreezeAll;
			stunned = true;
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
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
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

