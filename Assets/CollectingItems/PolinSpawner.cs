using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolinSpawner : MonoBehaviour
{
    public GameObject PolinPrefab;
    private GameObject _polinFlower;

    public float delayMin = 10;
    public float delayMax = 15;

    public List<Transform> _spawnerPoints;

    private void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
    }

    private void Update()
    {
        if (_polinFlower != null) return;
        if (IsInvoking()) return;

        Invoke("CreateHealGrib", Random.Range(delayMin, delayMax));
    }

    private void CreateHealGrib()
    {
        _polinFlower = Instantiate(PolinPrefab);
        _polinFlower.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;
    }

}
