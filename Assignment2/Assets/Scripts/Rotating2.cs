using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating2 : MonoBehaviour
{
    public float degreesPerSecond = 15.0f;
    private float PorN;
    private float PorN1;
    private float PorN2;

    private void Start()
    {
        PorN = Random.Range(0, 1) * 2 - 1;
        PorN1 = Random.Range(0, 1) * 2 - 1;
        PorN2 = Random.Range(0, 1) * 2 - 1;
    }

    void Update()
    {
        transform.Rotate(new Vector3(Time.deltaTime * degreesPerSecond * PorN, Time.deltaTime * degreesPerSecond * PorN1, Time.deltaTime * -degreesPerSecond * PorN2), Space.World);
    }
}
