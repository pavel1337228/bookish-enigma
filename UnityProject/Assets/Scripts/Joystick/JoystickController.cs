using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private Image _joystickBG;
    [SerializeField] private Image _joystick;

    public float Vertical, Horizontal;

    public Vector2 _input;

    private void Start()
    {
        _joystickBG = GetComponent<Image>();
        _joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBG.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / _joystickBG.rectTransform.sizeDelta.x);
            pos.y = (pos.y / _joystickBG.rectTransform.sizeDelta.y);
        }

        _input = new Vector2(pos.x * 2 - 1, pos.y * 2 - 1);
        _input = (_input.magnitude > 1f) ? _input.normalized : _input;

        _joystick.rectTransform.anchoredPosition = new Vector2(_input.x * (_joystickBG.rectTransform.sizeDelta.x / 2), _input.y * (_joystickBG.rectTransform.sizeDelta.y / 2));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _input = Vector2.zero;
        _joystick.rectTransform.anchoredPosition = Vector2.zero;
    }
}
