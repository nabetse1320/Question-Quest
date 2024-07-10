using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformasMovibles : MonoBehaviour
{
    public GameObject ObjetoAmover;
    public Transform inicio;
    public Transform final;
    public float velocidad;
    private Vector3 moverHacia;

    void Start()
    {
        moverHacia = final.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObjetoAmover.transform.position = Vector3.MoveTowards(ObjetoAmover.transform.position,moverHacia,velocidad*Time.deltaTime);
        if (ObjetoAmover.transform.position==final.position)
        {
            moverHacia = inicio.position;
        }
        if (ObjetoAmover.transform.position == inicio.position)
        {
            moverHacia = final.position;
        }
    }
}
