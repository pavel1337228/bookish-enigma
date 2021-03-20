using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private CharacterStatus _characterStatus;

    [SerializeField] private Transform _rayStep;

    private Animator _anim;

    private float _horizontal, _vertical, _run, _moveAmount;

    [SerializeField] private bool _climb = false;
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
        //StartClimb();
    }

    public void Moving()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");
        _run = Input.GetAxis("Run");

        if (_characterStatus.IsGrounded)
        {
            Vector3 moveDir = _cameraTransform.forward * _vertical;
            moveDir += _cameraTransform.right * _horizontal;
            moveDir.Normalize();
            _moveDirection = moveDir;
            _rotationDirection = _cameraTransform.forward;

            Rotation();
        }
        _characterStatus.IsGrounded = IsGrounded();
        //_characterStatus.IsClimbing = IsClimbing();
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

    //public void StartClimb()
    //{
    //    if (_characterStatus.IsClimbing == true)
    //    {
    //        if (Input.GetKeyDown(KeyCode.E))
    //        {
    //            _climb = true;
    //        }
    //    }
    //}

    public bool IsGrounded()
    {
        Vector3 origin = _rayStep.transform.position;
        Vector3 dir = -Vector3.up;

        Vector3 checkClimbing = _rayStep.transform.position;
        Vector3 checkDis = Vector3.forward;

        float distance = 1.5f;
        float checkDistance = 0.2f;

        RaycastHit hit;
        RaycastHit checkHit;
        if (Physics.Raycast(origin, dir, out hit, distance))
        {
            if (Physics.Raycast(checkClimbing, checkDis, out checkHit, checkDistance))
            {
                if (checkHit.distance >= checkDistance)
                {
                    if ((hit.distance >= 0.6f) && (hit.distance <= 0.99f))
                    {
                        Vector3 Lift = transform.position;
                        Lift.y = hit.point.y;
                        transform.position = Lift;
                    }
                }
            }
            return true;
        }
        return false;
    }

    //public bool IsClimbing()
    //{
    //    Vector3 checkClimbing = _rayStep.transform.position;
    //    Vector3 checkDis = Vector3.forward;
    //    float checkDistance = 0.5f;

    //    RaycastHit checkHit;

    //    if (Physics.Raycast(checkClimbing, checkDis, out checkHit, checkDistance))
    //    {
    //        if (checkHit.distance <= checkDistance)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    public void PlayAnimation()
    {
        _moveAmount = Mathf.Clamp01(Mathf.Abs(_vertical) + Mathf.Abs(_horizontal)) + _run * 1;

        _anim.SetFloat("Vertical", _moveAmount);
        _anim.SetBool("Climbing", _climb);

    }
}
