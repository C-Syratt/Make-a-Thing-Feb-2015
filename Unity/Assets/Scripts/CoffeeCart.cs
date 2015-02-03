using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoffeeCart : MonoBehaviour {

	[SerializeField] float maxDistance = 5f;
	public int[] roomID;
	[SerializeField] GameObject player;
	[SerializeField] Canvas notepadCanvas;

	void Start()
	{
		roomID = new int[5];
		for(int i = 0; i < roomID.Length; i++)
		{
			bool contains = true;
			while(contains)
			{
				int nextInt = Random.Range(0, 5);
				if(CheckContains(nextInt))
				{
					contains = true;
				}
				else
				{
					roomID[i] = nextInt;
				}
			}
			contains = true;
		}
	}

	bool CheckContains(int a)
	{
		for(int i = 0; i < roomID.Length; i++)
		{
			if(roomID[i] == a)
				return true;
		}
		return false;
	}

	void Update () {
		if(Vector3.Distance(transform.position, player.transform.position) <= maxDistance)
		{
			notepadCanvas.enabled = true;
		}
		else
		{
			notepadCanvas.enabled = false;
		}
	}

	void OptionOne()
	{

	}

	void OptionTwo()
	{

	}

	void OptionThree()
	{

	}

	void OptionFour()
	{

	}

	void OptionFive()
	{

	}
}
