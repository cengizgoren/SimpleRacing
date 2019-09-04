using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownSystem : MonoBehaviour
{
	public bool isAvailableSpawn;

	private void Start()
	{
		isAvailableSpawn = true;
	}

	public IEnumerator StartCoolDown()
	{
		isAvailableSpawn = false;
		yield return new WaitForSeconds(3f);
		isAvailableSpawn = true;
	}
}
