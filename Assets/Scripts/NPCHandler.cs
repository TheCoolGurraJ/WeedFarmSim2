using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHandler : MonoBehaviour
{
    List<NPC_base> NPCs = new List<NPC_base>();
    bool show = true;


    void Start()
    {
        NPC_Seller Seller = new NPC_Seller();
        NPCs.Add(Seller);
    }

    void Update()
    {
        
    }
    
    public void MakeNPCAction(GameObject NPCObj)
    {
        NPC_base identifiedNPC = IdentifyNPC(NPCObj.GetInstanceID());
        identifiedNPC.NPC_Action(show);
        show = !show;
    }

    private NPC_base IdentifyNPC(int id)
    {
        foreach(NPC_base npc in NPCs)
        {
            if(npc.ID == id)
            {
                return npc;
            }
        }
        return null;
    }
}
