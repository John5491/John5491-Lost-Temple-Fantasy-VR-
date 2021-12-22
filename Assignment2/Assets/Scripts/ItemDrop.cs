using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject item;
    public float jumpForce = 5f;
    Vector3 jumpPos = new Vector3(0f, 2f, 0f);

    public void dropItem()
    {
        Vector3 pos = gameObject.transform.position;
        pos.y = 1.9f;
        var drops = Instantiate(item, pos, Quaternion.identity) as GameObject;
        drops.GetComponent<Rigidbody>().AddForce(jumpPos * jumpForce, ForceMode.Impulse);
    }
}
