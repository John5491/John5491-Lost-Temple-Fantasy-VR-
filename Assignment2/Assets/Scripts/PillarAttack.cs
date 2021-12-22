using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarAttack : MonoBehaviour
{
    public GameObject[] attackPosition;
    public GameObject warningObject;
    public GameObject laserAttack;
    public GameObject miniRock;

    public int iniNumberOfAttack = 3;
    public float attackDuration = 2f;
    public float warningDuration = 2f;
    public int attackMaxSize = 50;
    public bool attack = false;
    private int size;
    private List<int> positionToAttack;
    private bool selected = false;
    private bool hasAttacked = false;
    private bool hasWarned = false;
    public float numberOfAttack;
    public float numberOfMiniRock = 10;

    private void Start()
    {
        positionToAttack = new List<int>(new int[attackMaxSize]);
        size = attackPosition.Length - 1;
        numberOfAttack = iniNumberOfAttack;
    }

    private void Update()
    {
        if(attack)
        {
            if (!selected)
            {
                for(int i = 0; i < numberOfAttack; i++)
                {
                    int temp;
                    do
                    {
                        temp = Random.Range(0, size);
                    } while (positionToAttack.Contains(temp));

                    positionToAttack[i] = temp;
                }
                selected = true;
            }
            if(selected && !hasAttacked && !hasWarned)
            {
                StartCoroutine(spawnWarningAttack());
            }
        }
    }

    private IEnumerator spawnWarningAttack()
    {
        for(int i = 0; i < numberOfAttack; i ++)
        {
            var attack = Instantiate(warningObject, attackPosition[positionToAttack[i]].transform.position + new Vector3(0f, 0.1f, 0f), Quaternion.identity) as GameObject;
            Destroy(attack, warningDuration);
        }
        GameObject.Find("AttackSFX").GetComponent<AttackSoundeffectManager>().warnS = true;
        hasWarned = true;
        yield return new WaitForSeconds(warningDuration - 4.5f);
        GameObject.Find("AttackSFX").GetComponent<AttackSoundeffectManager>().laserS = true;
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < numberOfAttack; i++)
        {
            attackPosition[positionToAttack[i]].SetActive(true);
            var laser = Instantiate(laserAttack, attackPosition[positionToAttack[i]].transform.position + new Vector3(0f, 26f, 0f), transform.rotation * Quaternion.Euler(90f, 0f, 0f)) as GameObject;
            Destroy(laser, attackDuration);
        }
        hasAttacked = true;
        yield return new WaitForSeconds(attackDuration);
        selected = false;
        hasAttacked = false;
        hasWarned = false;
        for (int i = 0; i < numberOfAttack; i++)
        {
            attackPosition[positionToAttack[i]].SetActive(false);
        }
    }

    public void spawnMiniRock()
    {
        for (int i = 0; i < numberOfMiniRock; i++)
        {
            int temp;
            do
            {
                temp = Random.Range(0, size);
            } while (positionToAttack.Contains(temp));

            positionToAttack[i] = temp;
        }
        StartCoroutine(rockSFX());

        for (int i = 0; i < numberOfMiniRock; i++)
        {
            var mRock = Instantiate(miniRock, attackPosition[positionToAttack[i]].transform.position + new Vector3(0f, -5f, 0f), Quaternion.identity) as GameObject;
            Destroy(mRock, warningDuration + 10f);
        }
    }

    IEnumerator rockSFX()
    {
        yield return new WaitForSeconds(3f);
        GameObject.Find("AttackSFX").GetComponent<AttackSoundeffectManager>().rock1S = true;
    }
}
