using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchPadController : MonoBehaviour
{
    public Button sinistraButton;
    public Button destraButton;
    public float velocitaMovimento = 5f;
    public Rigidbody2D rb; // Riferimento al Rigidbody del personaggio

    private bool muoviSinistra;
    private bool muoviDestra;

    private void Start()
    {
        // Aggiungi gestori per i pulsanti
        sinistraButton.onClick.AddListener(() => MuoviSinistra());
        destraButton.onClick.AddListener(() => MuoviDestra());
    }

    private void Update()
    {
        // Controlla il movimento del personaggio
        if (muoviSinistra)
        {
            MuoviPersonaggio(-1f);
        }
        else if (muoviDestra)
        {
            MuoviPersonaggio(1f);
        }
    }

    public void MuoviPersonaggio(float direzione)
    {
        Vector2 movimento = new Vector2(direzione * velocitaMovimento, rb.velocity.y);
        rb.velocity = movimento;
    }

    public void MuoviSinistra()
    {
        muoviSinistra = true;
        muoviDestra = false;
    }

    public void MuoviDestra()
    {
        muoviDestra = true;
        muoviSinistra = false;
    }

    public void RilasciaTastoSinistra()
    {
        muoviSinistra = false;
    }

    public void RilasciaTastoDestra()
    {
        muoviDestra = false;
    }
}