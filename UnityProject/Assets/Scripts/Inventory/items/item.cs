using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public string ItemName;
    [Header("Weapon | Heal | Tool")]
    public string Type;
    public int Id;
    [Multiline(5)] public string ItemDescription;
    public Sprite Icon;
    public string pathPrefab;
    public bool IsStacable;
    public int Count;


    [Header("Weapon")]
    public float Damage;

    [Header("Heal")]
    public float Healing;
}
