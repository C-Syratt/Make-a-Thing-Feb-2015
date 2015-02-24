using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CoffeeCart : MonoBehaviour {

	public class CoffeeOrder
	{
		public C_Employee actor;
		public string coffeeInitials;
		public bool delivered = false;
	}

	static public CoffeeCart inst;

	[SerializeField] float maxDistance = 5f;
	//public int[] roomID;
	[SerializeField] GameObject player;
	[SerializeField] Canvas notepadCanvas;

	public List<C_Employee> employeeList = new List<C_Employee> ();
	public Text[] orderText = new Text[5];
	public List<C_Employee> currentOrders = new List<C_Employee>();

	public enum Hand
	{
		LEFT,
		RIGHT
	}

	void Awake()
	{
		inst = this;
	}

	public void SetUp()
	{
		Debug.Log (S_Employee_Manager.inst.employeeList.Count);
		for(int i = 0; i < S_Employee_Manager.inst.employeeList.Count; i++)
		{
			employeeList.Add(S_Employee_Manager.inst.employeeList[i]); 
		}

		ShuffleOrders();
	} 

	public void ShuffleOrders()
	{

		RandomiseEmployeeList (employeeList);

		for(int i = 0; i < 5; i++)
		{
			AddNewOrder();
		}

		UpdateText ();
	}

	public void AddNewOrder()
	{
		currentOrders.Add (employeeList [0]);
		employeeList.RemoveAt (0);
	}

	public void SelectOrder(Hand hand, int orderIndex)
	{
		S_Player_Logic playerLogic = player.GetComponent<S_Player_Logic> ();
		if(hand == Hand.LEFT)
		{
			if(playerLogic.leftCoffee != null)
			{
				print("Left Coffee");
				playerLogic.leftCoffee.employeeData = currentOrders[orderIndex];
				playerLogic.leftCoffee.counter = 0.0f;
			}
			else
			{
				print("Left Coffee else");
				playerLogic.leftCoffee = new Coffee();
				playerLogic.leftCoffee.employeeData = currentOrders[orderIndex];
			}
		}
		else
		{
			if(playerLogic.rightCoffee != null)
			{
				print("Right Coffee");
				playerLogic.rightCoffee.employeeData = currentOrders[orderIndex];
				playerLogic.rightCoffee.counter = 0.0f;
			}
			else
			{
				print("Right Coffee");
				playerLogic.rightCoffee = new Coffee();
				playerLogic.rightCoffee.employeeData = currentOrders[orderIndex];
			}
		}
	}

	public void UpdateText()
	{
		for(int i = 0; i < orderText.Length; i++)
		{
			orderText[i].text = currentOrders[i].firstName + " " + currentOrders[i].lastName + " - " + currentOrders[i].coffee + " - Room " + currentOrders[i].roomNum;
		}
	}

	private void RandomiseEmployeeList(List<C_Employee> list)
	{
		for(int i = list.Count - 1; i > 0; i--)
		{
			C_Employee temp;
			int ranNum = Random.Range(0, i - 1);
			
			temp = list[i];
			list[i] = list[ranNum];
			list[ranNum] = temp;
		}
	}
}
