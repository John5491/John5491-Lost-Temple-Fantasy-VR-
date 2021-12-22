using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject controlPanel;
    public GameObject OST;

    public void StartGame()
    {
        StartCoroutine(start());
    }

    private IEnumerator start()
    {
        Camera.main.GetComponent<FadeCamera>().enabled = true;
        OST.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Debug.Log("Exited");
        Application.Quit();
    }

    public void Controls()
    {
        controlPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void Return()
    {
        mainPanel.SetActive(true);
        controlPanel.SetActive(false);
    }
}
