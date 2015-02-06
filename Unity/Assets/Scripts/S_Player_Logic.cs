using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class S_Player_Logic : MonoBehaviour 
{
	public float armReach = 2.0f;
	public float armWidth = 1.0f;
	public Coffee leftCoffee = null;
	public Coffee rightCoffee = null;
	public C_Employee leftHand = null;
	public C_Employee rightHand = null;

	private bool inRange = false;
	private C_Employee inRangeEmployee = null;

	public List<GameObject> startingPoints;

	public GameObject coffeeCart;

	// Use this for initialization
	void Start () 
	{
		transform.position = startingPoints [Random.Range (0, startingPoints.Count)].transform.position;
		coffeeCart.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
		{
			RaycastHit hit;
			CharacterController charCtrl = GetComponent<CharacterController> ();
			Transform cam = Camera.main.transform;
			if (Physics.SphereCast (cam.position, armWidth, cam.forward, out hit, armReach)) {
				// true if on range of drop off point
				if (hit.collider.tag == "Door" || hit.collider.tag == "AI") {
					//which hand
					if (Input.GetButtonDown ("Fire1")) {
						// check for coffee
						if (leftHand != null) {
							//check temp is not too cold
							// too cold - deliver coffee receive bad response
							// all good - tally score and receive pos response
							// leftHand = null;
							// coffee cart newOrder();
						} else {
							// play error sound
						}
					} else if (Input.GetButtonDown ("Fire1")) {
						// check for coffee
						if (rightHand != null) {
							//check temp is not too cold
							// too cold - deliver coffee receive bad response
							// all good - tally score and receive pos response
							// leftHand = null;
							// coffee cart newOrder();
						} else {
							// play error sound
						}
					}
				}
			}
		}
	}// end Update

	void CheckCoffee(Coffee cof, C_Employee hand, C_Employee employee)
	{
		//Checks if it is the right person to give coffee
		if(hand.firstName == employee.firstName && hand.lastName == employee.lastName)
		{
			if(cof.temp == HeatEnum.COLD)
			{
				//Play "Cold Coffee" sound
				employee.PlaySound(C_Employee.SoundEnum.COLD);

			}else if(cof.temp == HeatEnum.WARM)
			{
				//Play "Hot Coffee" sound
				employee.PlaySound(C_Employee.SoundEnum.WARM);
			}
			else if(cof.temp == HeatEnum.HOT)
			{
				//Play "Warm Coffee" sound
				employee.PlaySound(C_Employee.SoundEnum.HOT);
			}
		}
		else //Play "Not my coffee" voice
		{
			employee.PlaySound(C_Employee.SoundEnum.NOTMINE);
		}

	}
}
