using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pot
{
    //Add more properties later. 
    public GameObject gameobj { get; set; }
    public GameObject GrowBar { get; set; }
    public float growstatus { get; set; } = 0f;
    public bool hasgrown { get; set; } = false;
}

public class GrowHandler : MonoBehaviour
{
    public List<Pot> pots = new List<Pot>();
    public GameObject player;
    public GameObject[] GrowBars;



    void Start()
    {
        GrowBars = GameObject.FindGameObjectsWithTag("GrowBar");
        player = GameObject.FindGameObjectWithTag("Player");


        for (int i = 0; i<this.transform.childCount;i++)
        {
            //Store all children in a list.
            //Pots will be able to be purchased so a growable list makes sense.

            //We create a new Pot object and store it in our list.

            GameObject pot = this.transform.GetChild(i).gameObject;
            Pot _pot = new Pot()
            {
                gameobj = pot,
                GrowBar = GrowBars[i],
                growstatus = 0f
            };        
            pots.Add(_pot);
        }
    }

    void Update()
    {
        
        foreach (Pot pot in pots)
        {

            Vector3 targetpos = new Vector3(
            player.transform.position.x,
            pot.GrowBar.transform.position.y,
            player.transform.position.z
            );

            //make bar look at player
            pot.GrowBar.transform.LookAt(targetpos);

            //update bar with growstatus
            pot.GrowBar.GetComponent<Slider>().value = pot.growstatus;

        }
    }

    public void MakePotGrow(Collider target)
    {
        GameObject potobj = target.gameObject;

        //search for Pot in pots with the corresponding gameobject

        foreach (Pot p in pots)
        {
            if(p.gameobj == potobj)
            {
                p.growstatus += 0.1f;
            }

            if(p.GrowBar.GetComponent<Slider>().value == 1)
            {
                //pot is now finished!
                p.growstatus = 0f;
                p.hasgrown = true;
                //Spawn weedplant
            }
        }
    }
}
