using UnityEngine;
using System.Collections;

public class ArmPosition : MonoBehaviour {

	public Transform cam;

	// Update is called once per frame
	void Update () 
	{
		transform.position = cam.transform.position;
		transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, cam.rotation.eulerAngles.y, cam.rotation.eulerAngles.z));
	}
}
