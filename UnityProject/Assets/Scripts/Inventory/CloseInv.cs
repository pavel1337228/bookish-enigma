using UnityEngine;
using UnityEngine.EventSystems;

public class CloseInv : MonoBehaviour, IPointerDownHandler
{
    private GameObject _button;
    private GameObject _ui;

    private void Start()
    {
        _button = GameObject.FindGameObjectWithTag("inventory");
        _ui = GameObject.FindGameObjectWithTag("ui");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _button.SetActive(false);
        _ui.SetActive(true);
    }
}
