using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OrderButton : MonoBehaviour {

	public enum Hand
	{
		LEFT,
		RIGHT
	}

	public CoffeeCart coffeeCart;
	public int orderIndex;

	// Use this for initialization
	void Start () 
	{
		coffeeCart = GameObject.FindWithTag ("CoffeeCart").GetComponent<CoffeeCart> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//coffeeCart.orderText[orderIndex].ToString();
	}

	public void LeftClick()
	{
		coffeeCart.SelectOrder (CoffeeCart.Hand.LEFT, orderIndex);
	}

	public void RightClick()
	{
		coffeeCart.SelectOrder (CoffeeCart.Hand.RIGHT, orderIndex);
	}
}
