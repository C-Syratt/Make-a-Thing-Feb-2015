using UnityEngine;
using System.Collections;

public class gotomenu : MonoBehaviour {
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Application.LoadLevel(0);
		}
	}
}
