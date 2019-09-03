using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    void Start ()
    {
        switch (transform.name)
        {
            case "Start":
                GetComponent<Button>().onClick.AddListener(StartGame);
                break;
            case "Options":
                GetComponent<Button>().onClick.AddListener(SetOptions);
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
        Debug.Log("1");
    }
    void SetOptions()
    {
        Debug.Log("2");
    }
    void ExitGame()
    {
        Debug.Log("3");
    }

}
