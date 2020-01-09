using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    CharacterController cc;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(FindObjectOfType<SlowWalking>().slowWalking == false && cc.isGrounded == true && cc.velocity.magnitude > 0f && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().volume = Random.Range(0.1f, 0.2f);
            GetComponent<AudioSource>().pitch = Random.Range(0.3f, 0.6f);
            GetComponent<AudioSource>().Play();
        }
    }
}
