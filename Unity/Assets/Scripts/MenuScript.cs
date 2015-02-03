using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public GameObject featureObject;
	//sdfuagsdkfuSGf

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		featureObject.transform.Rotate (2.0f, 1f, 4f);
	}
}
