using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyController : MonoBehaviour
{
    [SerializeField] protected SO_Enemies _enemyInfo;


    protected EnemyState.State _currentState;
    protected NavMeshAgent _agent;
    protected Transform _player;
    protected HealthSystem _healthSystem;



    protected virtual void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _agent.speed = _enemyInfo._speed;
        _healthSystem = GetComponent<HealthSystem>();
    }
    protected bool CanSeePlayer()
    {
        return Vector3.Distance(transform.position, _player.position) < _enemyInfo._triggerDistance;
    }

    protected void CheckPlayer()
    {
        if (CanSeePlayer())
        {
            _currentState = EnemyState.State.Attack;
        }
    }

    protected virtual void Update()
    {
        CheckPlayer();

        switch (_currentState)
        {
            case EnemyState.State.Patrol:
                Patrol();
                break;

            case EnemyState.State.Attack:
                Attack();
                break;
        }
    }

    protected abstract void Patrol();
    protected abstract void Attack();
}
