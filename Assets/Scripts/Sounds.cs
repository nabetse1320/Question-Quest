using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private float volumen;

    // Start is called before the first frame update
    private void bajarSonido() 
    {

        GetComponent<AudioSource>().volume = volumen;
    }
}
