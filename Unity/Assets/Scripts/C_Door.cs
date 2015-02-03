public class C_Door
{
	public enum Destination{Null, Water, Room, Printer};

	public int number;
	public bool occupied;
	public Destination occupant = Destination.Null;

	private int roomDest;

	// Use this for initialization
	void Start () 
	{
		// send door number and this game object to game manager
	}
	
	public void LeftRoom()
	{
		occupied = false;

	}

	// set the room destination
	public void SetDoorDest(int dest)
	{
		roomDest = dest;
	}
}
