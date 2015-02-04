using UnityEngine;
using System.Collections;

public class GUIFollowObject : MonoBehaviour {

	public GameObject target;
	public float offsetX;
	public float offsetY;
	public float offsetZ;

	Vector3 newPos = new Vector3(0,0);

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		SetNewPos ();
		transform.position = newPos;
	}

	void SetNewPos()
	{
		newPos =  new Vector3 ( (target.transform.position.x + offsetX) , (target.transform.position.y + offsetY) , (target.transform.position.z + offsetZ) );
	}
}
