using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalGhost : MonoBehaviour {

    public GameObject thePlayer, ghost1, ghost2;
    
    private Walking walkingScript;

    //Finding all GameObjects needed in the script
    void Start()
    {
        thePlayer = GameObject.Find("Character");
        
        walkingScript = thePlayer.GetComponent<Walking>();
    }

    // Update to set NPC in center room true
    void Update () {
		if(walkingScript.NPC1Unlock == true && walkingScript.NPC2Unlock == true)
        {
            ghost1.SetActive (true);
            ghost2.SetActive (true);
        }
	}
}
