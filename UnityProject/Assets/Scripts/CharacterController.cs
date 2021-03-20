using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Transform _pointTransform;
    private float _horizontal, _vertical;

    [SerializeField] private float _rotationSpeed = 0.1f;

    private Vector3 _rotationDirection;
    private Vector3 _moveDirection;

    private void Update()
    {
        Moving();
    }

    public void Moving()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");

        Vector3 moveDir = _pointTransform.forward * _vertical;
        moveDir += _pointTransform.right * _horizontal;
        moveDir.Normalize();
        transform.Translate(moveDir * Time.deltaTime);
        _moveDirection = moveDir;
        _rotationDirection = _pointTransform.forward;

        Rotation();
    }

    public void Rotation()
    {
        _rotationDirection = _moveDirection;

        Vector3 targetDir = _rotationDirection;
        targetDir.y = 0;

        if (targetDir == Vector3.zero)
        {
            targetDir = transform.forward;
        }

        Quaternion lookDir = Quaternion.LookRotation(targetDir);
        Quaternion targetRot = Quaternion.Slerp(transform.rotation, lookDir, _rotationSpeed);
        transform.rotation = targetRot;
    }
}
