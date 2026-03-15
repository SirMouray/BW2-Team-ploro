using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKamikaze : EnemyController
{
    [SerializeField] protected Transform[] _patrolPoints;

    protected int _arrIndex;

    protected override void Start()
    {
        base.Start();
        _currentState = EnemyState.State.Patrol;
        _agent.SetDestination(_patrolPoints[_arrIndex].position);
    }
    protected override void Attack()
    {
        _agent.speed = _enemyInfo._attackSpeed;
        _agent.SetDestination(_player.position);
    }

    protected override void Patrol()
    {
        if(!_agent.pathPending && _agent.remainingDistance < 1)
        {
            _arrIndex = (_arrIndex +1)%_patrolPoints.Length;
            _agent.SetDestination(_patrolPoints[_arrIndex].position);
        }
    }
}
