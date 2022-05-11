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
		
		Debug.Log(Description);
	}
}

public class PickUpEvent : Event<PickUpEvent>{
	private int amount;
	private ResourceManager.ItemType type;
	//private ResourceManager manager;

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

	
}