using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour
{
    public float Force
    {
        get
        {
            return force;
        }
        set
        {
            force = value;
        }
    }
    public float ObjectWide
    {
        get
        {
            return objectWide;
        }
        set
        {
            objectWide = value;
        }
    }
    public string PushButton
    {
        get
        {
            return pushButton;
        }
        set
        {
            pushButton = value;
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
    public GameObject Player
    {
        get
        {
            return player;
        }
        set
        {
            player = value;
        }
    }

    ///<summary>
    ///Determina la fuerza con que se empujara el objeto.
    ///</summary>
    [SerializeField]
    private float force;
    ///<summary>
    ///Indica el ancho del objeto.
    ///</summary>
    [SerializeField]
    private float objectWide;
    ///<summary>
    ///Determina el botón que activará el dash, utiliza la nomenclatura de botones de Unity.
    ///</summary>
    [SerializeField]
    private string pushButton;
    ///<summary>
    ///El RigidBody2D del objeto.
    ///</summary>
    [SerializeField]
    private Rigidbody2D rb;
    ///<summary>
    ///Este es el GameObject Player, es una referencia al objeto jugador del juego. Se utiliza para determinar si se puede empujar el objeto empujable,
    ///si el objeto que colisionó al objeto empujable es igual a esta variable y el botón de empujado es presionado, el objeto será empujado.
    ///</summary>
    [SerializeField]
    private GameObject player;

    ///<summary>
    ///Indica el estado del objeto.
    ///</summary>
    private string state;

    ///<summary>
    ///Aplica la fuerza de empuje al objeto y lo hace kinematico cuando su velosidad es 0; 
    ///</summary>
    private void Update()
    {
        if (Input.GetButton(pushButton))
        {
            rb.isKinematic = false;
            if (state == "left")
            {
                rb.velocity = Vector2.right * force;
            }
            if (state == "right")
            {
                rb.velocity = Vector2.left * force;
            }
            if (state == "up")
            {
                rb.velocity = Vector2.down * force;
            }
            if (state == "down")
            {
                rb.velocity = Vector2.up * force;
            }
            state = null;
        }
        if(rb.velocity == Vector2.zero)
        {
            rb.isKinematic = true;
        }
    }
    ///<summary>
    ///Determina la direccion en que se empujara el objeto.
    ///</summary>
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == player) {
            Vector2 tmpVector = collision.gameObject.transform.position;
            if (tmpVector.y <= transform.position.y && tmpVector.x <= transform.position.x + (objectWide / 2) && tmpVector.x >= transform.position.x - (objectWide / 2))
            {
                state = "down";
            }
            else if (tmpVector.y >= transform.position.y && tmpVector.x <= transform.position.x + (objectWide / 2) && tmpVector.x >= transform.position.x - (objectWide / 2))
            {
                state = "up";
            }
            else if(tmpVector.x <= transform.position.x)
            {
                state = "left";
            }   
            else if(tmpVector.x >= transform.position.x)
            {
                state = "right";
            }
        }
    }
    ///<summary>
    ///Restablece a "" a state cuando se termina una colision.
    ///</summary>
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (rb.velocity == Vector2.zero)
        {
            state = "";
        }
    }
}
