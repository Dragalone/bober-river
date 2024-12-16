using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverMapGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public List<GameObject> riverPrefabs;
    private List<GameObject> rivers = new List<GameObject>();
    public float maxSpeed = 6;
    private float speed = 0;
    public int maxRiverCount = 5;
    
    void Start()
    {
        ResetLevel();
        StartLevel();
    }

    private void StartLevel()
    {
        speed = maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (speed ==  0)
        {
            return;
        }

/*       foreach (GameObject river in rivers)
        {
            river.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }*/

        if (rivers[0].transform.position.z < - 30f)
        {
            Destroy(rivers[0]);
            rivers.RemoveAt(0);

            CreateNextRiver();
        }
    }



    public void ResetLevel()
    {
        speed = 0;
        while(rivers.Count > 0)
        {
            Destroy(rivers[0]);
            rivers.RemoveAt(0);
        }
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


}
