using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageSlicing : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D tex;
    public GameObject puzzlePiecePrefab;
    private int puzzleNumber;
    private Sprite mySprite;
    public bool debugMode;
    public List<GameObject> PuzzlePieces = new List<GameObject>();

    void Start()
    {
        puzzleNumber = 0;
        Transform parentPanel = transform.GetChild(0);
        for(int j=3;j >= 0; j--)
        {
            for (int i = 0; i < 8; i++)
            {
                mySprite = Sprite.Create(tex, new Rect(i * tex.width / 8, j * tex.height / 4, tex.width / 8, tex.height / 4), new Vector2(0.5f, 0.5f), 100.0f);
                GameObject puzzlePieceObject = (GameObject)Instantiate(puzzlePiecePrefab,/* parentPanel,*/ transform);
                puzzlePieceObject.transform.localScale = Vector3.one;
                puzzlePieceObject.GetComponent<Image>().sprite = mySprite;
                puzzlePieceObject.AddComponent<PuzzleMovement>();
                puzzlePieceObject.GetComponent<PuzzleMovement>().puzzleNumber = puzzleNumber;
                puzzlePieceObject.name = "" + puzzleNumber;
                puzzlePieceObject.AddComponent<Button>();
                PuzzlePieces.Add(puzzlePieceObject);
                puzzleNumber++;
            }
        }
        int puzzleCount = PuzzlePieces.Count;
       for (int i = 0; i < puzzleCount-1; i++)
        {
            int rnd = Random.Range(0, PuzzlePieces.Count);
            PuzzlePieces[rnd].transform.SetParent(parentPanel);
            PuzzlePieces.RemoveAt(rnd);
            Debug.Log(PuzzlePieces.Count);
        }
        Debug.Log(PuzzlePieces[0].name);
        GameObject BlankPiece = (GameObject)Instantiate(puzzlePiecePrefab, parentPanel);
        BlankPiece.transform.localScale = Vector3.one;
        BlankPiece.AddComponent<PuzzleMovement>();
        BlankPiece.name = "Blank";

    }

    void SliceImage()
    {

    }
}
