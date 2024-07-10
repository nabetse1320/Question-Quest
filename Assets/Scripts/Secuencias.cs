using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Secuencias : MonoBehaviour
{
    [SerializeField] private PlayableDirector secuencia;

    private void ActivarSecuancia() 
    {
        secuencia.Play();
    }
    private void OnEnable()
    {
        Eventos.eve.PlaySecuense.AddListener(ActivarSecuancia);
    }

}
