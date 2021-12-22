using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float damage = 10f;
    public float health = 100f;
    bool justDamaged = false;
    public GameObject shield;
    public GameObject bloodEffect;
    public GameOver gameOver;

    public bool needShake = false;

    // Start is called before the first frame update
    void Start()
    {
        bloodEffect.SetActive(false);
        bloodEffect.GetComponent<Renderer>().material.SetFloat("_Opacity", 0f);
        if (needShake)
        {
            StartCoroutine(startingSHake());
        }
    }

    IEnumerator startingSHake()
    {
        yield return new WaitForSeconds(1.7f);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ShakeCamera>().shake2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(health > 90)
            bloodEffect.GetComponent<Renderer>().material.SetFloat("_Opacity", 0f);
        else if (health < 90 && health > 70)
        {
            bloodEffect.SetActive(true);
            bloodEffect.GetComponent<Renderer>().material.SetFloat("_Opacity", 0.5f);
        }
        else if (health < 70 && health > 50)
            bloodEffect.GetComponent<Renderer>().material.SetFloat("_Opacity", 1f);
        else if (health < 50 && health > 20)
            bloodEffect.GetComponent<Renderer>().material.SetFloat("_Opacity", 2f);

        if(health < 0)
        {
            gameOver.EndGame();
        }
    }

    private IEnumerator takeDamage()
    {
        if(!shield.activeSelf)
        {
            justDamaged = true;
            health -= damage;
            yield return new WaitForSeconds(5f);
            justDamaged = false;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Poision" && !justDamaged)
        {
            StartCoroutine(takeDamage());
        }
    }

    public void deductHealth()
    {
        health -= damage;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ShakeCamera>().shake1 = true;
    }
}
