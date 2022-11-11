using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_base
{
    protected int _id = 0;
    protected string _name = "Unknown";
    protected GameObject _npcObj = null;
    protected Vector3 _npcPosition = new Vector3(0, 0, 0);


    public virtual int ID
    {
        get { return _id; }
        set { _id = value; }
    }

    public virtual string Name
    {
        get { return _name; }
    }

    public virtual GameObject NPC_Object
    {
        get { return _npcObj; }
    }

    public virtual Vector3 NPC_Position
    {
        get { return _npcPosition; }
    }

    public virtual void NPC_Action(bool show)
    {
        Debug.Log("base method called");
    }
}
