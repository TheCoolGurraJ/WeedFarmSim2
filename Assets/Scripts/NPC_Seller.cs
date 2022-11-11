using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class NPC_Seller : NPC_base
{
    public override string Name => "Tom";

    public override GameObject NPC_Object => (GameObject)Resources.Load("Prefabs/NPC_Seller");

    public override Vector3 NPC_Position => new Vector3(-11, 1, 9.5f);

    public NPC_Seller()
    {
        GameObject seller = GameObject.Instantiate(NPC_Object, NPC_Position, Quaternion.identity);
        ID = seller.GetInstanceID();
    }

    public override void NPC_Action(bool show)
    {
        DialogManager dialogManager = GameObject.FindGameObjectWithTag("DialogAsset").GetComponent<DialogManager>();

        if (show)
        {
            Debug.Log("Hello");

            DialogData test = new DialogData("Hello! Do you have some weed?", "Seller");
            dialogManager.Show(test);
        }
        else
        {
            dialogManager.Hide();
        }
    }
}
