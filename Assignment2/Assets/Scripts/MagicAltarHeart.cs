using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAltarHeart : MonoBehaviour
{
    public GameObject barrier;
    public GameObject worm1;
    public GameObject worm2;
    public GameObject sacrificialAltar;
    public GameObject explodeParticle;

    public float heartHealth = 100f;
    public float damage = 10f;
    public bool destroyed = false;
    
    private bool collided = false;
    private bool guarded = false;
    private bool activated = false;
    private Animator anim1;
    private Animator anim2;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" && !collided)
        {
            collided = true;
            barrier.SetActive(true);
            worm1.SetActive(true);
            GameObject.Find("OST").GetComponent<AudioSceneTransition>().changeClip();
        }
        if (collision.gameObject.tag == "Bullet")
            takeDamage();
    }

    private void Awake()
    {
        anim1 = worm1.GetComponent<Animator>();
        anim2 = worm2.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (worm1 == null && worm2 != null)
            worm2.SetActive(true);
        if(worm1 == null && worm2 == null)
        {
            barrier.GetComponent<DissolveObject>().startFadeOut = true;
        }
        checkHealth();
    }

    private void takeDamage()
    {
        heartHealth -= damage;
    }

    private void checkHealth()
    {
        //Debug.Log(heartHealth);
        if (heartHealth < 0)
        {
            gameObject.SetActive(false);
            explodeParticle.SetActive(true);
            destroyed = true;
            sacrificialAltar.SetActive(true);
        }
    }

    private IEnumerator activateBarrier()
    {
        Debug.Log("Hi");
        yield return new WaitForSeconds(4f);
        barrier.SetActive(true);
        activated = false;
    }
}
