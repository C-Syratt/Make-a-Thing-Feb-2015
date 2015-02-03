using UnityEngine;
using System.Collections;

public class S_WayPoint_Movement : MonoBehaviour 
{
	public float moveSpeed = 1.0f;
	public GameObject[] waypoints;
	public bool loopedTrack = false;
	public string[] deadEndTags;

	private float turnSpeed, turnBuffer = 1.0f;
	private bool moving = true, backTrack = false;
	private int waypoint = 1;
	private float waitTimer = 0.0f;

	// Use this for initialization
	void Start () 
	{
		// set all wayPoints level to AI's Y-Axis
		for(int i = 0; i < waypoints.Length; i++)
		{
			waypoints[i].transform.position = new Vector3(waypoints[i].transform.position.x, transform.position.y, waypoints[i].transform.position.z);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if(moving)
		{
			transform.localPosition += transform.forward * moveSpeed * Time.deltaTime;
			LookAt(waypoints[waypoint].transform.position);
			turnSpeed = moveSpeed / 2;
		}
		else
		{
			waitTimer -= Time.deltaTime;
			if(waitTimer <= 0.0f)
				moving = true;
		}

		// changes direction just before postion (smooth turn)
		if (Vector3.Distance(waypoints[waypoint].transform.position, transform.position) < turnBuffer) 
		{
			if(backTrack && waypoint == 0)
			{
				if(waypoints[waypoint].tag == "Door")
				{
					// go into room
				}
				else
				backTrack = false;
			}

			// reached the destination
			if(waypoint == waypoints.Length - 1)
			{
				if(!loopedTrack)		// reverse through waypoints
				{
					backTrack = true;
					waypoint--;
				}
				else
					waypoint = 0;		// back at starting pos
			}
			else
			{
				if(backTrack)			// move back through wayPoints
					waypoint--;
				else
					waypoint++;			// move forward through wayPoints
			}
		}
	}

	void OnCollisionEnter(Collision otherObj)
	{
		for(int i = 0; i < deadEndTags.Length; i++)
		{
			if(deadEndTags[i] == otherObj.gameObject.tag)
			{
				print ("tag matched");

				if(backTrack)
				{
					backTrack = false;
					waypoint++;
				}
				else
				{
					backTrack = true;
					waypoint--;
				}
			}
		}
	}

	public void StopWait(float seconds)
	{
		moving = false;
		waitTimer += seconds;
	}

	// slerps towards given vector3
	public void LookAt(Vector3 target)
	{
		Quaternion rotation = Quaternion.LookRotation(target - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
	}
}