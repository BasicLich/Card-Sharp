using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillLineScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Enemy")
        {
            other.collider.enabled = false;
        }
    }
}