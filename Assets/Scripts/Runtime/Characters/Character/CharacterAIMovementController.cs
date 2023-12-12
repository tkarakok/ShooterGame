using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class CharacterAIMovementController : MonoBehaviour, ICharacterAIMovement
{
    protected CharacterHealthController _characterHealthController;
    
    protected NavMeshAgent _agent;
    protected Transform _target;
    
    public virtual  void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _characterHealthController = GetComponent<CharacterHealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void Stop()
    {
        _agent.isStopped = true;
    }

    public void Move()
    {
        if (!_target && !_agent.isStopped ) return;
        if (_characterHealthController.IsDead) return;
        _agent.SetDestination(_target.position);
    }
}
