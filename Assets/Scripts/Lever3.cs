using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever3 : MonoBehaviour
{

    public bool wasClicked, isUp1, isUp4, isUp5;
    public GameObject item1, item4, item5;
    public GameObject lever1, lever2;

    private Lever1 lever1Script;
    private Lever2 lever2Script;

    public GameObject thePlayer;
    private Walking walkingScript;

    //Finding all GameObjects needed in the script
    void Start()
    {

        thePlayer = GameObject.Find("Character");
        walkingScript = thePlayer.GetComponent<Walking>();

        lever1Script = lever1.GetComponent<Lever1>();
        lever2Script = lever2.GetComponent<Lever2>();

    }

    //Checking if levers are up or down and moving crystals
    void Update()
    {

        if (isUp1 == true)
        {
            item1.transform.position = Vector3.MoveTowards(item1.transform.position, new Vector3(26f, 1.33f, 0f), 0.01f);
        }
        else
        {
            item1.transform.position = Vector3.MoveTowards(item1.transform.position, new Vector3(26f, -0.5f, 0f), 0.01f);
        }

        if (isUp4 == true)
        {
            item4.transform.position = Vector3.MoveTowards(item4.transform.position, new Vector3(32f, 1.33f, 0f), 0.01f);
        }
        else
        {
            item4.transform.position = Vector3.MoveTowards(item4.transform.position, new Vector3(32f, -0.5f, 0f), 0.01f);
        }

        if (isUp5 == true)
        {
            item5.transform.position = Vector3.MoveTowards(item5.transform.position, new Vector3(34f, 1.33f, 0f), 0.01f);
        }
        else
        {
            item5.transform.position = Vector3.MoveTowards(item5.transform.position, new Vector3(34f, -0.5f, 0f), 0.01f);
        }
    }

    //Checking for Player click and collision and changing lever position
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.name == "Character" && wasClicked == true)
        {
            wasClicked = false;

            if (isUp1 == true)
            {
                walkingScript.animator.Play("Character_Interact");
                FindObjectOfType<AudioManager>().Play("Lever");

                lever1Script.isUp1 = false;
                isUp1 = false;
            }
            else
            {
                walkingScript.animator.Play("Character_Interact");
                FindObjectOfType<AudioManager>().Play("Lever");

                lever1Script.isUp1 = true;
                isUp1 = true;
            }

            if (isUp4 == true)
            {
                walkingScript.animator.Play("Character_Interact");
                FindObjectOfType<AudioManager>().Play("Lever");

                lever2Script.isUp4 = false;
                isUp4 = false;
            }
            else
            {
                walkingScript.animator.Play("Character_Interact");
                FindObjectOfType<AudioManager>().Play("Lever");

                lever2Script.isUp4 = true;
                isUp4 = true;
            }

            if (isUp5 == true)
            {
                walkingScript.animator.Play("Character_Interact");
                FindObjectOfType<AudioManager>().Play("Lever");

                lever1Script.isUp5 = false;
                isUp5 = false;
            }
            else
            {
                walkingScript.animator.Play("Character_Interact");
                FindObjectOfType<AudioManager>().Play("Lever");

                lever1Script.isUp5 = true;
                isUp5 = true;
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
