using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class S_Player_Logic : MonoBehaviour 
{
	public float armReach = 2.0f;
	public float armWidth = 1.0f;
	public C_Employee leftHand = null;
	public C_Employee rightHand = null;

	private bool inRange = false;
	private C_Employee inRangeEmployee = null;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		RaycastHit hit;
		CharacterController charCtrl = GetComponent<CharacterController>();
		Transform cam = Camera.main.transform;
		if (Physics.SphereCast(cam.position, armWidth, cam.forward, out hit, armReach))
		{
			// true if on range of drop off point
			if(hit.collider.tag == "Door" || hit.collider.tag == "AI")
			{
				//which hand
				if(Input.GetButtonDown("Fire1"))
				{
					// check for coffee
					if(leftHand != null)
					{
						//check temp is not too cold
						// too cold - deliver coffee receive bad response
						// all good - tally score and receive pos response
						// leftHand = null;
						// coffee cart newOrder();
					}
					else
					{
						// play error sound
					}
				}
				else if(Input.GetButtonDown("Fire1"))
				{
					// check for coffee
					if(rightHand != null)
					{
						//check temp is not too cold
						// too cold - deliver coffee receive bad response
						// all good - tally score and receive pos response
						// leftHand = null;
						// coffee cart newOrder();
					}
					else
					{
						// play error sound
					}
				}
			}
		}

	}
}
