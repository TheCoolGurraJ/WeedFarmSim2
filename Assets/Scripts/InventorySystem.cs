using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem
{
    public string Id { get; set; }
    public int Value { get; set; }

    public InventoryItem(string id, int val) 
    {
        this.Id = id;
        this.Value = val;
    }
}


public class InventorySystem : MonoBehaviour
{
    public GameObject WeedCounterActual;
    // Start is called before the first frame update
    public InventoryItem[] inv = new InventoryItem[]
    {
        new InventoryItem("Weed",0),
        new InventoryItem("Ammo",0), //Init array with our different type of collectables.
        new InventoryItem("Money",0),
    };
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTo(string type,int amount)
    {
        foreach(InventoryItem i in inv)
        {
            if(i.Id == type)
            {
                i.Value += amount;
                WeedCounterActual.GetComponent<Text>().text = i.Value.ToString();
            }
        }
        
    }
}
