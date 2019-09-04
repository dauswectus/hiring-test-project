using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageSlicing : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D tex;
    public GameObject puzzlePiecePrefab;
    private Sprite mySprite;
    List<GameObject> PuzzlePieces = new List<GameObject>();

    void Start()
    {
        for(int j=0;j<4;j++)
        {
            for (int i = 0; i < 8; i++)
            {
                mySprite = Sprite.Create(tex, new Rect(i * tex.width / 8, j * tex.height / 4, tex.width / 8, tex.height / 4), new Vector2(0.5f, 0.5f), 100.0f);
                GameObject puzzlePieceObject = (GameObject)Instantiate(puzzlePiecePrefab, transform);
                puzzlePieceObject.transform.localScale = Vector3.one;
                puzzlePieceObject.GetComponent<Image>().sprite = mySprite;
                PuzzlePieces.Add(puzzlePieceObject);
            }
        }
        int puzzleCount = PuzzlePieces.Count;
        for (int i = 0; i < puzzleCount-1; i++)
        {
            int rnd = Random.Range(0, PuzzlePieces.Count);
            PuzzlePieces[rnd].transform.SetParent(transform.GetChild(0));
            PuzzlePieces.RemoveAt(rnd);
            Debug.Log(PuzzlePieces.Count);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
