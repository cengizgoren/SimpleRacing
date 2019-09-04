using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterOfStart : MonoBehaviour
{
	void Start ()
	{
		CarDriveForwardBehaviour.isDrive = false;
	}

	public void StartDrive()
	{
		CarDriveForwardBehaviour.isDrive = true;
	}

	public void SetValueOfCountDown(string displayedValue)
	{
		GetComponent<TextMeshProUGUI>().text = displayedValue;
	}
}
