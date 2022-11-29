using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimJogador : MonoBehaviour
{
    public Animator animador;
    private Jogador jogador;

    void Start()
    {
        jogador = FindObjectOfType<Jogador>();  
    }

    void Update()
    {
        Mover();
    }

    void Mover()
    {
        if(jogador.direção != 0)
        {
            animador.SetInteger("Transição", 1);
        }
        else
        {
            animador.SetInteger("Transição", 0);
        }

        if(jogador.direção > 0)
        {
            jogador.transform.eulerAngles = new Vector2(0, 0);
        }

        if (jogador.direção < 0)
        {
            jogador.transform.eulerAngles = new Vector2(0, 180);
        }

        if (!jogador.podePular)
        {
            animador.SetInteger("Transição", 2);
        }

        if (jogador.atacando)
        {
            animador.SetInteger("Transição", 3);
        }

        if (jogador.recebeDano)
        {
            animador.SetTrigger("RecebeDano");
            jogador.recebeDano = false;
        }

        if (jogador.morreu)
        {
            animador.SetTrigger("Morreu");
            jogador.morreu = false;
        }
    }
}
