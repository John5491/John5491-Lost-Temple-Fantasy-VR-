using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScatter : MonoBehaviour
{
    public float minForce = 1f;
    public float maxForce = 1f;
    public float radius = 1f;

    private void OnEnable()
    {
        foreach (Transform t in transform)
        {
            var rb = t.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(Random.Range(minForce, maxForce), transform.position, radius);
            }
        }
    }
}
