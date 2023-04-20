using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject HealthBar;
    public GameObject Character;
    public GameObject pauseOption;
    public static bool isPaused;
    public static bool inPOptions;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        pauseOption.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
               

            }
            else
            {
                PauseGame();
                

            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        HealthBar.SetActive(false);
        Character.GetComponent<FirstPersonController>().enabled = false;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        HealthBar.SetActive(true);
        Character.GetComponent<FirstPersonController>().enabled = true;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
        isPaused = false;
    }

    public void pOptions()
    {
        pauseMenu.SetActive(false);
        pauseOption.SetActive(true);
        Time.timeScale = 0f;
        inPOptions = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        HealthBar.SetActive(false);
        Character.GetComponent<FirstPersonController>().enabled = false;
    }
    public void OutpOptions()
    {
        pauseMenu.SetActive(true);
        pauseOption.SetActive(false);
        Time.timeScale = 0f;
        inPOptions = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        HealthBar.SetActive(false);
        Character.GetComponent<FirstPersonController>().enabled = false;
    }



}
