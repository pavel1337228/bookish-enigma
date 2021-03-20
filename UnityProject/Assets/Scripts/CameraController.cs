using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject eye;
    public float transformx;
    public float transformz;

    private void Start()
    {
        //Camera.main.transform.position = new Vector3(eye.transform.position.x, 10, eye.transform.position.z);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Mathf.Lerp
        float x; float z;
        x = Mathf.Lerp(Camera.main.transform.position.x, eye.transform.position.x + transformx, 2f * Time.deltaTime);
        z = Mathf.Lerp(Camera.main.transform.position.z, eye.transform.position.z + transformz, 2f * Time.deltaTime);
        Camera.main.transform.position = new Vector3(x, 10, z);
    }
}
