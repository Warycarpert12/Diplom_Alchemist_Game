using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyhomorSpawner : MonoBehaviour
{
    public GameObject MyhomorPrefab;
    private GameObject _myhomor;

    public float delayMin = 10;
    public float delayMax = 15;

    public List<Transform> _spawnerPoints;

    private void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
    }

    private void Update()
    {
        if (_myhomor != null) return;
        if (IsInvoking()) return;

        Invoke("CreateHealGrib", Random.Range(delayMin, delayMax));
    }

    private void CreateHealGrib()
    {
        _myhomor = Instantiate(MyhomorPrefab);
        _myhomor.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;
    }

}
