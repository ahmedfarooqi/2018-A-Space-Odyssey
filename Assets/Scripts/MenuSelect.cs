using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuSelect : MonoBehaviour
{
    public GameObject shipComponent0;
    public GameObject shipComponent1;
    public GameObject shipComponent2;

    public GameObject menuScreen;
    public GameObject tutorial;
    public GameObject laser;
    public bool isPaused;
    public bool isTutorial;
    public Button top, middle, bottom;

    // Use this for initialization
    void Start ()
    {
        isPaused = false;
        isTutorial = false;
        top.onClick.AddListener(Resume);
        middle.onClick.AddListener(Tutorial);
        bottom.onClick.AddListener(Quit);
        
    }
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            //Debug.Log("Pressed start");
            PauseScreen();
        }
        laser.SetActive(isPaused);
        menuScreen.SetActive(isPaused);
        tutorial.SetActive(isTutorial);
        if (isPaused)
        {
            Time.timeScale = 0.0f;
        } 
        else
        {
            Time.timeScale = 1.0f;
        }

        if (OVRInput.GetUp(OVRInput.Button.One))
        {
            if (isTutorial)
            {
                isTutorial = false;
                shipComponent0.SetActive(true);
                shipComponent1.SetActive(true);
                shipComponent2.SetActive(true);
            }
            else
            {
                EventSystem.current.SetSelectedGameObject(null);
            }
        }
    }
    
    public void PauseScreen()
    {
        if (isTutorial)
        {
            isTutorial = false;
            shipComponent0.SetActive(true);
            shipComponent1.SetActive(true);
            shipComponent2.SetActive(true);
        }
        isPaused = !isPaused;
    }

    public void Resume()
    {
        isPaused = false;
    }

    public void Tutorial()
    {
        isPaused = false;
        isTutorial = true;
        shipComponent0.SetActive(false);
        shipComponent1.SetActive(false);
        shipComponent2.SetActive(false);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

   
}
