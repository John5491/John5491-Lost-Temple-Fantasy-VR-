using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetThisOnFire : MonoBehaviour
{
    public GameObject fire1;
    public GameObject fire2;
    public GameObject smoke;

    public Material burnedTrunk;
    public Material burnedLeaves;

    public AudioSource fireSFX;

    private Material oriMat1;
    private Material oriMat2;

    private bool isBurned = false;
    private bool startFade = false;
    private float duration = 3.0f;

    private void Awake()
    {
        Material[] matArray = gameObject.GetComponent<Renderer>().materials;
        oriMat1 = matArray[0];
        oriMat2 = matArray[1];
    }

    private void Update()
    {
        if(startFade)
        {
            var lerp = Mathf.PingPong(Time.time, duration) / duration;
            Material[] matArray = gameObject.GetComponent<Renderer>().materials;
            matArray[0].Lerp(oriMat1, burnedTrunk, lerp);
            matArray[1].Lerp(oriMat2, burnedLeaves, lerp);
            gameObject.GetComponent<Renderer>().materials = matArray;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" && !isBurned)
        {
            fireSFX.Play();
            isBurned = true;
            fire1.SetActive(true);
            fire2.SetActive(true);
            StartCoroutine(burnout());
        }
    }

    private IEnumerator burnout()
    {
        yield return new WaitForSeconds(2f);
        smoke.SetActive(true);
        yield return new WaitForSeconds(4f);
        fire1.SetActive(false);
        fire2.SetActive(false);
        startFade = true;
        /*Material[] matArray = gameObject.GetComponent<Renderer>().materials;
        matArray[0] = burnedTrunk;
        matArray[1] = burnedLeaves;
        gameObject.GetComponent<Renderer>().materials = matArray;*/
        yield return new WaitForSeconds(6f);
        startFade = false;
        smoke.SetActive(false);
    }
}
