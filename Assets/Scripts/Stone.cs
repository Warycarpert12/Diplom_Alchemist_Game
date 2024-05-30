using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public float damage = 20;
    public float lifeTime;
    public AudioSource PebbleCollision;
     

    void Start()
    {
        Invoke("DestroyStone", lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        SoundEffect();

    }

    public void SoundEffect()
    {
        
         
        //if (GetComponent<SoundToggleInPause>()._soundVolume == true)
        {
            //Debug.Log("SoundWorks");
            PebbleCollision.Play();
        }
    }

    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
            DestroyStone();
        }

        //DestroyStone();
    }

    private void DestroyStone()
    {
        Destroy(gameObject);
    }
}
