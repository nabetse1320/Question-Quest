using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Orbes : MonoBehaviour
{
    public TextMeshPro Respuesta;
    public GameObject Retenedor;
    public void mostrarOrbes()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }



    public void tomarOrbe(int orb) {

        if (!transform.GetChild(orb).gameObject.GetComponentInChildren<Recolectar>().correcta)
        {
            Eventos.eve.Morir.Invoke();
            Respuesta.SetText("¡¡RESPUESTA INCORRECTA!!");
        }
        else
        {
            Retenedor.SetActive(false);
            Respuesta.SetText("¡¡RESPUESTA CORRECTA!!");
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponentInChildren<Animator>().SetBool("borrar", true);
            Destroy(gameObject, 0.5f);
        }
        
        
    }

    private void OnEnable()
    {
        Eventos.eve.IniciarDialogo.AddListener(mostrarOrbes);
        Eventos.eve.Recolectar.AddListener(tomarOrbe);
    }
}
