using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibration : MonoBehaviour
{
    private Vector3 initialPosition;
    Vector3 directionOfShake;
    public float amplitude; // the amount it moves
    public float frequency; // the period of the earthquake

    void Start()
    {
        directionOfShake = transform.forward;
        initialPosition = transform.position; // store this to avoid floating point error drift
    }



    void Update()
    {
        transform.position = initialPosition + directionOfShake * Mathf.Sin(frequency * Time.deltaTime) * amplitude;
    }
}
