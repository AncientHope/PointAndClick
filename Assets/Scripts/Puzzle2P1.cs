using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle2P1 : MonoBehaviour
{

    public GameObject thePlayer, lever1, lever2, lever3;
    private Walking walkingScript;

    private Lever1 lever1Script;
    private Lever2 lever2Script;
    private Lever3 lever3Script;

    public GameObject crystalC, crystalE;

    public GameObject itemC, itemE;

    public Image itemF, itemG;
        
    public bool[] itemUsed;
    public bool crystalsUsed;

    //Finding all GameObjects needed in the script
    void Start()
    {
        thePlayer = GameObject.Find("Character");
        walkingScript = thePlayer.GetComponent<Walking>();

        lever1Script = lever1.GetComponent<Lever1>();
        lever2Script = lever2.GetComponent<Lever2>();
        lever3Script = lever3.GetComponent<Lever3>();

        //itemC = GameObject.Find("C");
        itemC = GameObject.Find("C");
        itemE = GameObject.Find("E");
        itemF = GameObject.Find("F").GetComponent<Image>();
       
    }

    //Checking used Items and displaying sprites
    void Update()
    {
        if(walkingScript.itemUsed[2] == true)
            crystalC.SetActive(true);

        if (walkingScript.itemUsed[3] == true)
            crystalE.SetActive(true);

        //Completing Puzzle if all crystals are Up
        if(lever1Script.isUp1 == true && lever2Script.isUp2 == true && lever2Script.isUp3 == true && lever2Script.isUp4 == true && lever3Script.isUp5 == true && walkingScript.itemUnlocked[1] == false && walkingScript.itemUsed[2] == true && walkingScript.itemUsed[3] == true)
        {
            walkingScript.itemUnlocked[1] = true;
            walkingScript.animator.Play("Character_Interact");
            walkingScript.itemObtained[5] = true;
            itemF.enabled = true;
            
        }
    }

    //Checking for collision of player and object to run the interaction animation and update inventory
    void OnTriggerStay2D(Collider2D other)
    {

        if (walkingScript.itemSelected[2] == true && other.name == "Character")
        {
            walkingScript.animator.Play("Character_Interact");
            walkingScript.itemSelected[3] = false;
            itemC.SetActive(false);
            walkingScript.itemUsed[2] = true;
            crystalC.SetActive(true);
        }

        if (walkingScript.itemSelected[4] == true && other.name == "Character")
        {
            walkingScript.animator.Play("Character_Interact");
            walkingScript.itemSelected[4] = false;
            itemE.SetActive(false);
            walkingScript.itemUsed[3] = true;
            crystalE.SetActive(true);
        }
        
    }
}
