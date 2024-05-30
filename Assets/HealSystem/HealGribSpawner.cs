using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealGribSpawner : MonoBehaviour
{
    public HealMush healGribPrefab;
    private HealMush _healMush;

    public float delayMin = 10;
    public float delayMax = 15;

    private List<Transform> _spawnerPoints;

    private void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>()); 
    }

    private void Update()
    {
        if (_healMush != null) return;
        if (IsInvoking()) return;

        Invoke ("CreateHealGrib", Random.Range(delayMin, delayMax));
    }

    private void CreateHealGrib()
    {
       _healMush = Instantiate(healGribPrefab);
       _healMush.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;
    }

}
