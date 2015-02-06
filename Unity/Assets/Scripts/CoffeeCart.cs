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

	void Awake()
	{
		inst = this;
	}

	public void SetUp()
	{
		for(int i = 0; i < S_Employee_Manager.inst.employeeList.Count; i++)
		{
			employeeList.Add(S_Employee_Manager.inst.employeeList[i]); 
		}

		ShuffleOrders();
	} 

	void Update () {
		if(Vector3.Distance(transform.position, player.transform.position) <= maxDistance)
		{
			//notepadCanvas.enabled = true;
			S_Player_Logic playerComp = player.GetComponent<S_Player_Logic>();
			if(playerComp.leftCoffee == null && currentOrders.Count != 0)
			{
				playerComp.leftCoffee = new Coffee();
				playerComp.leftHand = currentOrders[0];
				currentOrders.RemoveAt(0);
				AddNewOrder();
			}
			if(playerComp.rightCoffee == null && currentOrders.Count != 0)
			{
				playerComp.rightCoffee = new Coffee();
				playerComp.rightHand = currentOrders[0];
				currentOrders.RemoveAt(0);
				AddNewOrder();
			}
		}
		else
		{
			//notepadCanvas.enabled = false;
		}
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

	public void UpdateText()
	{
		//for(int i = 0; i < orderText.Length; i++)
		//{
		//	orderText[i].text = currentOrders[i].firstName + " " + currentOrders[i].lastName + " - Room " + currentOrders[i].roomNum;
		//}
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
