using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform player;

    public float followSpeed = 0.125f;
    public Vector3 offset;

    private static CameraScript instance = null;

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

    //Making the camera follow the player with Lerp
    void FixedUpdate()
    {
        Vector3 finalPos = player.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, finalPos, followSpeed);
        transform.position = smoothPos;

    }
}
