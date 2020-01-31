using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunAbility : Ability, IPlayerAbilitys
{
	private PlayerController _playerController;
	[SerializeField]
	float timeStunned = 1.0f;
	float timer;
	bool stunned = false;
	public Ability[] abilities;
	public override void OnStart()
	{
		_playerController = GetComponent<PlayerController>();
	}

	public void Stun()
	{
		timer = timeStunned;
		stunned = true;
		foreach(Ability a in abilities)
		{
			a.AbilityPermitted = false;
		}
	}
	public override void EveryFrame()
	{
		if (AbilityPermitted)
		{
			if (stunned)
			{
				timer -= Time.deltaTime;
				if(timer <= 0)
				{
					stunned = false;
					foreach (Ability a in abilities)
					{
						a.AbilityPermitted = true;
					}
				}
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

