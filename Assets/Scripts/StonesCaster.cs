using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonesCaster: MonoBehaviour
{
    public List<GameObject> Stones = new List<GameObject>();

    public Transform stoneSourceTransform;

    public float force = 10;

    private void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
       Cursor.visible = false;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var stoneToSpawn = Stones[Random.Range(0, Stones.Count)];

            var spawnedStone = Instantiate(stoneToSpawn);
            spawnedStone.transform.position = stoneSourceTransform.position;
            spawnedStone.GetComponent<Rigidbody>().AddForce(stoneSourceTransform.forward * force);
        }
    }
}
