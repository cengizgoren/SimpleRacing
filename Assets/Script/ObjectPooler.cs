using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {


	#region Singleton

	public static ObjectPooler instance;

	private void Awake()
	{
		if (instance != this && instance != null)
		{
			Destroy(this.gameObject);
		}
		else
		{
			instance = this;
		}
	}

	#endregion	

	[Serializable] public class Pools
	{
		public string tag;
		public GameObject prefab;
		public int size;
	}
	
	public List<Pools> pools;
	private Dictionary<string, Queue<GameObject>> _poolDictionary;

	private void Start()
	{
		_poolDictionary = new Dictionary<string, Queue<GameObject>>();
		foreach (var pool in pools)
		{
			Queue<GameObject> poolQueue = new Queue<GameObject>();
			for (int i = 0; i < pool.size; i++)
			{
				var obj = Instantiate(pool.prefab);
				poolQueue.Enqueue(obj);
			}
			print(pool.tag);
			_poolDictionary.Add(pool.tag, poolQueue);
		}
	}

	public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
	{
		if (!_poolDictionary.ContainsKey(tag)) 
			return null;
		var objToSpawn = _poolDictionary[tag].Dequeue();
		objToSpawn.SetActive(true);
		objToSpawn.transform.position = position;
		objToSpawn.transform.rotation = rotation;
		var pooledObj = objToSpawn.GetComponent<IPooledObject>();
		if (pooledObj != null)
		{
			pooledObj.OnObjectSpawn();
		}
		_poolDictionary[tag].Enqueue(objToSpawn);
		return objToSpawn;
	}
	
}
