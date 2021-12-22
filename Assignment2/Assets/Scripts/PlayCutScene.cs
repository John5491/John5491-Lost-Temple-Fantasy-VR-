using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCutScene : MonoBehaviour
{
    public GameObject Rig;
    public GameObject camera;
    public GameObject Gwyndolin;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            camera.SetActive(true);
            Rig.SetActive(false);
            Gwyndolin.GetComponent<Animator>().SetTrigger("StartDialogue");
        }
    }
}
