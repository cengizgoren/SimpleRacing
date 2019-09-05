using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PathOfCar : MonoBehaviour {

	private GameObject LPath;
	private GameObject MPath;
	private GameObject RPath;
	
	private int path;

	private GameObject _target;
	private void Start()
	{
		LPath = GameObject.FindGameObjectWithTag(MyTag.LPath.ToString());	
		RPath = GameObject.FindGameObjectWithTag(MyTag.RPath.ToString());	
		MPath = GameObject.FindGameObjectWithTag(MyTag.MPath.ToString());	
		path = 2;
		_target = MPath;
	}

	void Update ()
	{

		if (!CarDriveForwardBehaviour.isDrive) return;
		if (Input.GetKeyDown(KeyCode.A))
		{
			if (path == 3)
			{
				_target = MPath;
				path = 2;
			}
			else if (path == 2)
			{
				_target = LPath;
				path = 1;
			}
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			if (path == 1)
			{
				_target = MPath;
				path = 2;

			}
			else if (path == 2)
			{
				_target = RPath;
				path = 3;
			}
		}
		
		transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, 30*Time.deltaTime);
		


	}

	
}
