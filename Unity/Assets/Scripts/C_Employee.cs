using UnityEngine;
using System.Collections;

public class C_Employee : MonoBehaviour 
{

	public enum SoundEnum
	{
		HOT,
		WARM,
		COLD,
		NOTMINE
	}
	public string firstName;
	public string lastName;
	public int roomNum;
	public string coffee;
	public bool isPerson = false;
	public GameObject person = null;

	void Start()
	{
		if(!isPerson)
		{
			S_Employee_Manager.inst.employeeList.Add(this);
		}
	}

	public void SetPersonData()
	{
		C_Employee tempE = person.GetComponent<C_Employee>();
		tempE.name = name;
		tempE.roomNum = roomNum;
		tempE.coffee = coffee;
		tempE.isPerson = true;
	}

	public void SetData(string first, string last, string coff)
	{
		firstName = first;
		lastName = last;
		coffee = coff;

		if(person != null)
			SetPersonData();
	}

	public void PlaySound(SoundEnum sound)
	{
		switch(sound)
		{
		case SoundEnum.COLD:
			break;
		case SoundEnum.WARM:
			break;
		case SoundEnum.HOT:
			break;
		case SoundEnum.NOTMINE:
			break;
		default:
			Debug.LogError("Incorrect Sound");
			break;
		}
	}
}
