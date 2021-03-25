using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMobs : MonoBehaviour
{

    public GameObject[] _enemy;
    [SerializeField] private float _healthEnemy;
    public float minfloat;
    public int numberdist;

    private void FixedUpdate()
    {
        _enemy = GameObject.FindGameObjectsWithTag("Zombie");
        minfloat = 200f;
        for (int i = 0; i < _enemy.Length; i++)
        {
            if (minfloat < Vector3.Distance(this.transform.position, _enemy[i].transform.position))
            {
                continue;
            }
            else
            {
                numberdist = i;
                minfloat = Vector3.Distance(this.transform.position, _enemy[i].transform.position);
                _healthEnemy = _enemy[i].GetComponent<EnemyAI>().health;
                if (_healthEnemy <= 0f) {
                    Destroy(_enemy[i]);
                }
            }
        }

    }

}
