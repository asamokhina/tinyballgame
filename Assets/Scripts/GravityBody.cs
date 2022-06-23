using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public GravityAttractor attractor;
    Transform bodyTransform;

    void Start()
    {   Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
        bodyTransform = transform;

    }

    void Update()
    {
        attractor.Attract(bodyTransform);
    }
}
