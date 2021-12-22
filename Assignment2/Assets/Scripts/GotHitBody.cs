using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotHitBody : MonoBehaviour
{
    public GameObject body;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            body.GetComponent<WormControll>().takeDamage();
        }
    }
}
