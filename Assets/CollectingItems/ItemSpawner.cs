using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject> Items = new List<GameObject>();

    public int itemsMaxCount = 6;
    public float delayMin = 5;
    public float delayMax = 10;

    private List<Transform> _spawnerPoints;

    public static ItemSpawner instance;

    private void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
    }

    private void Update()
    {
        if (IsInvoking()) return;
        
        Invoke("CreateItem", Random.Range(delayMin, delayMax));
    }

    private void CreateItem()
    {
        

        var itemToSpawn = Items[Random.Range(0, Items.Count)];

        var spawnedItem = Instantiate(itemToSpawn);
        spawnedItem.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;
    }
}
