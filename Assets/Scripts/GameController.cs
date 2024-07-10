using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameController : MonoBehaviour
{

    [SerializeField] private Canvas Interfaz;


    public void Paused() 
    {
        Time.timeScale = 0;
        Eventos.eve.PausarPersonaje.Invoke();
        Interfaz.transform.GetChild(0).gameObject.SetActive(false);
        Interfaz.transform.GetChild(1).gameObject.SetActive(true);
    }
    public void UnPaused() 
    {
        Time.timeScale = 1;
        Eventos.eve.DespausarPersonaje.Invoke();
        Interfaz.transform.GetChild(0).gameObject.SetActive(true);
        Interfaz.transform.GetChild(1).gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Eventos.eve.Pausar.AddListener(Paused);
        Eventos.eve.DesPausar.AddListener(UnPaused);
    }
}
