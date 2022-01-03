using System;
using System.Collections;
using System.Collections.Generic;
using Items;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Timeline;

[RequireComponent(typeof(Enemy))]
public class EnemyController : MonoBehaviour
{

    protected Transform _target;
    protected NavMeshAgent _agent;

    protected float _damage;
    protected float _attackSpeed;
    
    [SerializeField] private EnemyData _enemyData;
    
    private void Awake()
    {
        _target = GameObject.Find("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        LoadData();
    }

    public virtual void LoadData()
    {
        _damage = _enemyData.Damage;
        _attackSpeed = _enemyData.AttackSpeed;

        GetComponent<Enemy>().LoadData(_enemyData);
    }

    private float timeToAttack = 0f;
    
    private void Update()
    {
        _agent.SetDestination(_target.position);
        var distance = Vector3.Distance(transform.position, _target.position);

        RotateToTarget();

        timeToAttack += Time.deltaTime;
        if (timeToAttack >= _attackSpeed)
        {
            Attack();
            timeToAttack = 0f;
        }
        
    }

    protected virtual void Attack()
    {
        
    }
    
    private void RotateToTarget()
    {
        Vector3 dir = _target.position - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
    
    
    
}