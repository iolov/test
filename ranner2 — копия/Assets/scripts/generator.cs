using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class generator : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    private List<GameObject> prefabsList = new List<GameObject>();
    [SerializeField]float spPos;
    [SerializeField]float preLenf;
    [SerializeField] Transform player;
    [SerializeField]private int StaptPref;

    private void Start()
    {
        SpawnPref(0,0);
        SpawnPref(0,0);
        SpawnPref(0,0);
        for (int i = 0; i < StaptPref; i++)
        {
            SpawnPref(Random.Range(0,prefabs.Length),0);
        }
    }

    void FixedUpdate()
    {
        if (player.position.z> spPos - (StaptPref * preLenf))
        {
            SpawnPref(Random.Range(1, prefabs.Length),1);
            delPref();
        }
    }
    void SpawnPref(int Ind,byte cum)
    {
        DataHolder.ScenScore+=cum;
        GameObject nextPref = Instantiate(prefabs[Ind],transform.forward*spPos,Quaternion.identity);
        prefabsList.Add(nextPref);
        spPos += preLenf;
    }
    private void delPref()
    {
        Destroy(prefabsList[0]);
        prefabsList.RemoveAt(0);
    }
}
