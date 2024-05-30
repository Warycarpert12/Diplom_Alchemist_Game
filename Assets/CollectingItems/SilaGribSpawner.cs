using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilaGribSpawner : MonoBehaviour
{
    public GameObject SilaGribPrefab;
    private GameObject _SilaMush;

    public float delayMin = 10;
    public float delayMax = 15;

    public List<Transform> _spawnerPoints;


    private void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
    }

    private void Update()
    {
        if (_SilaMush != null) return;
        if (IsInvoking()) return;

        Invoke("CreateHealGrib", Random.Range(delayMin, delayMax));
    }

    private void CreateHealGrib()
    {
        _SilaMush = Instantiate(SilaGribPrefab);
        _SilaMush.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;
    }

}
