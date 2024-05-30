using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyarishnikSpawner : MonoBehaviour
{
    public GameObject BoyarishnikPrefab;
    private GameObject _boyarishnik;

    public float delayMin = 10;
    public float delayMax = 15;

    public List<Transform> _spawnerPoints;

    private void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
    }

    private void Update()
    {
        if (_boyarishnik != null) return;
        if (IsInvoking()) return;

        Invoke("CreateHealGrib", Random.Range(delayMin, delayMax));
    }

    private void CreateHealGrib()
    {
        _boyarishnik = Instantiate(BoyarishnikPrefab);
        _boyarishnik.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;
    }

}
