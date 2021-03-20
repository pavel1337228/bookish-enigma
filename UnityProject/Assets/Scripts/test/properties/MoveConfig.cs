﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MoveConfig")]
public class MoveConfig : ScriptableObject
{
    public bool VisibleCursor;
    public float MovementSpeed;
    public float RunSpeed;
    public float AngularSpeed;
    public float Gravity;
    public float JumpForce;
}
