using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (CompareTag("Enemy"))
        {
            Destroy(this);
        }
    }
}
