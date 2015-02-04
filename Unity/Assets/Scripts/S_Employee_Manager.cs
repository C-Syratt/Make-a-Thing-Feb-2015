using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class S_Employee_Manager : MonoBehaviour 
{
	static public S_Employee_Manager inst;

	void Awake()
	{
		inst = this;
	}

	public List<C_Employee> employeeList = new List<C_Employee>();

	// Use this for initialization
	void Start () 
	{
		AssignDoors();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void AssignDoors()
	{
		for(int i = 0; i < employeeList.Count; i++)
		{
			print ("Looped");
			string tempF = S_TXT_Reader.inst.NewFirstName();
			string tempL = S_TXT_Reader.inst.NewLastName();
			string tempC = S_TXT_Reader.inst.GetCoffee(tempF);
			employeeList[i].SetData(tempF, tempL, tempC);
		}
	}
}
