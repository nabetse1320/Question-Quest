using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaDeslizante2 : MonoBehaviour
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
    }

    private void OnEnable()
    {
        Eventos.eve.moverPlataforma2.AddListener(ActivarPlataforma);
        Eventos.eve.devolverPlataforma2.AddListener(DesactivarPlataforma);
    }
}
