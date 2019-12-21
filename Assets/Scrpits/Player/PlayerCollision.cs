using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().Dead();
            //Dead animation
            //respawn
        }
        else if (collision.gameObject.CompareTag("CanGrab"))
            Destroy(collision.gameObject);
    }

}
