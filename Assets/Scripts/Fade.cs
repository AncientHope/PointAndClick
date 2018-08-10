using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    public Animator animator;
	
	// Update is called once per frame
	void Update () {
		
	}

    //Enabling FadeOut animation
    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }

}
