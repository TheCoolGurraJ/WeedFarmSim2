using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedKeeper : MonoBehaviour
{
    public int numberOfSec;
    public float timer = 0;
    public Pot potToGrow;
    bool grown;
    public bool potHasGrown = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //update growbar in sync with timer
        if(!grown)
            timer += Time.deltaTime;

        if(timer >=numberOfSec)
        {
            grown = true;
            potHasGrown = true;
        }
    }
}
