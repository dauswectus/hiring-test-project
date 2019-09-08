using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    void Start()
    {
        transform.GetChild(0).GetComponent<Text>().text = transform.name;
        switch (transform.name)
        {
            case "Restart":
                GetComponent<Button>().onClick.AddListener(StartGame);
                break;
            case "Exit":
                GetComponent<Button>().onClick.AddListener(ExitGame);
                break;
            default:
                break;
        }

    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    void ExitGame()
    {
        Application.Quit();
    }
}
