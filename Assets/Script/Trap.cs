using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour,IPooledObject
{
	private GameObject _player;
	internal static int firstPositionAfterStart = 150;
	private GameObject GameOverText;
	private GameObject FadeScreen;

	private void Awake()
	{
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag(MyTag.Player.ToString()))
		{
			GameController.isGameOver = true;
		}
	}

	private void Start()
	{
		_player = GameObject.FindGameObjectWithTag(MyTag.Player.ToString());
		ObjectPooler.instance.SpawnFromPool(MyTag.Trap.ToString(), 
			new Vector3(RandomNumOnRoad.PositionOnRoad(-6,2,6),0f,transform.position.z + firstPositionAfterStart),Quaternion.identity);
		firstPositionAfterStart += 100;

	}

	private void Update()
	{
		if (transform.position.z < _player.transform.position.z-30)
		{
			ObjectPooler.instance.SpawnFromPool(MyTag.Trap.ToString(), 
				new Vector3(RandomNumOnRoad.PositionOnRoad(-6,2,6),0f,transform.position.z + 1000),Quaternion.identity);
		}
	}

	public void OnObjectSpawn()
	{
		
	}
}
