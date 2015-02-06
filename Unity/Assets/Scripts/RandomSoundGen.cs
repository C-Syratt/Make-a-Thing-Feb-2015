using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (AudioSource))]

public class RandomSoundGen : MonoBehaviour {


	public List<AudioClip> randomSounds = new List<AudioClip> ();
	//Base time is set at 60 seconds
	public float baseTime = 60.0f;
	//buffpercent is set at 50%
	public float buffPercent = 0.5;
	private float timer = 0.0f;
	private float randomTimeNumber;
	private C_Employee ourDoor;
//	private bool isPlaying = false;
	private AudioSource aSource;

	// Use this for initialization
	void Start () 
	{
		randomTimeNumber = Random.Range(baseTime-(baseTime * buffPercent), baseTime + (baseTime * buffPercent));
		ourDoor = GetComponent<C_Employee>();
		aSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(ourDoor.isOccupied == true && !aSource.isPlaying)
		{
			timer += Time.deltaTime;
			if(timer >= randomTimeNumber)
			{
				aSource.clip = randomSounds[Random.Range(0, randomSounds.Count - 1)];
				aSource.Play();
				timer = 0.0f;
			}
		}
	}
}
