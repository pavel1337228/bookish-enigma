﻿using UnityEngine;
using UnityEngine.EventSystems;


public class OpenInv : MonoBehaviour, IPointerDownHandler
{
    private GameObject _button;
    private GameObject _ui;
    

    private void Start()
    {
        _button = GameObject.FindGameObjectWithTag("inventory");
        _ui = GameObject.FindGameObjectWithTag("ui");
        _button.SetActive(false);
        _ui.SetActive(true);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _button.SetActive(true);
        _ui.SetActive(false);
    }
}
