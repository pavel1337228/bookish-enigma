using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class InteractScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> _interactableObjects = new List<GameObject>();
    private inventoryScript _invScript;
    private GameObject _mainPers;

    private bool _targFlag;

    [SerializeField] private GameObject _target;

    [SerializeField] private GameObject _currentTarget;

    private float _minDist;

    private void Start()
    {
        _invScript = GameObject.FindGameObjectWithTag("InvManager").GetComponent<inventoryScript>();
        _mainPers = GameObject.FindGameObjectWithTag("MainPers");
        _currentTarget = GameObject.FindGameObjectWithTag("podsvetka");

        _targFlag = false;
    }

    private void FixedUpdate()
    {
        ParseInteractableList();  
    }

    private void ParseInteractableList()
    {
        if (_interactableObjects.Count != 0)
        {
            if (_target != null)
            {
                _targFlag = true;
            }
            else
            {
                _targFlag = false;
            }

            if (_interactableObjects.Count == 1)
            {
                _target = _interactableObjects[0];

                _currentTarget.transform.position = _target.transform.Find("point").transform.position;
            }
            else if (_interactableObjects.Count > 1)
            {
                _minDist = Vector3.Distance(this.transform.position, _interactableObjects[0].transform.position);

                for (int i = 0; i < _interactableObjects.Count; i++)
                {
                    float distance = Vector3.Distance(this.transform.position, _interactableObjects[i].transform.position);
                    if (distance < _minDist && _target != _interactableObjects[i])
                    {
                        _minDist = distance;
                        _target = _interactableObjects[i].gameObject;
                        _currentTarget.transform.position = _target.transform.Find("point").transform.position;
                    }
                }
            }
        }
        else if (_interactableObjects.Count == 0 && _target != null)
        {
            _currentTarget.transform.position = GameObject.FindGameObjectWithTag("ItemBase").transform.position;
            _target = null;
        }
        else if (_target == null)
        {
            _currentTarget.transform.position = GameObject.FindGameObjectWithTag("ItemBase").transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Resource")
        {
            _interactableObjects.Add(other.gameObject);
        }
        else if (other.gameObject.tag == "Enemy")
        {
            if (other == other.gameObject.GetComponent<CapsuleCollider>())
            {
                _interactableObjects.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Resource")
        {
            _interactableObjects.Remove(other.gameObject);

            if (_target == other.gameObject)
            {
                _target = null;
            }
        }
        else if (other.gameObject.tag == "Enemy")
        {
            if (other == other.gameObject.GetComponent<CapsuleCollider>())
            {
                _interactableObjects.Add(other.gameObject);

                if (_target == other.gameObject)
                {
                    _target = null;
                }
            }
        }
    }
}
