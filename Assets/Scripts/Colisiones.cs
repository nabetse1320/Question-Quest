using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisiones : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            Eventos.eve.Morir?.Invoke();
        }

        if (collision.CompareTag("Dialogos"))
        {
            Eventos.eve.IniciarDialogo?.Invoke();
        }

        if (collision.CompareTag("Dialogos2"))
        {
            Eventos.eve.IniciarDialogo2?.Invoke();
        }

        if (collision.CompareTag("Orbes"))
        {
            Eventos.eve.Recolectar.Invoke(collision.gameObject.GetComponent<Recolectar>().id);
        }
        if (collision.CompareTag("PasarNivel"))
        {
            Eventos.eve.PasarNivel.Invoke(collision.gameObject.GetComponent<cambiarNivel>().SceneSig);
        }
        if (collision.CompareTag("Interruptor"))
        {
            collision.GetComponent<Animator>().SetBool("activado", true);
            Eventos.eve.moverPlataforma.Invoke();
        }
        if (collision.CompareTag("Interruptor2"))
        {
            collision.GetComponent<Animator>().SetBool("activado", true);
            Eventos.eve.moverPlataforma2.Invoke();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interruptor"))
        {
            Eventos.eve.devolverPlataforma.Invoke();
            collision.GetComponent<Animator>().SetBool("activado",false);
        }
        if (collision.CompareTag("Interruptor2"))
        {
            Eventos.eve.devolverPlataforma2.Invoke();
            collision.GetComponent<Animator>().SetBool("activado", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Plataforma")
        {
            
            Eventos.eve.Seguir.Invoke(collision.gameObject);

        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataforma")
        {
            Eventos.eve.DejarDeSeguir.Invoke(collision.gameObject);
            
        }
    }
}
