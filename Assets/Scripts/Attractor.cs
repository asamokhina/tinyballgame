using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public float G = 6.6f;
    public Rigidbody rb;

    public static List<Attractor> Attractors;
    void FixedUpdate ()
	{
		foreach (Attractor attractor in Attractors)
		{
			if (attractor != this)
				Attract(attractor);
		}
	}
    void OnEnable () {
        if (Attractors == null) {
            Attractors = new List<Attractor>();
        }
        Attractors.Add(this);
    }

    void OnDisable() {
        Attractors.Remove(this);
    }

    void Attract(Attractor other) {

        Vector3 direction = rb.position - other.rb.position;
		float distance = direction.magnitude;

		if (distance == 0f)
			return;

		float forceMagnitude = G * (rb.mass * other.rb.mass) / Mathf.Pow(distance, 2);
		Vector3 force = direction.normalized * forceMagnitude;

		other.rb.AddForce(force);
    }
}
