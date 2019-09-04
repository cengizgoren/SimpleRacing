using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour,IPooledObject
{
    private GameObject _player;
    internal static float firstPositionAfterStart;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(MyTag.Player.ToString());
        ObjectPooler.instance.SpawnFromPool(MyTag.Road.ToString(), new Vector3(0,0f,firstPositionAfterStart),Quaternion.identity);
        firstPositionAfterStart += 1000;
    }
    private void Update()
    {
        //execute when we miss object
        if (transform.position.z < _player.transform.position.z-505)
        {
            ObjectPooler.instance.SpawnFromPool(MyTag.Road.ToString(), new Vector3(0,0f,transform.position.z + 3000),Quaternion.identity);
        }
    }


    public void OnObjectSpawn()
    {
        
    }
}
