using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterObject : MonoBehaviour
{
    public GameObject oriObject;
    public GameObject shatteredObject;

    private void Awake()
    {
        oriObject.SetActive(true);
        shatteredObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            oriObject.SetActive(false);
            shatteredObject.SetActive(true);
        }
    }
}
