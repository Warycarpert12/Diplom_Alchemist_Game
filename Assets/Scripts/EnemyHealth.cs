using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public Animator animator;
    public float afterDeathTime;

    //public PlayerProgress playerProgress;

    private void Start()
    {
        //playerProgress = FindObjectOfType<PlayerProgress>();
    }

    public bool IsAlive()
    {
        return value > 0;
    }

    public void DealDamage(float damage)
    {
        //playerProgress.AddExperience(damage);

        value -= damage;
        if (value <= 0)
        {
            EnemyDeath();
        }
        else
        {
            animator.SetTrigger("Hit");
        }
    }

    private void EnemyDeath()
    {
        animator.SetTrigger("Death");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        Invoke("DestroyMob", afterDeathTime);
    }

    public void DestroyMob()
    {
        Destroy(gameObject);
    }
}