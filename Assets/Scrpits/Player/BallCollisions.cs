using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().Dead();
            //Dead animation
        }
        else if (collision.gameObject.CompareTag("CanGrab"))
            Destroy(collision.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlaySound"))
            FindObjectOfType<AudioManager>().Play("Ball");
    }
}