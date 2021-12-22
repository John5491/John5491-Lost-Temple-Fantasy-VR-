using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockPortal : MonoBehaviour
{
    public GameObject portal;
    public GameObject portalRing;
    public Material unlockedMat;
    public GameObject gate;

    private bool key1 = false;
    private bool key2 = false;
    private int numberOfKeys = 0;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Key")
            numberOfKeys++;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Key")
            numberOfKeys--;
    }

    private void Update()
    {
        if(numberOfKeys == 2)
        {
            /*portal.SetActive(true);
            Material[] matArray = portalRing.GetComponent<Renderer>().materials;
            matArray[1] = unlockedMat;
            portalRing.GetComponent<Renderer>().materials = matArray;*/
            gate.SetActive(false);
        }
    }
}
