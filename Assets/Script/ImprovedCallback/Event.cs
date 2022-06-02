using System;
using UnityEngine;

public abstract class Event<T> where T : Event<T>{
	public string Description;
	public delegate void EventListener(T info);

	private static event EventListener listeners;

	private bool hasFired;
	
	public static void RegisterListener(EventListener listener)
	{
		listeners += listener;
	}

	public static void UnregisterListener(EventListener listener)
	{
		listeners -= listener;
	}

	public void FireEvent()
	{
		if (hasFired){throw new Exception("Event already been fired.");}
		hasFired = true;
		if (listeners != null){listeners(this as T);}
		
	}
}
/**
 * @authors Markus Larsson and Martin Wallmark
 * 
 */
public class DebugEvent : Event<DebugEvent>
{
	public int VerbosityLevel;
}

public class PickUpEvent : Event<PickUpEvent>{
	private int amount;
	private ResourceManager.ItemType type;
	private ResourceManager manager;

	public int GetAmount(){
		return amount;
	}
	
	public void SetAmount(int amount){
		this.amount = amount;
	}
	
	public ResourceManager.ItemType GetItemType(){
		return type;
	}

	public void SetItemType(ResourceManager.ItemType type){
		this.type = type;
	}

	public void SetRM(ResourceManager rm)
    {
		manager = rm;
    }

	public ResourceManager GetRm()
    {
		return manager;
    }

	
}

public class PlayerHealthChangeEvent : Event<PlayerHealthChangeEvent>
{
	public int PlayerHealth;
}

public class PlayerGetHitByZombieEvent : Event<PlayerGetHitByZombieEvent>
{
	public GameObject player;

}

public class PlayerDieEvent : Event<PlayerDieEvent>
{
	public GameObject UnitGO;
}

public class GneratorIsOnEvent : Event<GneratorIsOnEvent>
{
}
public class OnZombieDeathEvent : Event<OnZombieDeathEvent>
{
	public String name;
}
public class PlayeIsNearTheCarEvent : Event<PlayeIsNearTheCarEvent>
{
	public GameObject zombie;
	public BatteryObjectPooled bPool;
}
public class OnAttackWithMaleeEvent : Event<OnAttackWithMaleeEvent>
{
	public DynamicMovementController player;
}
// här skpar ni ny events
public class EatThePizza : Event<EatThePizza>
{
	public IWantPizza pizza; //ni behöver inte lägga något här.
}
public class IncreaseWaveEvent : Event<IncreaseWaveEvent>
{
}
public class HeadShootEvent : Event<HeadShootEvent> {
	public String name;
}
public class ZombieWaveEvent : Event<ZombieWaveEvent>
{

}