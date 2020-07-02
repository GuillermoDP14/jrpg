using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool isPaused;
    public GameObject pausePanel;
    public GameObject playerPanel;
    public GameObject inventoryPanel;
    public GameObject playerParty;
    public bool usingPausePanel;
    public string mainMenu;
    

    // Start is called before the first frame update
    void Start()
    {
        playerParty = GameObject.Find("PlayerParty");
        isPaused = false;
        pausePanel.SetActive(false);
        inventoryPanel.SetActive(false);
        playerPanel.SetActive(false);
        usingPausePanel = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("pause"))
        {
            ChangePause();
        }
    }
  
    public void ChangePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            usingPausePanel = true;;
        }
        else
        {
            inventoryPanel.SetActive(false);
            playerPanel.SetActive(false);
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }



    public void QuitToMain()
	{
        SceneManager.LoadScene(mainMenu);
         Time.timeScale = 1f;

    }

    public void SwitchPlayerPanel()
    {
        usingPausePanel = !usingPausePanel;
        if(usingPausePanel)
        {
            pausePanel.SetActive(true);
            playerPanel.SetActive(false);
            playerParty.SetActive(false);
        }
        else
        {           
            playerParty.SetActive(true);
            playerPanel.SetActive(true);
            pausePanel.SetActive(false);
        }
    }

    public void SwitchInventoryPanel()
    {
        usingPausePanel = !usingPausePanel;
        if(usingPausePanel)
        {
            pausePanel.SetActive(true);
            inventoryPanel.SetActive(false);
        }
        else
        {
            inventoryPanel.SetActive(true);
            pausePanel.SetActive(false);
        }
    }
}
