using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMobs : MonoBehaviour
{
    public GameObject enemyHealthBar;
    public Text type;
    public Text textHealth;
    public GameObject[] _enemy;
    [SerializeField] private float _healthEnemy;
    public float minfloat;
    public int numberdist;


    private void FixedUpdate()
    {


        #region Zombie UI + Health
        _enemy = GameObject.FindGameObjectsWithTag("Zombie");
        minfloat = 200f;
        for (int i = 0; i < _enemy.Length; i++)
        {
            if (minfloat < Vector3.Distance(this.transform.position, _enemy[i].transform.position))
            {
                continue;
            }
            else
            {
                numberdist = i;
                minfloat = Vector3.Distance(this.transform.position, _enemy[i].transform.position);
                _healthEnemy = _enemy[i].GetComponent<EnemyAI>().health;
                if (_healthEnemy <= 0f) {
                    Destroy(_enemy[i]);
                }
            }
        }

        if (minfloat <= 10f)
        {
            enemyHealthBar.GetComponent<Slider>().value = _healthEnemy;
            switch (_enemy[numberdist].tag)
            {
                case "Zombie":type.text = "Зомби";
                break;
            }
            textHealth.text = ""+(_healthEnemy * 100);
            enemyHealthBar.SetActive(true);
        }
        else
        {
            enemyHealthBar.SetActive(false);
        }
        #endregion

        for (int i = 0; i < _enemy.Length; i++)
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

    public float distanseStream = 25f;
}
