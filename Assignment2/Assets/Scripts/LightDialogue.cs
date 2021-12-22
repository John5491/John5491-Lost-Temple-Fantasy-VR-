using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDialogue : MonoBehaviour
{
    public GameObject canvas;
    public int dialogueNo = 0;
    public float delayBeforeDialogue = 10.5f;
    public AudioSource audioS;
    private AudioClip mokiSurprise, mokiCurious, mokiGeneral, mokiSad, warp, warpOut;


    private void Start()
    {
        mokiCurious = Resources.Load<AudioClip>("Moki_Curious");
        mokiSurprise = Resources.Load<AudioClip>("Moki_Surprise");
        mokiGeneral = Resources.Load<AudioClip>("Moki_General");
        mokiSad = Resources.Load<AudioClip>("Moki_Sad");
        warp = Resources.Load<AudioClip>("Warp");
        warpOut = Resources.Load<AudioClip>("Warp_Out");
        canvas.SetActive(false);
        if(dialogueNo == 1) audioS.PlayOneShot(warpOut);
        StartCoroutine(begin());
    }

    private IEnumerator begin()
    {
        yield return new WaitForSeconds(delayBeforeDialogue);
        canvas.SetActive(true);
        if(dialogueNo == 0)
        {
            StartCoroutine(updateDialogue());
        }
        else if (dialogueNo == 1)
        {
            StartCoroutine(updateDialogue1());
        }
        else if (dialogueNo == 2)
        {
            StartCoroutine(updateDialogue2());
        }
    }

    private IEnumerator updateDialogue()
    {
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(mokiSurprise);
        yield return new WaitForSeconds(3f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(4f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(mokiSad);
        yield return new WaitForSeconds(4.5f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(6f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(mokiGeneral);
        yield return new WaitForSeconds(2.5f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(3f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        gameObject.GetComponent<WarpSpeed>().activeWarp();
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(warp);
    }

    private IEnumerator updateDialogue1()
    {
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(mokiSurprise);
        yield return new WaitForSeconds(2f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(2.5f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(mokiGeneral);
        yield return new WaitForSeconds(3.5f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(4.5f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(mokiSad);
        yield return new WaitForSeconds(4.5f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(2f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(mokiCurious);
        yield return new WaitForSeconds(4.5f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(mokiGeneral);
        yield return new WaitForSeconds(4.5f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(5f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(mokiSurprise);
        yield return new WaitForSeconds(5f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(1f);
        GameObject.Find("LightFairy").SetActive(false);
    }

    private IEnumerator updateDialogue2()
    {
        audioS.PlayOneShot(mokiSurprise);
        yield return new WaitForSeconds(2.5f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(3f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(mokiGeneral);
        yield return new WaitForSeconds(4f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(mokiSad);
        yield return new WaitForSeconds(2.5f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(3.5f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(mokiCurious);
        yield return new WaitForSeconds(1.5f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(3f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(mokiGeneral);
        yield return new WaitForSeconds(5.5f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(2f);
        canvas.gameObject.transform.Find("DialogueBox").gameObject.GetComponent<Dialogue>().update();
        yield return new WaitForSeconds(1f);
        GameObject.Find("LightFairy").SetActive(false);
    }
}
