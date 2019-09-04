using UnityEngine;

public class CarDriveForwardBehaviour : MonoBehaviour
{
	public float speed = 60;
	internal static bool isDrive;
	
	void Update ()
	{
		if (!isDrive) return;
	    transform.position += Vector3.forward*Time.deltaTime*speed;
	    if (Input.GetKey(KeyCode.W))
	    {
		    speed++;
	    }
	    else if (Input.GetKey(KeyCode.S))
	    {
		    speed--;
	    }

	    if (speed > 100)
	    {
		    speed = 100;
	    }else if (speed < 50)
	    {
		    speed = 50;
	    }
	}
	
}
