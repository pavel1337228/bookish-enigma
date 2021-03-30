using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private JoystickController Joystick;

    [SerializeField] private Transform _pointTransform;
    private float _horizontal, _vertical, _moveAmount;
    private Animator _anim;

    [SerializeField] private float _rotationSpeed = 0.1f;

    private Vector3 _rotationDirection;
    private Vector3 _moveDirection;

    private void Start()
    {
        _anim = GetComponent<Animator>();

        _mainPers = GameObject.FindGameObjectWithTag("MainPers");
    }

    private void FixedUpdate()
    {
        Moving();
        PlayAnimation();
        HealthBar();
    }

    public void Moving()
    {
        // для удобного теста на компе (потом убрать)
        //_vertical = Input.GetAxis("Vertical");
        //_horizontal = Input.GetAxis("Horizontal");
        //

        _vertical = Joystick._input.y;
        _horizontal = Joystick._input.x;

        if (Joystick._input.x != 0 || Joystick._input.y != 0)
        {
            Vector3 moveDir = _pointTransform.forward * _vertical;
            moveDir += _pointTransform.right * _horizontal;
            moveDir.Normalize();
            _moveDirection = moveDir;
            _rotationDirection = _pointTransform.forward;

            Rotation();
        }
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

        _anim.SetFloat("Vertical", _moveAmount);
    }

    #region HealthBar

    public Text NickName;
    public float health_player = 100f;
    public Slider healthBarPlayer;

    private GameObject _mainPers;
    public void HealthBar()
    {
        healthBarPlayer.value = health_player;

        if (health_player <= 0f)
        {
            _mainPers.SetActive(false);
        }
    }


    #endregion
}
