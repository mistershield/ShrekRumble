using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideViewRunerController : MonoBehaviour
{
    //Este codigo esta vazado en el codigo del video https://www.youtube.com/watch?v=j111eKN8sJw&t=2s.
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
    public float JumpHight
    {
        get
        {
            return jumpHight;
        }
        set
        {
            jumpHight = value;
        }
    }
    public int ExtraJumps
    {
        get
        {
            return extraJumps;
        }
        set
        {
            extraJumps = value;
        }
    }
    public float DuckingSpeed
    {
        get
        {
            return duckingSpeed;
        }
        set
        {
            duckingSpeed = value;
        }
    }
    public float ImpulsionForce
    {
        get
        {
            return impulsionForce;
        }
        set
        {
            impulsionForce = value;
        }
    }
    public float CheckRadius
    {
        get
        {
            return checkRadius;
        }
        set
        {
            checkRadius = value;
        }
    }
    public string JumpButton
    {
        get
        {
            return jumpButton;
        }
        set
        {
            jumpButton = value;
        }
    }
    public string DuckButton
    {
        get
        {
            return duckButton;
        }
        set
        {
            duckButton = value;
        }
    }
    public Transform FeetPos
    {
        get
        {
            return feetPos;
        }
        set
        {
            feetPos = value;
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
    public LayerMask Floor
    {
        get
        {
            return floor;
        }
        set
        {
            floor = value;
        }
    }

    ///<summary>
    ///Determina qué tan rápido se moverá el objeto.
    ///</summary>
    [SerializeField]
    private float speed = 0;
    ///<summary>
    ///Determina la altura de los saltos del objeto.
    ///</summary>
    [SerializeField]
    private float jumpHight = 0;
    ///<summary>
    ///Determina cuántos saltos extra podrá realizar el objeto antes de tener que tocar el suelo 
    ///(por default el objeto puede saltar una vez, si el valor de la variable ExtraJumps es 1 entonces el objeto podrá saltar 2 veces).
    ///</summary>
    [SerializeField]
    private int extraJumps = 0;
    ///<summary>
    ///Determina qué tan rápido se moverá hacia abajo el objeto.
    ///</summary>
    [SerializeField]
    private float duckingSpeed = 0;
    ///<summary>
    ///Determina la fuerza que está empujando constantemente al objeto 
    ///(si esta es positiva el objeto será empujado hacia la derecha de lo contrario será empujado a la izquierda).
    ///</summary>
    [SerializeField]
    private float impulsionForce = 0;
    ///<summary>
    ///Determina el radio del círculo que se utiliza para determinar si el objeto está tocando el suelo.
    ///</summary>
    [SerializeField]
    private float checkRadius;
    ///<summary>
    ///Es el nombre del botón que hará que el elemento salte.
    ///</summary>
    [SerializeField]
    private string jumpButton;
    ///<summary>
    ///Es el nombre del botón que hará que el elemento se mueva hacia abajo.
    ///</summary>
    [SerializeField]
    private string duckButton;
    ///<summary>
    ///Este es el TRANSFORM del hijo vacío del objeto (la posición de los pies del avatar del jugador).
    ///</summary>
    [SerializeField]
    private Transform feetPos;
    ///<summary>
    ///Este es el RigidBody2D del objeto.
    ///</summary>
    [SerializeField]
    private Rigidbody2D rb;
    ///<summary>
    ///Esta es una LayerMask la cual determina los objetos considerados suelo. Los saltos del objeto sólo se reiniciarán cuando el círculo, 
    ///cuyo centro es el hijo vacío del objeto, se sobreponga a un objeto que esté en la misma capa que el valor de la variable Floor.
    ///</summary>
    [SerializeField]
    private LayerMask floor;

    ///<summary>
    ///Referencia al valor original de extreJumps
    ///</summary>
    private int startJumps = 0;
    ///<summary>
    ///Indica si se esta tocando el piso.
    ///</summary>
    private bool touchingFloor = true;

    ///<summary>
    ///Inicializa startJumps.
    ///</summary>
    private void Start()
    {
        startJumps = extraJumps;
    }
    ///<summary>
    ///Empuja al jugador hacia la direccion indicada por impulsionForce y determina si el jugador esta tocando el piso.
    ///</summary>
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(impulsionForce * speed, rb.velocity.y);
        touchingFloor = Physics2D.OverlapCircle(feetPos.position, checkRadius, floor);
    }
    ///<summary>
    ///Hace que el jugador salte y hace que se mueva hacia abajo cuando se preciona la tecla S.
    ///</summary>
    private void Update()
    {
        if (Input.GetButtonDown(jumpButton) && (startJumps > 0 || touchingFloor))
        {
            rb.velocity += Vector2.up * jumpHight;
            startJumps -= 1;
        }
        if (touchingFloor)
        {
            startJumps = extraJumps;
        }
        if (Input.GetButtonDown(duckButton))
        {
            rb.velocity = Vector2.up * (-1 * duckingSpeed);
        }
    }
}
