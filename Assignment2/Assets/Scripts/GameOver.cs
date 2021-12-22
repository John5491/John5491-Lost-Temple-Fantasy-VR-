using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;

    public void EndGame()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(endGame());
        }
    }

    private IEnumerator endGame()
    {
        GameObject.Find("XR Rig").GetComponent<WarpSpeed>().activeWarp();
        yield return new WaitForSeconds(0.1f);
    }
}
