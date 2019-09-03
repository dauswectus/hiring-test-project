using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiButtonBehaviour : MonoBehaviour
{
    public Dictionary<int, GameObject> ButtonNames = new Dictionary<int, GameObject>();
    GameObject buttonPanel;


    void Start()
    {
        buttonPanel = transform.GetChild(0).gameObject;

        NameButtons();
    }

    void NameButtons()
    {
        for (int i = 0; buttonPanel.transform.childCount > i; i++)
        {
            if (!ButtonNames.ContainsKey(i))
            {
                ButtonNames.Add(i, buttonPanel.transform.GetChild(i).gameObject); //Store Gameobjects
                Debug.Log(i + ", " + buttonPanel.transform.GetChild(i).gameObject);
            }
        }
        int j = 0;
        foreach (KeyValuePair<int, GameObject> kvp in ButtonNames)
        {
            if (kvp.Value.name == buttonPanel.transform.GetChild(j).transform.name)
            {
                buttonPanel.transform.GetChild(j).GetChild(0).GetComponent<Text>().text = kvp.Value.name; //Change button text based on gameobject names
            }
            j++;
        }
    }
  
}
