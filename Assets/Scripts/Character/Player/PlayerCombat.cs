using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    

    private PlayerStats _playerStats;
    private float timeToAttack;
    


    private void Awake()
    {
        _playerStats = GetComponent<PlayerStats>();
        
    }

    private void Start()
    {
        // Instant shoot
        timeToAttack = _playerStats.AttackSpeed;
    }


    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        timeToAttack += Time.deltaTime;
        if (Input.GetButton("Fire1") && timeToAttack >= _playerStats.AttackSpeed)
        {
            Shoot();
            timeToAttack = 0f;
        }
            
    }

    private void Shoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookingDir =  mousePosition - transform.position;
        var bullet = Instantiate(_playerStats.Weapon.Bullet, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Initialize(gameObject,_playerStats.Damage,_playerStats.BulletSpeed);
        bullet.GetComponent<Bullet>().Shoot(lookingDir);
    }
}
