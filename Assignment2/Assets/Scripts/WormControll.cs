using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormControll : MonoBehaviour
{
    public GameObject barrier;

    public float damage = 10f;
    public float noOfReset = 1;
    public float currentReset = 0;
    public float wormHealth = 200f;
    public int attackProb = 5;
    private float wormCurrentHealth;
    private bool healthIsEmpty = false;
    Animator anim;

    private bool isAnimating = false;
    private bool justDamaged = false;
    private bool printed = false;
    public bool death = false;
    private bool dropped = false;

    string[] moves = { "appear", "disappear", "idleBreak", "GotHitHead", "GotHitBody", "attack3", "death", "block1" };

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        wormCurrentHealth = wormHealth;
    }

    private void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !isAnimating)
        {
            StartCoroutine(animate());
        }
        if (!healthIsEmpty)
            checkHealth();
        else
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack03"))
            {
                if (death)
                {
                    anim.Play("Disappear");
                    StartCoroutine(destroyThisWorm());
                }
                else
                {
                    anim.Play("Block01");
                    anim.SetBool(moves[7], true);
                    if (!printed && anim.GetCurrentAnimatorStateInfo(0).IsName("Block01"))
                    {
                        barrier.GetComponent<DissolveObject>().startFadeOut = true;
                        StartCoroutine(resetHealth());
                        printed = true;
                    }
                }
            }
        }
    }

    private IEnumerator animate()
    {
        int animateIorA = Random.Range(1, 10);
        isAnimating = true;
        if(animateIorA >1 && animateIorA <= attackProb)
            anim.SetTrigger(moves[5]);
        yield return new WaitForSeconds(7f);
        isAnimating = false;
    }

    private void OnEnable()
    {
        anim.Play("Appear");
    }

    public void startAnimation(int position)
    {
        anim.SetTrigger(moves[position]);
    }

    public void takeDamage()
    {
        if(!justDamaged)
        {
            int randomAnim = Random.Range(3, 4);
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("IdleBreak"))
                anim.Play(moves[randomAnim]);
            justDamaged = true;
            StartCoroutine(waitForAwhile(3));
        }

        wormCurrentHealth -= damage;
    }

    private void checkHealth()
    {
        if(wormCurrentHealth <= 0)
        {
            healthIsEmpty = true;
            printed = false;
            if(currentReset == noOfReset)
                death = true;
        }
    }

    private IEnumerator resetHealth()
    {
        yield return new WaitForSeconds(5f);
        anim.SetBool(moves[7], false);
        healthIsEmpty = false;
        wormCurrentHealth = wormHealth;
        barrier.SetActive(true);
        currentReset++;
    }

    private IEnumerator waitForAwhile(float time)
    {
        yield return new WaitForSeconds(time);
        justDamaged = false;
    }

    private IEnumerator destroyThisWorm()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        if (!dropped)
        {
            dropped = true;
            gameObject.GetComponent<ItemDrop>().dropItem();
        }
    }
}
