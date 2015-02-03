using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoffeeCart : MonoBehaviour {

	[SerializeField] float maxDistance = 5f;
	int[] roomID;
	[SerializeField] GameObject player;
	[SerializeField] Canvas notepadCanvas;

	void Start()
	{
		roomID = new int[5];
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
