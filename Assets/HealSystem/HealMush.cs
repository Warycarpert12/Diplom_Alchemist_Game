using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealMush : MonoBehaviour
{
    public float healAmount;

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.AddHealth(healAmount);
            Destroy(gameObject);
        }

    }
}
