using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class S_TXT_Reader : MonoBehaviour 
{
	static public S_TXT_Reader inst;

	public TextAsset txtFirst;
	public TextAsset txtLast;
	public TextAsset txtCoffee;
	
	public List<string> namesFirst = new List<string>();
	public List<string> namesLast = new List<string>();
	public List<string> namesCoffee = new List<string>();
	public Dictionary<string, string> coffeeLookUp = new Dictionary<string, string>();

	// Use this for initialization
	void Awake() 
	{
		// static instance
		inst = this;
		
		// occupy name lists
		GenNames(txtFirst, namesFirst);
		GenNames(txtLast, namesLast);
		GenNames(txtCoffee, namesCoffee);

		int j = 0;
		for(int i = 0; i < namesFirst.Count; i++)
		{
			coffeeLookUp.Add(namesFirst[i], namesCoffee[j]);
			j++;

			if(j > namesCoffee.Count - 1)
				j = 0;
		}
	}

	// return a random name string
	public string NewFirstName()
	{
		Shuffle(namesFirst);
		return namesFirst[0];
	}

	public string NewLastName()
	{
		Shuffle(namesLast);
		return namesLast[0];
	}

	public string GetCoffee(string name)
	{
		return coffeeLookUp[name];
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
	public void Shuffle(List<string> list)
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