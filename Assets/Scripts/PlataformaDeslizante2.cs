using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaDeslizante : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject plataformaAmover;
    private void ActivarPlataforma() 
    {
        plataformaAmover.GetComponent<Animator>().SetBool("deslizar",true);
    }
    private void DesactivarPlataforma()
    {
        plataformaAmover.GetComponent<Animator>().SetBool("deslizar", false);
        Debug.Log("aaaa");
    }

    private void OnEnable()
    {
        Eventos.eve.moverPlataforma.AddListener(ActivarPlataforma);
        Eventos.eve.devolverPlataforma.AddListener(DesactivarPlataforma);
    }
}
