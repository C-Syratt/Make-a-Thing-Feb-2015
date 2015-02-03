using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class S_AI_Manager : MonoBehaviour 
{
	static public S_AI_Manager inst;

	public float waitTime = 5.0f;

	private List<GameObject> AIRoster;

	void Awake()
	{
		inst = this;
	}

	// Use this for initialization
	void Start () 
	{
		// find all AI and add to list
		GameObject[] temp = GameObject.FindGameObjectsWithTag("AI");
		for(int i = 0; i < temp.Length; i++)
		{
			AIRoster.Add(temp[i]);
		}
	}

	public void DestReached(GameObject ai, string dest)
	{
		// handle conversations / wait times
		if(dest == "WaterCooler" || dest == "Printer")
		{
			S_WayPoint_Movement temp1 = ai.GetComponent<S_WayPoint_Movement>();
			temp1.StopWait(waitTime);

			// compare all other AI
			for(int i = 0; i < AIRoster.Count; i++)
			{
				// check if AI are also near the destination
				if(Vector3.Distance(AIRoster[i].transform.position, ai.transform.position) < 2.0f && ai != AIRoster[i])
				{
					// stop and look at other AI
					S_WayPoint_Movement temp = AIRoster[i].GetComponent<S_WayPoint_Movement>();
					temp.StopWait(waitTime);
					temp.LookAt(ai.transform.position);
					temp1.LookAt(AIRoster[i].transform.position);
					temp1.StopWait(waitTime);
				}
			}
		}
	}

	// Update is called once per frame
	void Update () 
	{
	
	}
}
