using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowWalking : MonoBehaviour
{
    PlayerMovement pm;
    bool isSlowlyWalking;
    float walkSpeed, slowWalk;

    [HideInInspector]
    public bool slowWalking = false;
    void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
        walkSpeed = pm.movement;
        slowWalk = 2f;
    }
    void SetSlowlyWalking(bool isSlowlyWalking)
    {
        this.isSlowlyWalking = isSlowlyWalking;
        pm.movement = isSlowlyWalking ? slowWalk : walkSpeed;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SetSlowlyWalking(true);
            slowWalking = true;
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            SetSlowlyWalking(false);
            slowWalking = false;
        }
    }
}
