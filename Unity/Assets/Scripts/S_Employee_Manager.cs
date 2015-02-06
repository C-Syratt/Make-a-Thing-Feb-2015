using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class S_Employee_Manager : MonoBehaviour 
{
	static public S_Employee_Manager inst;
	
	public List<C_Employee> employeeList = new List<C_Employee>();

	
	void Awake()
	{
		inst = this;

	}

	// Use this for initialization
	void Start () 
	{
		AssignDoors();
	}

	// sets data for all doors in list
	public void AssignDoors()
	{
		Debug.Log (employeeList.Count);
		for(int i = 0; i < employeeList.Count; i++)
		{
			string tempF = null;
			string tempL = null;
			bool nameFound = false;
			while(!nameFound)
			{
				tempF = S_TXT_Reader.inst.NewFirstName();
				tempL = S_TXT_Reader.inst.NewLastName();

				int matches = 0;
				for(int j = 0; j < employeeList.Count; j++)
				{
					if(employeeList[j].firstName == tempF && employeeList[j].lastName == tempL)
						matches++;
				}

				if(matches == 0)
					nameFound = true;
			}

			string tempC = S_TXT_Reader.inst.GetCoffee(tempF);
			employeeList[i].SetData(tempF, tempL, tempC);
		}

		CoffeeCart.inst.SetUp();

	}
}