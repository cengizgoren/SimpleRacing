using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PathOfCar : MonoBehaviour {

	public GameObject LPath;
	public GameObject MPath;
	public GameObject RPath;
	
	private int path;

	private GameObject _target;
	private Rigidbody rb;
	private void Start()
	{
		rb = GetComponent<Rigidbody>();
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

	private void TurnTheCar()
	{
		
	}
	
}
