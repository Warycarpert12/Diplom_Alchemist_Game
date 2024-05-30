using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorshevikSpawner : MonoBehaviour
{
    public GameObject BorshevikPrefab;
    private GameObject _borshevik;

    public float delayMin = 10;
    public float delayMax = 15;

    public List<Transform> _spawnerPoints;

    private void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
    }

    private void Update()
    {
        if (_borshevik != null) return;
        if (IsInvoking()) return;

        Invoke("CreateHealGrib", Random.Range(delayMin, delayMax));
    }

    private void CreateHealGrib()
    {
        _borshevik = Instantiate(BorshevikPrefab);
        _borshevik.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;
    }

}
