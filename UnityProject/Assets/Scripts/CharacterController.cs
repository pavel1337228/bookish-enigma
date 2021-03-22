using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Transform _pointTransform;
    //[SerializeField] private Rigidbody _playerTransform;
    private float _horizontal, _vertical, _moveAmount;
    private Animator _anim;

    [SerializeField] private float _rotationSpeed = 0.1f;

    private Vector3 _rotationDirection;
    private Vector3 _moveDirection;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Moving();
        PlayAnimation();
    }

    [SerializeField] private float _multiplayerz = 0f;
    [SerializeField] private float _multiplayerx = 0f;

    //private void FixedUpdate()
    //{
    //    _vertical = Input.GetAxis("Vertical");
    //    _horizontal = Input.GetAxis("Horizontal");

    //    _multiplayerz = Mathf.Lerp(0.2f, Mathf.Abs(_vertical), 50f * Time.deltaTime);
    //    _multiplayerx = Mathf.Lerp(0.2f, Mathf.Abs(_horizontal), 50f * Time.deltaTime);
    //    //_playerTransform.drag = Mathf.Lerp(3f, 2.5f * Mathf.Abs(_vertical), 20f *_vertical * Time.deltaTime);


    //    if ((Mathf.Abs(_vertical) > 0f) & (Mathf.Abs(_horizontal) > 0f))
    //    {
    //        _playerTransform.AddForce(Vector3.forward * _vertical * Time.deltaTime * (_multiplayerz / 1.35f));
    //        _playerTransform.AddForce(Vector3.right * _horizontal * Time.deltaTime * (_multiplayerx / 1.35f));
    //    }
    //    else
    //    {
    //        _playerTransform.AddForce(Vector3.forward * _vertical * Time.deltaTime * _multiplayerz);
    //        _playerTransform.AddForce(Vector3.right * _horizontal * Time.deltaTime * _multiplayerx);
    //    }

    //}

    public void Moving()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");

    

        Vector3 moveDir = _pointTransform.forward * _vertical;
        moveDir += _pointTransform.right * _horizontal;
        moveDir.Normalize();
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

    public void PlayAnimation()
    {
        _moveAmount = Mathf.Clamp01(Mathf.Abs(_vertical) + Mathf.Abs(_horizontal));
        //+_run * 1

        _anim.SetFloat("Vertical", _moveAmount);
    }
}
