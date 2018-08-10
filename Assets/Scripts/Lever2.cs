using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever2 : MonoBehaviour {

    public bool wasClicked, isUp2, isUp3, isUp4;
    public GameObject item2, item3, item4;

    public GameObject lever1, lever3;

    private Lever1 lever1Script;
    private Lever3 lever3Script;

    public GameObject thePlayer;
    private Walking walkingScript;

    //Finding all GameObjects needed in the script
    void Start()
    {
        thePlayer = GameObject.Find("Character");
        walkingScript = thePlayer.GetComponent<Walking>();
        lever1Script = lever1.GetComponent<Lever1>();
        lever3Script = lever3.GetComponent<Lever3>();
    }

    //Checking if levers are up or down and moving crystals
    void Update()
    {

        if (isUp2 == true)
        {
            item2.transform.position = Vector3.MoveTowards(item2.transform.position, new Vector3(28f, 1.33f, 0f), 0.01f);
        }
        else
        {
            item2.transform.position = Vector3.MoveTowards(item2.transform.position, new Vector3(28f, -0.5f, 0f), 0.01f);
        }

        if (isUp3 == true)
        {
            item3.transform.position = Vector3.MoveTowards(item3.transform.position, new Vector3(30f, 1.33f, 0f), 0.01f);
        }
        else
        {
            item3.transform.position = Vector3.MoveTowards(item3.transform.position, new Vector3(30f, -0.5f, 0f), 0.01f);
        }

        if (isUp4 == true)
        {
            item4.transform.position = Vector3.MoveTowards(item4.transform.position, new Vector3(32f, 1.33f, 0f), 0.01f);
        }
        else
        {
            item4.transform.position = Vector3.MoveTowards(item4.transform.position, new Vector3(32f, -0.5f, 0f), 0.01f);
        }
    }

    //Checking for Player click and collision and changing lever position
    void OnTriggerStay2D(Collider2D other)
    {
        if (walkingScript.itemUnlocked[2] == true && walkingScript.itemUnlocked[3] == true)
        {
            if (other.name == "Character" && wasClicked == true)
            {
                wasClicked = false;

                if (isUp2 == true)
                {
                    walkingScript.animator.Play("Character_Interact");
                    FindObjectOfType<AudioManager>().Play("Lever");

                    lever1Script.isUp2 = false;
                    isUp2 = false;
                }
                else
                {
                    walkingScript.animator.Play("Character_Interact");
                    FindObjectOfType<AudioManager>().Play("Lever");

                    lever1Script.isUp2 = true;
                    isUp2 = true;
                }

                if (isUp3 == true)
                {
                    walkingScript.animator.Play("Character_Interact");
                    FindObjectOfType<AudioManager>().Play("Lever");

                    isUp3 = false;
                }
                else
                {
                    walkingScript.animator.Play("Character_Interact");
                    FindObjectOfType<AudioManager>().Play("Lever");

                    isUp3 = true;
                }

                if (isUp4 == true)
                {
                    walkingScript.animator.Play("Character_Interact");
                    FindObjectOfType<AudioManager>().Play("Lever");

                    lever3Script.isUp4 = false;
                    isUp4 = false;
                }
                else
                {
                    walkingScript.animator.Play("Character_Interact");
                    FindObjectOfType<AudioManager>().Play("Lever");

                    lever3Script.isUp4 = true;
                    isUp4 = true;
                }
            }
        }
    }
    

    //Checking if player didn't just click on lever to move around / If waypoint is on top of lever
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Waypoint")
        {
            wasClicked = false;
        }
    }

    //Check if lever was clicked
    void OnMouseDown()
    {
        wasClicked = true;
    }
}
