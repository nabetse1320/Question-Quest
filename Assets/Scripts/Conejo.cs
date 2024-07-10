using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Conejo : MonoBehaviour
{
    public static Conejo conejo;

    public GameObject barraDeVida;
    public int Health = 5;
    private string HealtPrefsName = "Healt";

    public GameObject escena;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private float Horizontal_J;
    public float Speed;
    public float JumpForce;
    private bool Grounded;
    private float ScaleX;
    private float ScaleY;
    private CapsuleCollider2D Collider;
    public float RaycastSize;
    private bool paused;
    private Vector2 RealScale;

    private void Awake()
    {
        LoadData();
        
    }

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Collider = GetComponent<CapsuleCollider2D>();
        Animator = GetComponent<Animator>();
        ScaleX = gameObject.transform.localScale.x;
        ScaleY = gameObject.transform.localScale.y;
    }

    void Update()
    {
        if (!paused)
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Horizontal_J = Input.GetAxisRaw("Horizontal_J");

            if (Horizontal < 0.0f || Horizontal_J < 0.0f) transform.localScale = new Vector3(-ScaleX, ScaleY, 1);
            else if (Horizontal > 0.0f || Horizontal_J > 0.0f) transform.localScale = new Vector3(ScaleX, ScaleY, 1);

            Estados();
            Caer();


            if (Input.GetKeyDown(KeyCode.W) && Grounded || Input.GetKeyDown(KeyCode.Joystick1Button2) && Grounded)
            {
                Jump();
            }

            if (Health == 0)
            {
                Health = 5;
                Eventos.eve.PasarNivel.Invoke(6);

            }

            if (Health < 5)
            {
                int n = (Health - 5) * (-1);
                StartCoroutine(DescontarVida(n));
            }
        }
        else {
            Horizontal = 0;
            Grounded= false;
            Estados() ;
        }
    } 
    private void FixedUpdate() 
    {
        if (!paused)
        {
            Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
        }
        else
        {
            Rigidbody2D.velocity = new Vector2(0,0);
        }
        
    }

    private void Jump() 
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
        
    }

    public void LowerLife() {
        Health = Health - 1;
        Invoke("Camb", 3);
    }

    private void OnDestroy()
    {
        SaveData();
    }

    private void SaveData() { 
        PlayerPrefs.SetInt(HealtPrefsName, Health);
    }
    private void LoadData() {
        Health = PlayerPrefs.GetInt(HealtPrefsName);
    }

    private void Caer() {
        
        Grounded = (Physics2D.Raycast(Collider.transform.position, Vector3.down,((int)Collider.size.y)/RaycastSize));
        
    }

    private void Estados() {
        if (Horizontal != 0.0f && Grounded)
        {
            Animator.SetBool("running", true);
            Animator.SetBool("falling", false);
            Animator.SetBool("goingUp", false);
        }
        else
        {
            Animator.SetBool("running", false);
            Animator.SetBool("falling", false);
            Animator.SetBool("goingUp", false);
        }
        if (!Grounded && Rigidbody2D.velocity.y > 0)
        {
            Animator.SetBool("running", false);
            Animator.SetBool("falling", false);
            Animator.SetBool("goingUp", true);
        }
        if (!Grounded && Rigidbody2D.velocity.y < 0)
        {
            Animator.SetBool("running", false);
            Animator.SetBool("falling", true);
            Animator.SetBool("goingUp", false);

        }
        

    }
    private void Camb()
    {
        escena.GetComponent<cambiarNivel>().LoadNextScene(escena.GetComponent<cambiarNivel>().SceneSig - 1);
    }

    public IEnumerator DescontarVida(int v)
    {
        for (int i = 0; i < v; i++)
        {
            barraDeVida.transform.GetChild(i).gameObject.GetComponent<Animator>().SetBool("LoseLive", true);
            yield return new WaitForSeconds(0.5f);
            barraDeVida.transform.GetChild(i).gameObject.SetActive(false);
            
        }
        
    }
    private void Pausar() { 
        paused = true;
    }
    private void Despausar()
    {
        paused = false;
    }
    public void Restaurarvida() 
    {
        Health = 5;
    }

    private void OnEnable()
    {
        Eventos.eve.Morir.AddListener(LowerLife);
        Eventos.eve.PausarPersonaje.AddListener(Pausar);
        Eventos.eve.DespausarPersonaje.AddListener(Despausar);
        Eventos.eve.Seguir.AddListener(moveWith);
        Eventos.eve.DejarDeSeguir.AddListener(OnMoveWith);
        Eventos.eve.Recuperarvida.AddListener(Restaurarvida);

    }

    private void moveWith(GameObject collider) 
    {
        transform.parent = collider.transform;

    }
    private void OnMoveWith(GameObject collider)
    {
        transform.parent = null;
    }
}
