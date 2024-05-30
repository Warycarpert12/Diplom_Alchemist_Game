using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Animator animator;
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle;
    public float damage = 20;
    public float attackDistance = 1f;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private PlayerHealth _playerHealth;
    private EnemyHealth _enemyHealth;

    public bool IsAlive()
    {
        return _enemyHealth.IsAlive();
    }

    private void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
        _enemyHealth = GetComponent<EnemyHealth>();

        if (_navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component is missing.");
            return;
        }

        // Принудительное размещение агента на NavMesh
        NavMeshHit hit;
        if (NavMesh.SamplePosition(transform.position, out hit, 1.0f, NavMesh.AllAreas))
        {
            _navMeshAgent.Warp(hit.position);
            Debug.Log("NavMeshAgent is placed on NavMesh.");
        }
        else
        {
            Debug.LogError("NavMeshAgent is not on a NavMesh.");
        }
    }

    private void Update()
    {
        if (_navMeshAgent != null && _navMeshAgent.isOnNavMesh)
        {
            NoticePlayerUpdate();
            ChaseUpdate();
            AttackUpdate();
            PatrolUpdate();
        }
        else
        {
            Debug.LogWarning("NavMeshAgent is either null or not on NavMesh.");
        }
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent != null && _navMeshAgent.isOnNavMesh && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                animator.SetTrigger("Attack");
            }
        }
    }

    public void AttackDamage()
    {
        if (!_isPlayerNoticed) return;
        if (_navMeshAgent != null && _navMeshAgent.isOnNavMesh && _navMeshAgent.remainingDistance <= (_navMeshAgent.stoppingDistance + attackDistance))
        {
            _playerHealth.DealDamage(damage);
        }
    }

    private void NoticePlayerUpdate()
    {
        _isPlayerNoticed = false;
        if (!_playerHealth.IsAlive()) return;

        var direction = player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + new Vector3(0, 0.8f, 0.6f), direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent != null && _navMeshAgent.isOnNavMesh && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
    }

    private void PickNewPatrolPoint()
    {
        if (_navMeshAgent != null && _navMeshAgent.isOnNavMesh)
        {
            _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
        }
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent != null && _navMeshAgent.isOnNavMesh)
            {
                _navMeshAgent.destination = player.transform.position;
            }
        }
    }
}


