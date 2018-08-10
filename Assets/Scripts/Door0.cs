using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door0 : MonoBehaviour {

    public bool wasClicked;

    public GameObject thePlayer;
    private Walking walkingScript;

    public GameObject fadeGameObject;
    private Fade fadeScript;

    //Finding all GameObjects needed in the script
    void Start()
    {
        thePlayer = GameObject.Find("Character");
        walkingScript = thePlayer.GetComponent<Walking>();

        fadeGameObject = GameObject.Find("FadeColor");
        fadeScript = fadeGameObject.GetComponent<Fade>();
    }


    //Checking for collision with player and changing scene
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.name == "Character" && wasClicked == true)
        {
            fadeScript.FadeOut();
            wasClicked = false;
            walkingScript.canMove = false;
            StartCoroutine("OneSec");
        }
    }

    //Checking if player has waypoint on the door
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Waypoint")
        {
            wasClicked = false;
        }
    }

    //Checking if door was clicked
    void OnMouseDown()
    {
        wasClicked = true;
        
    }

    //Give 1 second for animation to end after clicked on door
    IEnumerator OneSec()
    {
        
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

}
