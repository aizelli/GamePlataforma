using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform ponto;
    public LayerMask camadaInimigo;

    public float direção;
    public float velocidade;
    public float forçaPulo;
    public float raio;
    public int vida;

    public bool podePular;
    public bool puloDuplo;
    public bool atacando;
    public bool recebeDano;
    public bool morreu;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Direção();
        Pulo();
        Ataque();
    }

    private void FixedUpdate()
    {
        Mover();
    }

    void Direção()
    {
        direção = Input.GetAxis("Horizontal");
    }

    void Mover()
    {
        rb.velocity = new Vector2(velocidade * direção, rb.velocity.y);
    }

    void Pulo()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (podePular)
            {
                rb.AddForce(new Vector2(0, 1) * forçaPulo, ForceMode2D.Impulse);
                podePular = false;
                puloDuplo = true;
            }
            else if (puloDuplo)
            {
                rb.AddForce(new Vector2(0, 1) * forçaPulo, ForceMode2D.Impulse);
                puloDuplo = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            podePular = false;
        }
    }

    void Ataque()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            atacando = true;
            Collider2D colisão = Physics2D.OverlapCircle(ponto.position, raio, camadaInimigo);
            
            if (colisão != null)
            {
                colisão.GetComponent<Slime>().RecebeDano();
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            atacando = false;
        }

    }

    void RecebeAtque()
    {
        vida--;
        recebeDano = true;
        if (vida <= 0)
        {
            velocidade = 0;
            morreu = true;

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(ponto.position, raio);
    }

    private void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.layer == 6)
        {
            podePular = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.layer == 3)
        {
            RecebeAtque();
        }
    }
}
