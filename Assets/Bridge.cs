using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    FixedJoint2D bridge;

    private void Start()
    {
        bridge = GetComponent<FixedJoint2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            bridge.breakForce = 0;
        }
    }
}
