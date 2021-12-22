using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GwyndolinMovement : MonoBehaviour
{
    public Transform spawnRock1;
    public Transform spawnRock2;
    public GameObject magicCircle;
    public GameObject magicCircle1;
    public GameObject rockProjectile;
    public GameObject rowAttack1;
    public GameObject rowAttack2;
    public GameObject rowAttack3;
    public GameObject rowWarning1;
    public GameObject rowWarning2;
    public GameObject rowWarning3;
    public Transform target;
    public GameObject deathCam;
    public GameObject XRRig;
    public GameObject canvas;
    public AudioSource audioS;

    public float warningDuration = 1f;
    public float strength = 0.5f;
    public int liveCount = 3;

    Animator anim;

    private bool isAnimating = false;
    private bool canRotate = false;
    private bool shouldRotate = false;
    private Quaternion targetRotation;
    private int liveRemain;

    string[] moves = { "Attack", "Attack2", "Attack3", "Break", "gwynIdle"};
    int[] pattern1 = { 2, 1, 0 };
    int[] pattern2 = { 1, 2, 0 };


    void Awake()
    {
        anim = GetComponent<Animator>();
        targetRotation = Quaternion.LookRotation(target.position - transform.position);
    }

    private void Start()
    {
        isAnimating = true;
        StartCoroutine(buffer());
        liveRemain = liveCount;
        deathCam.SetActive(false);
        canvas.SetActive(false);
    }

    private void Update()
    {
        if (!isAnimating && (liveRemain != 0))
        {
            StartCoroutine(startAttack());
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("gwynIdle"))
        {
            gameObject.GetComponent<PillarAttack>().attack = false;
            StartCoroutine(Wait());
        }
        else
        {
            canRotate = false;
        }
        if (canRotate) {
            if(Quaternion.LookRotation(target.position - transform.position) != targetRotation)
            {
                targetRotation = Quaternion.LookRotation(target.position - transform.position);
                canRotate = false;
                shouldRotate = true;
            }
        }
        if(shouldRotate)
        {
            float str = Mathf.Min(strength * Time.deltaTime, 1);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);
            if (transform.rotation == targetRotation) shouldRotate = false;
        }
    }

    private IEnumerator buffer()
    {
        yield return new WaitForSeconds(10f);
        isAnimating = false;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        canRotate = true;
    }

    IEnumerator startAttack()
    {
        isAnimating = true;
        int setAttackPattern = Random.Range(1, 3);
        if (setAttackPattern == 1)
        {
            anim.SetTrigger(moves[pattern1[0]]);
            StartCoroutine(startRowAttack());
            yield return new WaitForSeconds((float)Random.Range(9, 12));

            anim.SetTrigger(moves[pattern1[1]]);
            yield return new WaitForSeconds(1.5f);
            gameObject.GetComponent<PillarAttack>().attack = true;
            yield return new WaitForSeconds((float)Random.Range(12, 15));

            anim.SetTrigger(moves[pattern1[2]]);
            spawnRock();

            yield return new WaitForSeconds((float)Random.Range(9, 12));
        }
        if (setAttackPattern == 2)
        {
            anim.SetTrigger(moves[pattern2[0]]);
            yield return new WaitForSeconds(1.5f);
            gameObject.GetComponent<PillarAttack>().attack = true;
            yield return new WaitForSeconds((float)Random.Range(9, 12));

            anim.SetTrigger(moves[pattern2[1]]);
            StartCoroutine(startRowAttack());
            yield return new WaitForSeconds((float)Random.Range(12, 15));

            anim.SetTrigger(moves[pattern2[2]]);
            spawnRock();

            yield return new WaitForSeconds((float)Random.Range(9, 12));
        }
        yield return new WaitForSeconds((float)Random.Range(1, 5));
        isAnimating = false;
    }

    private void spawnRock()
    {
        var rock = Instantiate(rockProjectile, spawnRock1.position, Quaternion.identity) as GameObject;
        var rock1 = Instantiate(rockProjectile, spawnRock2.position, Quaternion.identity) as GameObject;
        StartCoroutine(rockSFX());
        rock1.GetComponent<HomingScript>().delayBeforeLaunch = 0.5f;
        var circle1 = Instantiate(magicCircle, spawnRock1.position + new Vector3 (0f, 6.1f, 0f), Quaternion.identity) as GameObject;
        var circle2 = Instantiate(magicCircle, spawnRock2.position + new Vector3(0f, 6.1f, 0f), Quaternion.identity) as GameObject;
        var circle3 = Instantiate(magicCircle1, transform.position + new Vector3(0f, 0.1f, 0f), Quaternion.identity) as GameObject;
        Destroy(circle1, 10f);
        Destroy(circle2, 10f);
        Destroy(circle3, 10f);
    }
    
    IEnumerator rockSFX()
    {
        yield return new WaitForSeconds(3f);
        GameObject.Find("AttackSFX").GetComponent<AttackSoundeffectManager>().rock1S = true;
        GameObject.Find("AttackSFX").GetComponent<AttackSoundeffectManager>().rock2S = true;
    }

    private IEnumerator startRowAttack()
    {
        yield return new WaitForSeconds(warningDuration - 0.5f);
        GameObject.Find("AttackSFX").GetComponent<AttackSoundeffectManager>().warnS = true;
        yield return new WaitForSeconds(0.5f);
        rowWarning1.SetActive(true);
        rowWarning2.SetActive(true);
        rowWarning3.SetActive(true);
        yield return new WaitForSeconds(warningDuration - 0.5f);
        GameObject.Find("AttackSFX").GetComponent<AttackSoundeffectManager>().iceS = true;
        yield return new WaitForSeconds(0.5f);
        rowWarning1.SetActive(false);
        rowWarning2.SetActive(false);
        rowWarning3.SetActive(false);
        rowAttack1.SetActive(true);
        rowAttack2.SetActive(true);
        rowAttack3.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        rowAttack1.SetActive(false);
        rowAttack2.SetActive(false);
        rowAttack3.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Rock")
        {
            liveRemain -= 1;
            if (liveRemain == 0)
            {
                XRRig.SetActive(false);
                anim.SetTrigger("Death");
                deathCam.SetActive(true);
                StartCoroutine(startCanvas());
                isAnimating = true;
                audioS.clip = Resources.Load<AudioClip>("Long_Death");
                audioS.Play();
            }
            else
            {
                if (liveRemain == 2)
                {
                    audioS.clip = Resources.Load<AudioClip>("Hit1");
                    audioS.Play();
                }
                if (liveRemain == 1)
                {
                    audioS.clip = Resources.Load<AudioClip>("Hit2");
                    audioS.Play();
                }
                anim.SetTrigger(moves[3]);
                gameObject.GetComponent<PillarAttack>().spawnMiniRock();
                isAnimating = true;
                gameObject.GetComponent<PillarAttack>().numberOfAttack *= 2;
            }
        }
    }

    private IEnumerator startCanvas()
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(2f);
        audioS.clip = Resources.Load<AudioClip>("Dialogue5");
        audioS.Play();
        yield return new WaitForSeconds(2f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(1f);
        audioS.clip = Resources.Load<AudioClip>("Dialogue4");
        audioS.Play();
        yield return new WaitForSeconds(2f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(2f);
        GameObject.Find("OST").GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
    }
}
