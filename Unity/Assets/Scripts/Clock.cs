using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {

	public GameObject minuteHand;
	public GameObject hourHand;

	void Update () {
		print ((360f / 60f / 12f / 2f) * Time.deltaTime);
		minuteHand.transform.Rotate(new Vector3(0f, 0f, (360f / 60f) * -Time.deltaTime));
		hourHand.transform.Rotate(new Vector3(0f, 0f, (360f / 60f / 12f / 2f) * -Time.deltaTime));
	}
}
