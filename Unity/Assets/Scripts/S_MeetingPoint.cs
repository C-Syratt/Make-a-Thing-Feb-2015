using UnityEngine;
using System.Collections;

/*
 * Occupy the hangouts array in the inspector.
 * Attach anyone whose destination is the object (only printer and coolers)
 * 
*/

public class S_MeetingPoint : MonoBehaviour 
{
	static public S_MeetingPoint inst;

	[System.Serializable]
	public class MeetPoints
	{
		public GameObject printer;
		public AudioSource aSource;
		public C_Employee[] people;
	}
	
	public AudioClip chatter;
	public MeetPoints[] hangOuts;

	private float detectRadius = 3.0f;

	void Awake()
	{
		inst = this;

		// assign audio clips
		for(int i = 0; i < hangOuts.Length; i++)
		{
			hangOuts[i].aSource.clip = chatter;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		for(int i = 0; i < hangOuts.Length; i++)
		{
			// check to see if needed to stop
			if(hangOuts[i].aSource.isPlaying)
			{
				Check();
			}
		}
	}

	public void Check()
	{
		// check each meetPoint for multiple employees
		for(int i = 0; i < hangOuts.Length; i++)
		{
			int headCount = 0;
			for(int j = 0; j < hangOuts[i].people.Length; j++)
			{
				if(Vector3.Distance(hangOuts[i].people[j].transform.position, hangOuts[i].printer.transform.position) < 2.0f)
				{
					headCount++;
				}
			}
			
			if(headCount > 1)
				hangOuts[i].aSource.audio.Play();
			else
				hangOuts[i].aSource.audio.Pause();
		}
	}
}
