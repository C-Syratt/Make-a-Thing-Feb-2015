using UnityEngine;
using System.Collections;

public class Coffee : MonoBehaviour {
	
	[SerializeField] float deliveryTimeSeconds = 300f;
	float counter = 0f;
	[SerializeField] int percentageWarm = 100;
	[SerializeField] HeatEnum temp = HeatEnum.HOT;

	void Update () {
		counter += Time.deltaTime;
		percentageWarm = (int) (100 - (counter / deliveryTimeSeconds * 100f));
		if(percentageWarm <= 20)
		{
			temp = HeatEnum.COLD;
		}
		else if(percentageWarm <= 60)
		{
			temp = HeatEnum.WARM;
		}
		else
		{
			temp = HeatEnum.HOT;
		}
	}
}
