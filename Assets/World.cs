using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct Faction {
	public string Name;
	public int Size;
}

public class Region {
	public int ID;
	public string Name { get; private set; }
	public List<Faction> factions;

	public Region(int id, string name)
	{
		this.ID = id;
		this.Name = name;
		this.factions = new List<Faction>();
	}

	public void AddFaction(Faction f)
	{
		factions.Add (f);
	}
}

public class World {
	public static int SOTON_ID = 0;

	public List<Region> regions;
	public World()
	{
		this.regions = new List<Region> ();
		this.regions.Add(new Region (SOTON_ID, "Southampton"));
		this.regions [SOTON_ID].AddFaction (new Faction(){Name="Nobles", Size = 100});
	}

	public void DoEvent(ConcreteEvent g)
	{
		//Debug.Log("Currently executing event " + g.Name);
		g.Event.Do (this, this.regions [g.RegionID]);
	}
}
