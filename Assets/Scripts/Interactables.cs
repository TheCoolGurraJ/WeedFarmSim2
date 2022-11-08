using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactables : MonoBehaviour
{
    public SceneChanger sc;
    public GameObject cam;
    public Camera main_cam;
    public GrowHandler growhandler;
    public RaycastHit hit;
    public bool ishit;

    // Start is called before the first frame update
    void Start()
    {
       if(SceneManager.GetActiveScene().name == "House")
        {
            growhandler = GameObject.FindGameObjectWithTag("GrowHandler").GetComponent<GrowHandler>();
        }

        cam = GameObject.FindGameObjectWithTag("MainCamera");
        //if camera is in scene
        if(cam)
        {
            main_cam = cam.GetComponent<Camera>();
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
                }
            }
        }
    }
}
