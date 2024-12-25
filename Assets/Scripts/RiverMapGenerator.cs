using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverMapGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public List<GameObject> riverPrefabs;
    public GameObject riverWallsPrefab;
    private List<GameObject> rivers = new List<GameObject>();
    private List<GameObject> riverWalls = new List<GameObject>();
    public int maxRiverCount = 10;
    
    void Start()
    {
        ResetLevel();
        StartLevel();
    }

    private void StartLevel()
    {
  
    }

    // Update is called once per frame
    void Update()
    {

        if (rivers[0].transform.position.z < - 30f)
        {
            Destroy(rivers[0]);
            rivers.RemoveAt(0);

            CreateNextRiver();
        }
    }



    public void ResetLevel()
    {
        while(rivers.Count > 0)
        {
            Destroy(rivers[0]);
            rivers.RemoveAt(0);
        }
        CreateRiverWalls();
        for (int i = 0; i < maxRiverCount; i++)
        {
            CreateNextRiver();
        }

    }

    private void CreateNextRiver()
    {
        Vector3 pos = Vector3.zero;
        if (rivers.Count > 0)
        {
            pos = rivers[rivers.Count - 1].transform.position + new Vector3(0, 0, 30f);
        }
        int randomIndex = UnityEngine.Random.Range(0, riverPrefabs.Count);
        GameObject  river = Instantiate(riverPrefabs[randomIndex], pos, Quaternion.identity);
        river.transform.SetParent(transform);
        rivers.Add(river);
    }

    private void CreateRiverWalls()
    {

        for (int i = 0; i < maxRiverCount; i++)
        {
            Vector3 pos = Vector3.zero;
            if (riverWalls.Count > 0)
            {
                pos = riverWalls[riverWalls.Count - 1].transform.position + new Vector3(0, 0, 30f);
            }
            GameObject walls = Instantiate(riverWallsPrefab, pos, Quaternion.identity);
            walls.transform.SetParent(transform);
            riverWalls.Add(walls);
        }
    }


}
