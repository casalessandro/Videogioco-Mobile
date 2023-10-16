using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento : MonoBehaviour
{
  private float movimentoVelocita = 4f;
   public FixedJoystick joystick;
   private Rigidbody2D rb;
   private Vector2 movimentoDirezione;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movimentoDirezione = new Vector2(joystick.Horizontal,joystick.Vertical);
    }

    void FixedUpdate(){
        rb.velocity = movimentoDirezione * movimentoVelocita;
    }
}
