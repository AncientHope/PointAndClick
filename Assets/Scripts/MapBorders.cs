using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBorders : MonoBehaviour {

    public GameObject thePlayer;
    private Walking walkingScript;

    public GameObject waypoint;

    //Finding all GameObjects needed in the script
    void Start()
    {
        thePlayer = GameObject.Find("Character");
        walkingScript = thePlayer.GetComponent<Walking>();
    }

    void Update()
    {
        if(waypoint == null)
        waypoint = GameObject.Find("Waypoint");
    }

    //Making the waypoint not active when player clicks on walls or celling
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.name == "Waypoint")
        {
            waypoint.SetActive(false);
            walkingScript.animator.SetBool("IsWalking", false);

            for (int i = 0; i < walkingScript.itemSelected.Length; i++)
            {

                walkingScript.itemSelected[i] = false;
            }
        }
    }
}
