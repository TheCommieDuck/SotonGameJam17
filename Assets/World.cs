using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct Faction {
	public string Name;
	public int Size;
}

public class Region {
	public int ID;
<<<<<<< HEAD
	public string Name { get; private set; }
=======
	public string Name;
>>>>>>> f7d6ee10082b69ebcb1642d58d1c8e01866ea6fa
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
<<<<<<< HEAD
	public static int SOTON_ID = 0;
=======
	public static int SOMEWHERE_ID = 0;
>>>>>>> f7d6ee10082b69ebcb1642d58d1c8e01866ea6fa

	public List<Region> regions;
	public World()
	{
		this.regions = new List<Region> ();
<<<<<<< HEAD
		this.regions.Add(new Region (SOTON_ID, "Southampton"));
		this.regions [SOTON_ID].AddFaction (new Faction(){Name="Nobles", Size = 100});
	}

	public void DoEvent(ConcreteEvent g)
	{
		//Debug.Log("Currently executing event " + g.Name);
		g.Event.Do (this, this.regions [g.RegionID]);
=======
		this.regions.Add(new Region (SOMEWHERE_ID, "Somewhere"));
		this.regions [SOMEWHERE_ID].AddFaction (new Faction(){Name="Nobles", Size = 100});
	}

	public void DoEvent(GameEvent g)
	{
>>>>>>> f7d6ee10082b69ebcb1642d58d1c8e01866ea6fa
	}
}
