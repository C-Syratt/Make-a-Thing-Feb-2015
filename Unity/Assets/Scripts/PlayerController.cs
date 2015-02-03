using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField] Transform leftHand;
	[SerializeField] Transform rightHand;
	[SerializeField] GameObject coffeePrefab;

	void Start () {
		GameObject g1 = (GameObject) Instantiate (coffeePrefab, leftHand.position, Quaternion.identity);
		g1.transform.parent = leftHand;
		GameObject g2 = (GameObject) Instantiate (coffeePrefab, rightHand.position, Quaternion.identity);
		g2.transform.parent = rightHand;
	}

	void Update () {
		
	}
}
