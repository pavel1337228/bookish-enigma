using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class HealthMobs : MonoBehaviour
{
    public GameObject enemyHealthBar;
    public Text type;
    public Text textHealth;
    public List<GameObject> _enemy = new List<GameObject>();
    [SerializeField] private float _healthEnemy;
    public float minfloat;
    public int numberdist;
    public float distanseStream = 30f;

    private void FixedUpdate()
    {
        #region Zombie UI + Health
        minfloat = 200f;

        if (_enemy.Count != 0)
        {
            
            for (int i = 0; i < _enemy.Count; i++)
            {
                if (minfloat < Vector3.Distance(this.transform.position, _enemy[i].transform.position))
                {
                    continue;
                }
                else
                {
                    numberdist = i;
                    minfloat = Vector3.Distance(this.transform.position, _enemy[i].transform.position);
                    _healthEnemy = _enemy[i].GetComponent<Enemy>().Health;

                    if (_healthEnemy <= 0f)
                    {
                        Destroy(_enemy[i]);
                    }
                }
            }
        }

        if (minfloat <= 10f)
        {
            enemyHealthBar.GetComponent<Slider>().value = _healthEnemy;
            switch (_enemy[numberdist].tag)
            {
                case "Enemy":
                    type.text = _enemy[numberdist].GetComponent<Enemy>().Name;
                    break;
            }
            textHealth.text = "" + _healthEnemy;
            enemyHealthBar.SetActive(true);
        }
        else
        {
            enemyHealthBar.SetActive(false);
        }
        #endregion

        for (int i = 0; i < _enemy.Count; i++)
        {
            if (Vector3.Distance(this.transform.position, _enemy[i].transform.position) >= distanseStream)
            {
                for (int j = 0; j < _enemy[i].transform.childCount; j++)
                {
                    var child = _enemy[i].transform.GetChild(j).gameObject;
                    if (child != null)
                        child.SetActive(false);
                }
            }
            else
            {
                for (int j = 0; j < _enemy[i].transform.childCount; j++)
                {
                    var child = _enemy[i].transform.GetChild(j).gameObject;
                    if (child != null)
                        child.SetActive(true);
                }
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            _enemy.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            _enemy.Remove(other.gameObject);
        }
    }
}
