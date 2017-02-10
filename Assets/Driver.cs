using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public abstract class GameEvent
{
	public static int BLOW_UP_TRAIN = 0;
	public string Name {get; protected set;}

	public abstract void Do (World w, Region r);
}

public class BombTrainEvent : GameEvent
{
	public BombTrainEvent()
	{
		this.Name = "Bomb Train";
	}

	public override void Do(World w, Region r)
	{
		Debug.Log ("Bombed a train in " + r.Name);
	}
}

public struct ConcreteEvent
{
	public GameEvent Event;
	public int RegionID;

	public string Name { get { return Event.Name; } }

	public ConcreteEvent(GameEvent g, int r)
	{
		this.Event = g;
		this.RegionID = r;
	}
}

public class Planner
{
	private List<KeyValuePair<int, int>> eventsToHappen;
	public Planner()
	{
		eventsToHappen = new List<KeyValuePair<int, int>> ();
	}

	public void AddEvent(int eventid, int regionid)
	{
		eventsToHappen.Add (new KeyValuePair<int, int>(eventid, regionid));
		Debug.Log ("Added event " + Driver.Events[eventid].Name);
	}
	public IEnumerable<ConcreteEvent> GetEvents()
	{
		return eventsToHappen.Select (t => new ConcreteEvent(Driver.Events [t.Key], t.Value));
	}
}
public class Driver : MonoBehaviour {
	
	public enum Stage
	{
		Planning,
		DayRunning,
		Summary
	}

	public static Dictionary<int, GameEvent> Events;
	private Stage stage;
	public int Day = 1;
	public World world;
	public Planner planner;

	// Use this for initialization
	void Start () {
		stage = Stage.Planning;
		world = new World ();
		planner = new Planner ();
		Events = new Dictionary<int, GameEvent> ();
		Events.Add (GameEvent.BLOW_UP_TRAIN, new BombTrainEvent ());
	}
	
	// Update is called once per frame
	void Update () {
		switch (stage) {
		case Stage.Planning:
			if (!Input.GetKeyDown (KeyCode.A))
			{
				return;
			}
			planner.AddEvent(GameEvent.BLOW_UP_TRAIN, World.SOTON_ID);
			stage = Stage.DayRunning;
			break;
		case Stage.DayRunning:
			SimulateDay();
			stage = Stage.Planning;
			break;
		}
	}

	void SimulateDay()
	{
		Debug.Log ("starting day" + Day);
		//for each event:
		foreach(ConcreteEvent g in planner.GetEvents())
		{
			world.DoEvent(g);
			planner.ClearEvent();
		}
		Debug.Log ("ending day" + Day);
		Day++;
	}
}
