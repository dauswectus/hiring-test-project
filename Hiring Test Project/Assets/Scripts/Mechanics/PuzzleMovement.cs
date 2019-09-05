using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleMovement : MonoBehaviour
{
    private int puzzleNumber;
    private Transform parentPanel;
    // Start is called before the first frame update
    void Start()
    {
        parentPanel = transform.parent;
        GetComponent<Button>().onClick.AddListener(MovePuzzle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MovePuzzle()
    {
        puzzleNumber = transform.GetSiblingIndex();

        if (puzzleNumber > 0 && parentPanel.GetChild(puzzleNumber - 1).name == "Blank") //Before
        {
              transform.SetSiblingIndex(puzzleNumber - 1);
        }

        else if (puzzleNumber + 1 < parentPanel.childCount && parentPanel.GetChild(puzzleNumber + 1).name == "Blank") //After
        {
            transform.SetSiblingIndex(puzzleNumber + 1);
        }

        else if (puzzleNumber + 8 < parentPanel.childCount && parentPanel.GetChild(puzzleNumber + 8).name == "Blank" ) //Below
        {
            transform.SetSiblingIndex(puzzleNumber + 8);
            parentPanel.GetChild(puzzleNumber + 7).SetSiblingIndex(puzzleNumber);
        }
        else if (puzzleNumber - 8 < parentPanel.childCount && parentPanel.GetChild(puzzleNumber - 8).name == "Blank") //Above
        {
            transform.SetSiblingIndex(puzzleNumber - 7);
            parentPanel.GetChild(puzzleNumber - 8).SetSiblingIndex(puzzleNumber);
        }
        else
        {
            Debug.Log("Index Out of Bounds");
        }
       
    }
}
