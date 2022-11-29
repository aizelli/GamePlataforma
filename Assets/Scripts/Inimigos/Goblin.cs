using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform ponto;

    public float velocidade;
    public float campoVisao;

    public bool emFrente;    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        EncontraJogador();
    }

    void EncontraJogador()
    {
        RaycastHit2D colisao = Physics2D.Raycast(ponto.position, Vector2.right, campoVisao);
        if (colisao.collider != null)
        {

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(ponto.position, Vector2.right * campoVisao);
    }
}
