using UnityEngine;
using System.Collections;

public class HotColdCoffee : MonoBehaviour {

	private Material _mat;
	private float temperature;
	
	void Start () {
		//sets the material to the HealthBar material
		_mat = this.renderer.material;
		//		_mat = renderer.material.shader;
		//
		
		//		health = 0f;
		
	}
	
	void Update () {
		//health in the GameDirector is always positive, so I need to -5 to get it into the range of the shader (-5 to +5)
		temperature = (Coffee.inst.percentageWarm / 10) - 5f;
		//sets temp to the HealthBarMix and effectively displays the current health
		_mat.SetFloat("_HealthBarMix", temperature );
	}
}

