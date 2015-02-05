using UnityEngine;
using System.Collections;

public class Coffee : MonoBehaviour {

	public static Coffee inst;
	[SerializeField] float deliveryTimeSeconds = 300f;
	float counter = 0f;
	public int percentageWarm = 100;
	[SerializeField] HeatEnum temp = HeatEnum.HOT;


	void Awake()
	{
		inst = this;
	}

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
