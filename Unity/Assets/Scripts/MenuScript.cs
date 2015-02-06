using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public GameObject camera;
	public GameObject featureObject;
	//sdfuagsdkfuSGf

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Rotate the coffee Mug/s
		featureObject.transform.Rotate (0.02f, 0.3f, 0.03f);
		camera.transform.RotateAround (featureObject.transform.position, new Vector3(0,0.01f,0), 0.01f);
	}

	public void PlayGame()
	{
		Application.LoadLevel (1);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
