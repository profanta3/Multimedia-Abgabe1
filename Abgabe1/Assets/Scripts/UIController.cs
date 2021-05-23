using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Transform canvas;

    public bool MenuState { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
        MenuState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MenuState)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
    }

    public void Restart()
    {
        if (MenuState)
        {
            SceneManager.LoadScene(0);
            MenuState = false;
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Return()
    {
        if (MenuState)
        {
            CloseMenu();
        }
    }

    public void CloseMenu()
    {
        MenuState = false;
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenMenu()
    {
        MenuState = true;
        canvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
