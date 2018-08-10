using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle3 : MonoBehaviour
{

    public GameObject thePlayer;
    private Walking walkingScript;

   

    public GameObject itemD, itemF;

    public Image itemG, itemH;




    //Finding all GameObjects needed in the script
    void Start()
    {
        thePlayer = GameObject.Find("Character");
        walkingScript = thePlayer.GetComponent<Walking>();


        itemF = GameObject.Find("F");
               
        itemG = GameObject.Find("G").GetComponent<Image>();
        itemH = GameObject.Find("H").GetComponent<Image>();
        
       
    }

    //Checking used Items and displaying sprites
    void Update()
    {
        if(walkingScript.itemUsed[4] == true && walkingScript.itemUsed[5] == true && walkingScript.itemObtained[6] == false)
        {
            itemG.enabled = true;
            itemH.enabled = true;
            walkingScript.itemObtained[6] = true;
        }
       
    }

    //Checking for player collision with puzzle and if right item was selected  / Changing variables
    void OnTriggerStay2D(Collider2D other)
    {
        
        if (walkingScript.itemSelected[5] == true && other.name == "Character")
        {
            walkingScript.animator.Play("Character_Interact");
            walkingScript.itemSelected[5] = false;
            itemF.SetActive(false);
            walkingScript.itemUsed[5] = true;
        }
        
    }
}
