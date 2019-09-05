using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarSetter : MonoBehaviour {

	void Start ()
	{
		var CarInstance = Instantiate(ModelOfCar.ActualCar, transform.position, Quaternion.identity);
		CarInstance.transform.parent = gameObject.transform;
		CarInstance.AddComponent<PathOfCar>();
	}
	
}
