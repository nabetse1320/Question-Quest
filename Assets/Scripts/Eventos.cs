using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Eventos : MonoBehaviour
{

    public static Eventos eve;

    private void Awake()
    {
        if (eve != null && eve != this)
        {
            Destroy(this.gameObject);
            
        }
        else
        {
            eve = this;

        }
    }

    public UnityEvent Pausar;
    public UnityEvent DesPausar;
    public UnityEvent Morir;
    public UnityEvent PausarPersonaje;
    public UnityEvent DespausarPersonaje;
    public UnityEvent IniciarDialogo;
    public UnityEvent IniciarDialogo2;
    public UnityEvent EscribirPregunta;
    public UnityEvent Mostrarorbes;
    public UnityEvent<int> Recolectar;
    public UnityEvent<int> PasarNivel;
    public UnityEvent<GameObject> Seguir;
    public UnityEvent<GameObject> DejarDeSeguir;
    public UnityEvent moverPlataforma;
    public UnityEvent devolverPlataforma;
    public UnityEvent moverPlataforma2;
    public UnityEvent devolverPlataforma2;
    public UnityEvent enemigoSeva;
    public UnityEvent PlaySecuense;
    public UnityEvent Recuperarvida;



}
