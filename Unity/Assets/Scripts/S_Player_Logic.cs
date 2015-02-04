using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class S_Player_Logic : MonoBehaviour 
{
	public float armReach = 2.0f;
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
		if (Physics.SphereCast(p1, charCtrl.height / 2, cam.forward, out hit, armReach))
			float distanceToObstacle = hit.distance;

	}

	// attempts to deliver coffee based on hand
	public void DeliverCoffee(bool left)
	{
		// check if in range of AI/Door
		if(inRange)
		{
			// check which hand is trying
			if(left)
			{
				// has the hand got a coffee
				if(leftHand != null)
				{
					
				}
			}
			else
			{
				
			}
		}
	}

	void OnTriggerEnter(Collider otherObj)
	{
		if(otherObj.tag == "Door" || otherObj.tag == "AI")
		{
			inRange = true;
			inRangeEmployee = otherObj.GetComponent<C_Employee>();
		}
	}

	void OnTriggerExit(Collider otherObj)
	{
		if(otherObj.tag == "Door" || otherObj.tag == "AI")
		{
			inRange = false;
			inRangeEmployee = null;
		}
	}
}
