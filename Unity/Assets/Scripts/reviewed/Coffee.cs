using UnityEngine;
using System.Collections;

[System.SerializableAttribute]
public class Coffee {

	public C_Employee employeeData;

	[SerializeField] float deliveryTimeSeconds = 300f;
	public float counter = 0f;
	[SerializeField] int percentageWarm = 100;
	public HeatEnum temp = HeatEnum.HOT;

	public void Update () {
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

		if(percentageWarm < 0)
			percentageWarm = 0;
	}
}
