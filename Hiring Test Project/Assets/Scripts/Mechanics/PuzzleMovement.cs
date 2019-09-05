using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleMovement : MonoBehaviour
{
    private int puzzlePlacementNumber;
    public int puzzleNumber;
    private Transform parentPanel;
    // Start is called before the first frame update
    void Start()
    {
        parentPanel = transform.parent;
        if (transform.name != "Blank")
        {
            GetComponent<Button>().onClick.AddListener(MovePuzzle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void MovePuzzle()
    {
        puzzlePlacementNumber = transform.GetSiblingIndex();

        if (puzzlePlacementNumber > 0 && parentPanel.GetChild(puzzlePlacementNumber - 1).name == "Blank") //Before
        {
              transform.SetSiblingIndex(puzzlePlacementNumber - 1);
            CheckIfOver();
        }

        else if (puzzlePlacementNumber + 1 < parentPanel.childCount && parentPanel.GetChild(puzzlePlacementNumber + 1).name == "Blank") //After
        {
            transform.SetSiblingIndex(puzzlePlacementNumber + 1);
            CheckIfOver();
        }

        else if (puzzlePlacementNumber + 8 < parentPanel.childCount && parentPanel.GetChild(puzzlePlacementNumber + 8).name == "Blank" ) //Below
        {
            transform.SetSiblingIndex(puzzlePlacementNumber + 8);
            parentPanel.GetChild(puzzlePlacementNumber + 7).SetSiblingIndex(puzzlePlacementNumber);
            CheckIfOver();
        }
        else if (puzzlePlacementNumber - 8 < parentPanel.childCount && parentPanel.GetChild(puzzlePlacementNumber - 8).name == "Blank") //Above
        {
            transform.SetSiblingIndex(puzzlePlacementNumber - 7);
            parentPanel.GetChild(puzzlePlacementNumber - 8).SetSiblingIndex(puzzlePlacementNumber);
            CheckIfOver();
        }
        else
        {
            Debug.Log("Bad movement!");
        }
    }
    public void CheckIfOver()
    {

        for(int i = 0; i < parentPanel.childCount; i++)
        {
            Debug.Log(parentPanel.GetChild(i).name);
            if(parentPanel.GetChild(i).name == "Blank" || parentPanel.GetChild(i).GetComponent<PuzzleMovement>().puzzleNumber == i)
            {
                if((parentPanel.GetChild(i).GetComponent<PuzzleMovement>().puzzleNumber == 31 && i == 31) || (parentPanel.GetChild(i).name == "Blank" && i == 31))
                {
                    Debug.Log("You win!");
                }
            }
            else
            {
                Debug.Log("Not yet!");
                break;
            }

        }
    }
}
