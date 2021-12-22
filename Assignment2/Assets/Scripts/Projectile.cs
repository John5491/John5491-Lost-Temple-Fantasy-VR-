using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject impactVFX;
    public GameObject rippleVFX;
    public GameObject smallFireVFX;

    private bool collided;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Player" && !collided)
        {
            collided = true;

            var impact = Instantiate(impactVFX, collision.contacts[0].point, Quaternion.identity) as GameObject;
            if (collision.gameObject.tag == "Barrier")
            {
                var ripple = Instantiate(rippleVFX, collision.contacts[0].point, Quaternion.identity) as GameObject;
                Destroy(ripple, 2);
            }
            if (collision.gameObject.tag == "Terrain")
            {
                Debug.Log("Hi");
                var smallFire = Instantiate(smallFireVFX, collision.contacts[0].point, Quaternion.identity) as GameObject;
                Destroy(smallFire, 8);
            }

            Destroy(impact, 2);
            Destroy(gameObject);
        }
    }
}
