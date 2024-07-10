using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public void retirarse() 
    {
        GetComponent<Animator>().SetBool("irse", true);
    }
    private void OnEnable()
    {
        Eventos.eve.enemigoSeva.AddListener(retirarse);
    }
}
