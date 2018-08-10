using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Walking : MonoBehaviour {

    public Animator animator;

    public GameObject waypoint;

    public SpriteRenderer crystal1, crystal2, crystal3;

    public bool enter = true;
    public bool facingBack = false;
    public bool goingToDoor = false;
    public bool[] itemObtained, itemSelected, itemUnlocked, itemUsed;
    public bool crystalsUnlock, NPC1Unlock, NPC2Unlock, canMove;

    private static Walking instance = null;

    //Don't Destroy on Load Function
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
    }

    // Update for movement
    void Update () {
        if(canMove == false)
        {
            StartCoroutine("OneSec");
        }

        if (waypoint.activeSelf == true)
        {
            animator.SetBool("IsWalking", true);
            this.transform.position = Vector3.MoveTowards(transform.position, waypoint.transform.position, 0.1f);
        }

        if (Input.GetMouseButtonDown(0) && Camera.main.ScreenToWorldPoint(Input.mousePosition).y > -3.5f && canMove == true) {
            
                waypoint.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -1.55f);
                waypoint.SetActive(true);
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < this.transform.position.x && facingBack == false)
            {
                transform.Rotate(Vector3.up * 180);
                facingBack = true;
            }
            else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > this.transform.position.x && facingBack == true)
            {
                transform.Rotate(Vector3.up * 180);
                facingBack = false;
                
            }
            
        }

        //Checking for completed puzzle and displaying images if so
        if (itemUsed[0] == true && itemUsed[1] == true && crystalsUnlock == false)
        {
            crystalsUnlock = true;
        }

        if (itemUnlocked[0] == true && itemObtained[2] == false && "3" == SceneManager.GetActiveScene().name)
        {
            crystal1 = GameObject.Find("Crystal1").GetComponent<SpriteRenderer>();
            crystal1.enabled = true;

            crystal2 = GameObject.Find("Crystal2").GetComponent<SpriteRenderer>();
            crystal2.enabled = true;

            crystal3 = GameObject.Find("Crystal3").GetComponent<SpriteRenderer>();
            crystal3.enabled = true;
        }
    }

    //Checking for colision with waypoint to disable it
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Waypoint")
        {
            waypoint.SetActive(false);
            animator.SetBool("IsWalking", false);

            for(int i=0; i < itemSelected.Length; i++)
            {

                itemSelected[i] = false;
            }
        }
    }

    //Give 1 second for player to start moving after scene is loaded
    IEnumerator OneSec()
    {
        yield return new WaitForSeconds(1.5f);
        canMove = true;
    }

    //Functions for selecting Items
    public void ItemA()
    {
        for (int i = 0; i < itemSelected.Length; i++)
        {

            itemSelected[i] = false;
        }
        itemSelected[0] = true;
    }

    public void ItemB()
    {
        for (int i = 0; i < itemSelected.Length; i++)
        {

            itemSelected[i] = false;
        }
        itemSelected[1] = true;
    }

    public void ItemC()
    {
        for (int i = 0; i < itemSelected.Length; i++)
        {

            itemSelected[i] = false;
        }
        itemSelected[2] = true;
    }

    public void ItemD()
    {
        for (int i = 0; i < itemSelected.Length; i++)
        {

            itemSelected[i] = false;
        }
        itemSelected[3] = true;
    }

    public void ItemE()
    {
        for (int i = 0; i < itemSelected.Length; i++)
        {

            itemSelected[i] = false;
        }
        itemSelected[4] = true;
    }

    public void ItemF()
    {
        for (int i = 0; i < itemSelected.Length; i++)
        {

            itemSelected[i] = false;
        }
        itemSelected[5] = true;
    }

    public void ItemG()
    {
        for (int i = 0; i < itemSelected.Length; i++)
        {

            itemSelected[i] = false;
        }
        itemSelected[6] = true;
    }

    public void ItemH()
    {
        for (int i = 0; i < itemSelected.Length; i++)
        {

            itemSelected[i] = false;
        }
        itemSelected[7] = true;
    }
}
