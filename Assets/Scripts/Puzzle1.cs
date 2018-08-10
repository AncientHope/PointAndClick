using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle1 : MonoBehaviour
{

    public GameObject thePlayer;
    private Walking walkingScript;

    public GameObject crystals;
    
    public GameObject itemA, itemB, mirrorL, mirrorR;

    public Image itemC, itemD, itemE;

    //Finding all GameObjects needed in the script
    void Start()
    {
        thePlayer = GameObject.Find("Character");
        walkingScript = thePlayer.GetComponent<Walking>();



        itemA = GameObject.Find("A");
        itemB = GameObject.Find("B");
        itemC = GameObject.Find("C").GetComponent<Image>();
        itemD = GameObject.Find("D").GetComponent<Image>();
        itemE = GameObject.Find("E").GetComponent<Image>();
    }

    //Checking used Items and displaying sprites
    void Update()
    {
        if(walkingScript.itemUsed[0] == true)
            mirrorL.SetActive(true);

        if (walkingScript.itemUsed[1] == true)
            mirrorR.SetActive(true);
    }
    
    //Checking for collision of player and object to run the interaction animation and update inventory
    void OnTriggerStay2D(Collider2D other)
    {
        if (walkingScript.itemSelected[0] == true && other.name == "Character")
        {
            walkingScript.animator.Play("Character_Interact");
            walkingScript.itemSelected[0] = false;
            walkingScript.itemUsed[0] = true;

            itemA.SetActive(false);
            
        }

        if (walkingScript.itemSelected[1] == true && other.name == "Character")
        {
            walkingScript.animator.Play("Character_Interact");
            walkingScript.itemSelected[1] = false;
            walkingScript.itemUsed[1] = true;

            itemB.SetActive(false);
            mirrorR.SetActive(true);
        }

        if (walkingScript.itemUsed[0] == true && walkingScript.itemUsed[1] == true && other.name == "Character" && walkingScript.itemUnlocked[0] == false)
        {
            walkingScript.itemUnlocked[0] = true;
            crystals.SetActive(true);
            
        }

    }
}
