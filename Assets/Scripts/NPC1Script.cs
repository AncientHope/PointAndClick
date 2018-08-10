using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC1Script : MonoBehaviour {

    public Animator animator;

    public bool wasClicked, giveItem;

    public GameObject thePlayer, itemG;
    private Walking walkingScript;

    public Image itemA;

    //Finding all GameObjects needed in the script
    void Start()
    {
        thePlayer = GameObject.Find("Character");
        itemG = GameObject.Find("G");
        walkingScript = thePlayer.GetComponent<Walking> ();
        if (walkingScript.itemObtained[0] == false)
        {
            itemA = GameObject.Find("A").GetComponent<Image>();
        }
        //Not displaying NPC after entering the room again once the NPC is on the center room
        if (walkingScript.NPC1Unlock == true)
            gameObject.SetActive(false);
    }

    //Checking for collision of player and object to run the interaction animation and update inventory
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Character" && wasClicked == true && walkingScript.itemObtained[0] == false) 
        {
            walkingScript.animator.Play("Character_Interact");
            animator.Play("Cat_Interact");
            walkingScript.itemObtained[0] = true;
            itemA.enabled = true; 
        }

        if (other.name == "Character" && giveItem == true && walkingScript.NPC1Unlock == false)
        {
            walkingScript.animator.Play("Character_Interact");
            animator.Play("Cat_Interact");
            itemG.SetActive(false);
            walkingScript.NPC1Unlock = true;
        }
    }

    //Checking if NPC was clicked
    void OnMouseDown()
    {
        wasClicked = true;

        //With right item selected
        if (walkingScript.itemSelected[6] == true)
        {
            giveItem = true;
        }
    }
}
