using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC2Script : MonoBehaviour {

    public Animator animator;

    public bool wasClicked, giveItem;

    public GameObject thePlayer, itemH;
    private Walking walkingScript;

    public Image itemA;

    //Finding all GameObjects needed in the script
    void Start()
    {
        thePlayer = GameObject.Find("Character");
        itemH = GameObject.Find("H");
        walkingScript = thePlayer.GetComponent<Walking> ();
        if (walkingScript.itemObtained[1] == false)
        {
            itemA = GameObject.Find("B").GetComponent<Image>();
        }
        //Not displaying NPC after entering the room again once the NPC is on the center room
        if (walkingScript.NPC2Unlock == true)
            gameObject.SetActive(false);
    }

    //Checking for collision of player and object to run the interaction animation and update inventory
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Character" && wasClicked == true && walkingScript.itemObtained[1] == false) 
        {
            FindObjectOfType<AudioManager>().Play("DogSound");
            walkingScript.animator.Play("Character_Interact");
            animator.Play("Dog_Interact");
            walkingScript.itemObtained[1] = true;
            itemA.enabled = true; 
        }

        if (other.name == "Character" && giveItem == true && walkingScript.NPC2Unlock == false)
        {
            walkingScript.animator.Play("Character_Interact");
            FindObjectOfType<AudioManager>().Play("DogSound");
            animator.Play("Dog_Interact");
            itemH.SetActive(false);
            walkingScript.NPC2Unlock = true;
        }
    }

    //Checking if NPC was clicked
    void OnMouseDown()
    {
        wasClicked = true;

        //With right item selected
        if (walkingScript.itemSelected[7] == true)
        {
            giveItem = true;
        }
    }
}
