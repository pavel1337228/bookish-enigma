using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("target/rotation")]
    private GameObject _mainPers;
    private Transform _target;
    [SerializeField] private float _turnSpeed;

    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (_mainPers != null)
        {
            _target = _mainPers.transform;

            _anim.SetFloat("Vertical", 1);
        }
        else
        {
            _target = null;
        }

        if (_target != null)
        {
            Vector3 dir = _target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * _turnSpeed).eulerAngles;

            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainPers")
        {
            _mainPers = other.gameObject;
        }
    }
}
