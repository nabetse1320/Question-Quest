using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject Conejo;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Conejo.transform.position.x;
        position.y = Conejo.transform.position.y;
        transform.position = position;
    }
}
