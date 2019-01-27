using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public static LevelGenerator instance;
    // All level pieces blueprints used to copy from
    public List<LevelPiece> levelPrefabs = new List<LevelPiece>();
    // Starting point of the very frst level piece
    public Transform levelStartPoint;
    // All level pieces tat are currently in the level
    public List<LevelPiece> pieces = new List<LevelPiece>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateInitialPieces();
    }


    public void GenerateInitialPieces()
    {
        for (int i = 0; i < 2; i++)
        {
            AddPiece();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        instance = this;
    }

    public void AddPiece()
    {
        // Pick random number 
        int randomIndex = Random.Range(0, levelPrefabs.Count);

        // Instantiate copy of random level prefab and store it in the pieces variable
        LevelPiece piece = (LevelPiece) Instantiate(levelPrefabs[randomIndex]);
        piece.transform.SetParent(this.transform, false);

        Vector3 spawnPosition = Vector3.zero;

        if (pieces.Count == 0)
        {
            spawnPosition = levelStartPoint.position;
        }
        else
        {
            spawnPosition = pieces[pieces.Count - 1].exitPoint.position;
        }

        piece.transform.position = spawnPosition;
        pieces.Add(piece);

    }

    public void RemoveOldestPiece()
    {
        LevelPiece oldestPiece = pieces[0];
        pieces.Remove(oldestPiece);
        Destroy(oldestPiece.gameObject);
    }
}
