using UnityEngine;
using System.Collections;

public class ArmPosition : MonoBehaviour {

	// Update is called once per frame
	void Update () 
	{
		Transform cam = Camera.main.transform;
		transform.position = cam.transform.position;
		transform.rotation = new Quaternion (transform.rotation.x, cam.rotation.y, transform.rotation.z, transform.rotation.w);
	}
}
