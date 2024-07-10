using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    public GameObject Objeto;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;   
        position = Objeto.transform.position;
        transform.position = position;
  
    }
}
