using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crystals : MonoBehaviour
{
    public GameObject thePlayer, crystals;
    private Walking walkingScript;

    public Image itemC, itemD, itemE;


    public bool wasClicked, wasPicked, wasActive;

    //Finding all GameObjects needed in the script
    void Start()
    {
        thePlayer = GameObject.Find("Character");
        walkingScript = thePlayer.GetComponent<Walking>();

        itemC = GameObject.Find("C").GetComponent<Image>();
        itemD = GameObject.Find("D").GetComponent<Image>();
        itemE = GameObject.Find("E").GetComponent<Image>();

        
    }

    //Checking if Player collected Items
    void Update()
    {
        if (walkingScript.itemUnlocked[0] == true && walkingScript.itemObtained[2] == false)
        {
            crystals.SetActive(true);
        }
        else
        {
            crystals.SetActive(false);
        }
    }

    //Checking for collision of player and object to run the interaction animation and update inventory
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.name == "Character" && wasClicked == true)
        {
            walkingScript.animator.Play("Character_Interact");
            walkingScript.itemObtained[2] = true;
            itemC.enabled = true;
            walkingScript.itemObtained[3] = true;
            itemD.enabled = true;
            walkingScript.itemObtained[4] = true;
            itemE.enabled = true;
            wasPicked = true;
            crystals.SetActive(false);
        }
    }

    //Making the player not pick up crystals by just randomly clicking around
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Waypoint")
        {
            wasClicked = false;
        }
    }

    //Checking for player Clicking on crystals
    void OnMouseDown()
    {
        wasClicked = true;
    }
}
