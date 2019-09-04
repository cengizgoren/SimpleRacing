using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour,IPooledObject
{

	private GameObject _player;
	internal static float firstPositionAfterStart;
	private void Start()
	{
		_player = GameObject.FindGameObjectWithTag(MyTag.Player.ToString());
		ObjectPooler.instance.SpawnFromPool(MyTag.Tree.ToString(), new Vector3(RandomNumOnRoad.PositionOnRoad(-12,0,12),0f,transform.position.z + firstPositionAfterStart),Quaternion.identity);
		firstPositionAfterStart += 20;
	}
	private void Update()
	{
		
		//execute when we miss object
		if (transform.position.z < _player.transform.position.z-30)
		{
			ObjectPooler.instance.SpawnFromPool(MyTag.Tree.ToString(), new Vector3(RandomNumOnRoad.PositionOnRoad(-12,0,12),0f,transform.position.z + 1000),Quaternion.identity);
		}
	}


	public void OnObjectSpawn()
	{
        // behaviour of trees when the are spawned
	}
	
}
	