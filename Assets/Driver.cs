using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameEvent
{
}

public class Planner
{
	public void AddEvent()
	{
		Debug.Log ("Added event");
	}
	public List<GameEvent> GetEvents()
	{
		return new List<GameEvent>();
	}
}
public class Driver : MonoBehaviour {
	
	public enum Stage
	{
		Planning,
		DayRunning,
		Summary
	}

	public Stage stage;
	public World world;
	public Planner planner;

	// Use this for initialization
	void Start () {
		stage = Stage.Planning;
		world = new World ();
		planner = new Planner ();
	}
	
	// Update is called once per frame
	void Update () {
		switch (stage) {
		case Stage.Planning:
			if (!Input.GetKeyDown (KeyCode.A))
			{
				return;
			}
			planner.AddEvent();
			Debug.Log("starting day");
			break;
		case Stage.DayRunning:
			SimulateDay();
			break;
		}
	}

	void SimulateDay()
	{
		//for each event:
		foreach(GameEvent g in planner.GetEvents())
		{
			world.DoEvent(g);
		}
	}
}
