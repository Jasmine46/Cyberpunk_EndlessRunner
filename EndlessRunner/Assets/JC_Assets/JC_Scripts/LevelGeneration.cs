using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGeneration : MonoBehaviour
{
    // List of Spawnable GameObjects
    private List<GameObject> mLS_GO_Level = new List<GameObject>();
    private List<int> mLS_IN_Level = new List<int>();
    private int mIN_MaxLevelParts;
    private GameObject[] mOBJ_tempList;

    private void Awake()
    {
        LoadLevelBlocks("JC_Prefabs");
    }

    // Use this for initialization
    private void Start()
    {
        AssignLevelPart();
        SpawnLevel();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    // Load levels from the selected folder Inside the Resource folder.
    private void LoadLevelBlocks(string vST_FolderName)
    {
        // Folder JC_Prefabs.
        mOBJ_tempList = Resources.LoadAll<GameObject>(vST_FolderName);
        mIN_MaxLevelParts = mOBJ_tempList.Length;

        // Double check if the Objects are being loaded.
        foreach (GameObject tGO_Block in mOBJ_tempList)
        {
            if (tGO_Block == null)
            {
                Debug.Log("LevelGeneration: No GameObject Loaded from Prefab folder");
            }

            else
            {
                Debug.Log("LevelGeneration: Name of Loaded GameObject: " + tGO_Block.name);
            }
        }

        Debug.Log("LevelGeneration: Loaded: " + mIN_MaxLevelParts + " Level Parts");
    }

    // Randomly generate the level parts.
    private void RandomLevelGen()
    {
        for (int i = 0; i < mIN_MaxLevelParts; i++)
        {
            int RandomPart = Random.Range(0, mIN_MaxLevelParts);

            mLS_IN_Level.Add(RandomPart);

            Debug.Log("LevelGeneration: Added Part: " + RandomPart);
        }

        Debug.Log("LevelGeneration: Amounts of part added: " + mLS_IN_Level.Count);
    }

    // Assigns the correct GameObject depending on what level parts are supposed to be spawned from the resulting mLS_IN_Level.
    private void AssignLevelPart()
    {
        RandomLevelGen();

        foreach (var levelNo in mLS_IN_Level)
        {
            for (int i = 0; i < mIN_MaxLevelParts; i++)
            {
                if (levelNo == i)
                {
                    foreach (var LevelPartGO in mOBJ_tempList)
                    {
                        // Depending on the integer, it will load a different type of level part.
                        if (LevelPartGO.name.Contains(i.ToString()))
                        {
                            mLS_GO_Level.Add(LevelPartGO);

                            Debug.Log("LevelGeneration: Added Level: " + LevelPartGO.name);
                        }
                    }
                }
            }
        }
    }

    private void SpawnLevel()
    {
        Transform tGO_LevelPart;
        float tFL_OffsetX;
        //float tFL_OffsetZ;

        for (int i = 0; i < mLS_GO_Level.Count; i++)
        {
            tGO_LevelPart = mLS_GO_Level[i].GetComponentInChildren<Transform>();

            if (tGO_LevelPart == null)
            {
                Debug.Log("LevelGeneration: No Box Collider 2D Found");
            }

            else
            {
                Debug.Log("LevelGeneration: Box Collider 2D Found!");
                Debug.Log("LevelGeneration: Box Collider 2D size: " + tGO_LevelPart.name + " " + tGO_LevelPart.lossyScale.x);
            }

            //tFL_OffsetX = (tGO_LevelPart.bounds.size.x / 2) * i; //mLS_GO_Level[i].transform.localScale.x;
            //tFL_OffsetZ = tCL_LevelPart.bounds.size.z;//mLS_GO_Level[i].transform.localScale.x;
            //Vector3 tV3_SpawnPoint = new Vector3(tFL_OffsetX * i, 1, 0);

            //Debug.Log("LevelGeneration: Level Part Lenght: " + tFL_OffsetX + " i: " + i);

            //Instantiate(mLS_GO_Level[i], tV3_SpawnPoint, transform.rotation);
            //Debug.Log("LevelGeneration: Level Part spawned at: " + tV3_SpawnPoint + " i: " + i);
        }
    }
}


