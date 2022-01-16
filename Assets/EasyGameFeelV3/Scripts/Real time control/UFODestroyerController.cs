using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///La grabedad del rb deve ser de 0.
///</summary>
public class UFODestroyerController : MonoBehaviour
{
    //Este codigo esta vazado en el codigo del video https://www.youtube.com/watch?v=j111eKN8sJw&t=2s
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
    public bool UsesForceMovement
    {
        get
        {
            return usesForceMovement;
        }
        set
        {
            usesForceMovement = value;
        }
    }
    public Rigidbody2D Rb
    {
        get
        {
            return rb;
        }
        set
        {
            rb = value;
        }
    }

    ///<summary>
    ///Determina qué tan rápido se moverá el objeto.
    ///</summary>
    [SerializeField]
    private float speed = 0;
    ///<summary>
    ///Determina si el objeto utiliza velocidad o fuerza para moverse.
    ///Si se desea utilizar fuerzas, se recomienda que se modifiquen valores del rigidbody 2D como mass, linear drag, angular drag y gravity scale.
    ///</summary>
    [SerializeField]
    private bool usesForceMovement = false;
    ///<summary>
    ///El RigidBody2D del objeto.
    ///</summary>
    [SerializeField]
    private Rigidbody2D rb;

    ///<summary>
    ///Sirve como referencia que indica hacia donde el jugador desea moverse horizontalmente.
    ///</summary>
    private float moveInputHorizontal;

    ///<summary>
    ///Mueve al jugador.
    ///</summary>
    private void FixedUpdate()
    {
        moveInputHorizontal = Input.GetAxisRaw("Horizontal");

        if (usesForceMovement)
        {
            rb.AddForce(new Vector2(moveInputHorizontal * speed, 0), ForceMode2D.Impulse);
        }
        else
        {
            rb.velocity = new Vector2(moveInputHorizontal * speed, rb.velocity.y);
        }
    }
}
