using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (CompareTag("Stone"))
        {
            Destroy(this);
            Destroy(col);
            
        }
        else if (CompareTag("Door"))
        {
            Destroy(this);
            
        }
    }
}
