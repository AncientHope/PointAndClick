using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedCrystal : MonoBehaviour
{

    public GameObject thePlayer;
    private Walking walkingScript;
    
    public GameObject itemD, redCrystal;

    //Finding all GameObjects needed in the script
    void Start()
    {
        thePlayer = GameObject.Find("Character");
        walkingScript = thePlayer.GetComponent<Walking>();

        itemD = GameObject.Find("D");

        //Checking if the crystal was used so when player leaves the room display the sprite again upon entering
        if (walkingScript.itemUsed[4] == true)
        {
            redCrystal.SetActive(true);
        }
    }

    //Checking for player collision with puzzle and if right item was selected / Changing variables
    void OnTriggerStay2D(Collider2D other)
    {

        if (walkingScript.itemSelected[3] == true && other.name == "Character")
        {
            walkingScript.animator.Play("Character_Interact");
            walkingScript.itemSelected[3] = false;
            itemD.SetActive(false);
            redCrystal.SetActive(true);
            walkingScript.itemUsed[4] = true;
        }
    }
}
