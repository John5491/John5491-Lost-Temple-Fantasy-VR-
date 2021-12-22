using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterRock : MonoBehaviour
{
    public float shatterredDelay = 2f;
    public GameObject oriObject;
    public GameObject shatteredObject;
    public bool canEffectByBullet = false;

    private void Awake()
    {
        oriObject.SetActive(true);
        shatteredObject.SetActive(false);
    }

    private void Start()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        StartCoroutine(updateShatterStatus());
        Physics.IgnoreLayerCollision(11, 11);
    }

    private IEnumerator updateShatterStatus()
    {
        yield return new WaitForSeconds(shatterredDelay);
        gameObject.GetComponent<Collider>().enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!canEffectByBullet)
        {
            if (collision.gameObject.tag != "Rock" && collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "miniRock")
            {
            
                oriObject.SetActive(false);
                shatteredObject.SetActive(true);
                Destroy(oriObject, 2f);
                Destroy(shatteredObject, 2f);
                if(collision.gameObject.tag == "Player")
                {
                    collision.gameObject.GetComponent<PlayerManager>().deductHealth();
                }
            }
        }
        else
        {
            if (collision.gameObject.tag != "Rock" && collision.gameObject.tag != "miniRock")
            {

                oriObject.SetActive(false);
                shatteredObject.SetActive(true);
                Destroy(oriObject, 2f);
                Destroy(shatteredObject, 2f);
                if (collision.gameObject.tag == "Player")
                {
                    collision.gameObject.GetComponent<PlayerManager>().deductHealth();
                }
            }
        }
        
    }
}
