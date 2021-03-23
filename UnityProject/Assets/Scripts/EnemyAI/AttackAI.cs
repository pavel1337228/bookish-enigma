using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAI : MonoBehaviour
{
    [SerializeField] private float _dist;

    private EnemyAI _enemy;

    public bool Attacking;

    [SerializeField] private float _damage;

    private void Start()
    {
        _enemy = GetComponent<EnemyAI>();

        InvokeRepeating("DamageCharacter", 0f, 1f);
    }

    private void FixedUpdate()
    {
        if (_enemy.Target != null)
        {
            _dist = Vector3.Distance(_enemy.Target.position, transform.position);

            if (_dist <= 1)
            {
                Attacking = true;
            }
            else
            {
                Attacking = false;
            }
        }
    }

    private void DamageCharacter()
    {
        if (Attacking == true)
        {
            Debug.Log("Получай сука");
        }
    }
}
