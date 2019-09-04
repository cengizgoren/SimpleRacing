using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IPooledObject
{
	internal static float firstPositionAfterStart = -400;
	private GameObject _player;
	private RandomNumOnRoad _randomNumOnRoad;
	int RandomNum;

	private void Awake()
	{
		_randomNumOnRoad = new RandomNumOnRoad();
	}

	private void Start()
	{
		_player = GameObject.FindGameObjectWithTag(MyTag.Player.ToString());
		firstPositionAfterStart += 100;
		ObjectPooler.instance.SpawnFromPool(MyTag.Coin.ToString(),
			new Vector3(RandomNumOnRoad.PositionOnRoad(-6,1,6), 1f, firstPositionAfterStart),
			new Quaternion(1, 0, 0, 1));
	}

	private void OnTriggerEnter(Collider other)
	{
		//execute when we hit the coin
		if (other.gameObject.CompareTag(MyTag.Player.ToString()))
		{
			ObjectPooler.instance.SpawnFromPool(MyTag.Coin.ToString(),
				new Vector3(RandomNumOnRoad.PositionOnRoad(-6,1,6), 1f, transform.position.z + 1000),
				new Quaternion(1, 0, 0, 1));
		CountCoins.CoinAmount++;
		}
	}

	private void Update()
	{
		//execute when we miss object
		if (transform.position.z < _player.transform.position.z - 10)
		{
			ObjectPooler.instance.SpawnFromPool(MyTag.Coin.ToString(),
				new Vector3(RandomNumOnRoad.PositionOnRoad(-6,1,6), 1f, transform.position.z + 1000),
				new Quaternion(1, 0, 0, 1));
		}
	}

	public void OnObjectSpawn()
	{
	}

	
	


}

