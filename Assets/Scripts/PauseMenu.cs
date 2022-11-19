using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject ui;
    [SerializeField] TextMeshProUGUI resumeText;
    [SerializeField] GameObject buttonHolder;
    
    void Start(){
        ui.SetActive(false);
        resumeText.gameObject.SetActive(false);
    }
    
    public void Pause(){
        ui.SetActive(true);
        buttonHolder.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume(int totalTime = 3)
    {
        buttonHolder.SetActive(false);
        resumeText.gameObject.SetActive(true);
        StartCoroutine(Resuming(totalTime));
    }

    IEnumerator Resuming(int totalTime)
    {
        //Animation for the text
        for (int i = 0; i < totalTime; i++)
        {
            resumeText.text = (totalTime - i).ToString();
            yield return new WaitForSeconds(1);
        }
        yield return null;
        
        //Resume Time
        resumeText.gameObject.SetActive(false);
        ui.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnQuit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
