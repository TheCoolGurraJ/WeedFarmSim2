using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Pot
{
    //Add more properties later. 
    public GameObject gameobj { get; set; }
    public GameObject GrowBar { get; set; }
    public float growstatus { get; set; } = 0f;
    public bool hasgrown { get; set; } = false;
    public GameObject weedplant { get; set; }
    public float timer { get; set; } = 0f;
    public bool isgrowing { get; set; } = false;
}

public class GrowHandler : MonoBehaviour
{
    public List<Pot> pots = new List<Pot>();
    public GameObject player;
    public GameObject[] GrowBars;
    public GameObject weedplant;

    private Scene currScene;
    private static bool isinitialized = false;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
 

        currScene = scene;

        if (currScene.name == "House")
        {
            GrowBars = GameObject.FindGameObjectsWithTag("GrowBar");
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void Start()
    {
        //MAKE THIS SCRIPTABEL OBJECVT TO AVOID MULTIPLE GROWHADNELR

        if (!isinitialized)
        {
            GameObject[] potObjs = GameObject.FindGameObjectsWithTag("Pot");

            for (int i = 0; i < potObjs.Length; i++)
            {
                //Store all children in a list.
                //Pots will be able to be purchased so a growable list makes sense.

                //We create a new Pot object and store it in our list.
                GameObject pot = potObjs[i];
                Pot _pot = new Pot()
                {
                    gameobj = pot,
                    GrowBar = GrowBars[i],
                    growstatus = 0
                };
                pots.Add(_pot);
            }
            isinitialized = true;
        }
    }

    void Update()
    {
        if (currScene.name == "House")
        {
            foreach (Pot pot in pots)
            {
                //The postion of the player in a 2D plane.
                Vector3 targetpos = new Vector3(
                player.transform.position.x,
                pot.GrowBar.transform.position.y,
                player.transform.position.z
                );

                //make bar look at player
                pot.GrowBar.transform.LookAt(targetpos);

                UpdateTimer(pot);

                //update bar with growstatus
                pot.GrowBar.GetComponent<Slider>().value = pot.growstatus;

                if(pot.hasgrown && pot.isgrowing)
                {
                    PotFinished(pot);
                }
            }
        }
        else
        {
            foreach(Pot pot in pots)
            {
                UpdateTimer(pot);
            }
        }
    }

    private void UpdateTimer(Pot pot)
    {
        if (pot.isgrowing)
        {
            pot.timer += Time.deltaTime;
            pot.growstatus = pot.timer / 10;

            if (pot.timer >= 10) //change later to different strains cooldowns.
            {
                pot.hasgrown = true;
                pot.timer = 0;
            }
        }
    }

    public void MakePotGrow(Collider target)
    {
        GameObject potobj = target.gameObject;

        //search for Pot in pots with the corresponding gameobject

        foreach (Pot p in pots)
        {
            if (p.gameobj == potobj)
            {
                if (p.hasgrown && !p.isgrowing)
                {
                    HarvestPlant(p);
                }
                else if(!p.hasgrown && !p.isgrowing)
                {
                    PlantPlant(p);
                }
            }
        }
    }

    public void HarvestPlant(Pot pot)
    {
        //Harvesting plant
        pot.hasgrown = false;
        GameObject.Destroy(pot.weedplant);
        pot.GrowBar.SetActive(true);
        player.GetComponent<InventorySystem>().AddTo("Weed", 1);
    }

    public void PotFinished(Pot pot)
    {
        //pot is now finished!
        pot.growstatus = 0f;
        pot.isgrowing = false;
        //Spawn weedplant
        //Set pos to transform of pot and +1.0 in y-axis to align better.
        Vector3 pos = new Vector3(pot.gameobj.transform.position.x, pot.gameobj.transform.position.y + 1f, pot.gameobj.transform.position.z);
        pot.weedplant = Instantiate(weedplant, pos, Quaternion.identity);
        //Hide Growbar
        pot.GrowBar.SetActive(false);
    }

    public void PlantPlant(Pot pot)
    {
        pot.growstatus = 0f;
        pot.timer = 0f;
        pot.isgrowing = true;
    }

   
}
