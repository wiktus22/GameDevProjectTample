using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawning : MonoBehaviour
{
    [SerializeField] private Transform ballRespawn;
    [SerializeField] private Transform ball;

    void OnTriggerEnter(Collider other)
    {
        ball.transform.position = ballRespawn.transform.position;
    }
}
