using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;

    private NavMeshAgent _agent;
    private Transform _target;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        PickNewPoint();
        Move();
    }

    private void Update()
    {
        if (_agent.remainingDistance < _agent.stoppingDistance)
        {
            PickNewPoint();
            Move();
        }
    }

    public void Move()
    {
        _agent.SetDestination(_target.position);
    }

    public void PickNewPoint()
    {
        _target = _points[Random.Range(0, _points.Count)];
    }
}
