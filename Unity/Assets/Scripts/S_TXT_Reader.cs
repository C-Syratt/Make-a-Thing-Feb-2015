using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class S_TXT_Reader : MonoBehaviour 
{
	static public S_TXT_Reader inst;
	
	public TextAsset text1;
	public TextAsset text2;
	
	private List<string> namesFirst = new List<string>();
	private List<string> namesLast = new List<string>();

	// Use this for initialization
	void Awake() 
	{
		// static instance
		inst = this;
		
		// occupy name lists
		GenNames(text1, namesFirst);
		GenNames(text2, namesLast);
	}
	
	// return a random name string
	public string NewName()
	{
		Shuffle(namesFirst);
		Shuffle(namesLast);
		return namesFirst[0] + " " + namesLast[0];
	}
	
	// deserializes the txt to a list of strings
	public void GenNames(TextAsset txt, List<string> nList)
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