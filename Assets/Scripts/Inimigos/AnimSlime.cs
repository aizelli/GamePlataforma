using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSlime : MonoBehaviour
{
    public Animator animador;
    private Slime slime;
    // Start is called before the first frame update
    void Start()
    {
        slime = FindObjectOfType<Slime>();
    }

    // Update is called once per frame
    void Update()
    {
        Ação();
    }

    void Ação()
    {
        if (slime.recebeDano)
        {
            animador.SetTrigger("Dano");
        }

        if (slime.morreu)
        {
            animador.SetTrigger("Morto");
        }
    }

    private void fimAnimDano()
    {
        slime.recebeDano = false;
    }
}
