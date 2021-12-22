using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private bool called = false;
    private bool called1 = false;
    private bool called2 = false;
    private Animator anim;
    public GameObject canvas;
    public GameObject dialogueBox;
    public AudioSource audioS;
    private AudioClip dialogue1, dialogue2, dialogue3;
    // Start is called before the first frame update
    void Start()
    {
        dialogue1 = Resources.Load<AudioClip>("Dialogue1");
        dialogue2 = Resources.Load<AudioClip>("Dialogue2");
        dialogue3 = Resources.Load<AudioClip>("Dialogue3");
        canvas.SetActive(false);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("gwynDialogue"))
        {
            if (!called)
            {
                canvas.SetActive(true);
                audioS.PlayOneShot(dialogue1);
                StartCoroutine(wait(dialogue2));
                called = true;
            }
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("gwynDialogue2"))
        {
            if (!called1)
            {
                dialogueBox.GetComponent<Dialogue>().update();
                StartCoroutine(wait(dialogue3));
                called1 = true;
            }
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("gwynDialogue3"))
        {
            if (!called2)
            {
                dialogueBox.GetComponent<Dialogue>().update();
                called2 = true;
            }
        }
    }

    IEnumerator wait(AudioClip a)
    {
        yield return new WaitForSeconds(4f);
        audioS.PlayOneShot(a);
    }
}
