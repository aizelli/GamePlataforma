using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private new Rigidbody2D rigidbody;

    public Transform ponto;
    public LayerMask camadaPlataforma;

    public int vida;
    public float raio;
    public float velocidade;
    public bool recebeDano;
    public bool morreu;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

    }

    private void FixedUpdate()
    {
        Direção();
        Colisão();
    }

    void Direção()
    {
        rigidbody.velocity = new Vector2(velocidade, rigidbody.velocity.y);
    }

    void Colisão()
    {
        Collider2D colisão = Physics2D.OverlapCircle(ponto.position, raio, camadaPlataforma);
        if (colisão != null)
        {
            velocidade = -velocidade;
            if (transform.eulerAngles.y == 0)
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 0);
            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(ponto.position, raio);
    }

    public void RecebeDano()
    {
        vida--;
        recebeDano = true;
        if (vida <= 0)
        {
            velocidade = 0;
            morreu = true;
            Destroy(gameObject, 1.1f);

        }
    }
}
