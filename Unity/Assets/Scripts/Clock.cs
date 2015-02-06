using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {

	public GameObject minuteHand;
	public GameObject hourHand;

	void Update () {
		minuteHand.transform.Rotate(new Vector3(0f, 0f, (360f / 60f) * -Time.deltaTime));
		hourHand.transform.Rotate(new Vector3(0f, 0f, (360f / 60f / 12f / 2f) * -Time.deltaTime));
	}
}
