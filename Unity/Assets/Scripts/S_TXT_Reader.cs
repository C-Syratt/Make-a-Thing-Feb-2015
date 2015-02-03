using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// employee
public class Employee
{
	public string name = null;
	public string coffee = null;
	public int roomNum = 0;
}

public class S_TXT_Reader : MonoBehaviour 
{

	static public S_TXT_Reader inst;

	public TextAsset txtFirst;
	public TextAsset txtLast;
	public TextAsset txtCoffee;
	
	private List<string> namesFirst = new List<string>();
	private List<string> namesLast = new List<string>();
	private List<string> namesCoffee = new List<string>();

	// Use this for initialization
	void Awake() 
	{
		// static instance
		inst = this;
		
		// occupy name lists
		GenNames(txtFirst, namesFirst);
		GenNames(txtLast, namesLast);
		GenNames(txtCoffee, namesCoffee);
	}

	public Employee NewEmployee()
	{
		Employee tempE = new Employee();
		tempE.name = NewName();

		return tempE;
	}

	// return a random name string
	private string NewName()
	{
		Shuffle(namesFirst);
		Shuffle(namesLast);
		return namesFirst[0] + " " + namesLast[0];
	}

	// returns the first char of each word in "B.T." format
	public string GetInitials(string text)
	{
		string initials = null;
		string[] words = text.Split (' ');
		foreach(string s in words)
		{
			char[] temp = s.ToCharArray();
			initials += temp[0].ToString() + ".";
		}

		return initials;
	}
	
	// deserializes the txt to a list of strings
	private void GenNames(TextAsset txt, List<string> nList)
	{
		string[] lines = txt.text.Split('\n');
		foreach(string s in lines)
		{
			nList.Add(s);
		}
	}
	
	// Fischer Yates shuffle
	private void Shuffle(List<string> list)
	{
		for(int i = list.Count - 1; i > 0; i--)
		{
			string temp;
			int ranNum = Random.Range(0, i - 1);
			
			temp = list[i];
			list[i] = list[ranNum];
			list[ranNum] = temp;
		}
	}
}