using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;


public class Interactables : MonoBehaviour
{
    public SceneChanger sc;
    public GameObject cam;
    public Camera main_cam;
    public GrowHandler growhandler;
    public GameObject npchandler;
    public RaycastHit hit;
    public bool ishit;

    // Start is called before the first frame update
    void Start()
    {
        if (sc.GetCurrentScene() == "Main")
        {
            DialogManager dialogManager = GameObject.FindGameObjectWithTag("DialogAsset").GetComponent<DialogManager>();

            dialogManager.HideDialogOnEnable();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = main_cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        ishit = Physics.Raycast(ray,out hit,3f);
    }

    void Update()
    {
        if (ishit)
        {   
            //Add check to see if player is in range.
            if (Input.GetKeyDown(KeyCode.E))
            {
                switch (hit.collider.gameObject.tag)
                {
                    case "Door":
                        //change scene
                        sc.ChangeScene();
                        break;

                    case "Pot":
                        //Make it grow!
                        growhandler.MakePotGrow(hit.collider);
                        break;

                    case "NPC":
                        npchandler.GetComponent<NPCHandler>().MakeNPCAction(hit.collider.gameObject);
                        break;
                }
            }
        }
        growhandler.UpdateValues();
    }
}
