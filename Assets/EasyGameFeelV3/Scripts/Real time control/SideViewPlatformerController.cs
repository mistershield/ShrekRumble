using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class SideViewPlatformerController : MonoBehaviour
{
    //Este codigo esta vazado en los videos https://www.youtube.com/watch?v=w4YV8s9Wi3w&list=PLLTae1_1NyOOqKBz2WXeqrWRhvD0ttv5L&index=16&t=284s
    //y https://www.youtube.com/watch?v=j111eKN8sJw&t=2s.
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
    public float DashSpeed
    {
        get
        {
            return dashSpeed;
        }
        set
        {
            dashSpeed = value;
        }
    }
    public float DashTime
    {
        get
        {
            return dashTime;
        }
        set
        {
            dashTime = value;
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
            return extreJumps;
        }
        set
        {
            extreJumps = value;
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
    public bool ActivateDash
    {
        get
        {
            return activateDash;
        }
        set
        {
            activateDash = value;
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
    public string DashButton
    {
        get
        {
            return dashButton;
        }
        set
        {
            dashButton = value;
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
    ///Determina qué tan rápido será el ”Dash” del objeto.
    ///</summary>
    [SerializeField]
    private float dashSpeed = 0;
    ///<summary>
    ///Determina la duración del “Dash”.
    ///</summary>
    [SerializeField]
    private float dashTime = 0;
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
    private int extreJumps = 0;
    ///<summary>
    ///Determina el radio del círculo que se utiliza para determinar si el objeto está tocando el suelo.
    ///</summary>
    [SerializeField]
    private float checkRadius;
    ///<summary>
    ///Determina si el objeto podrá usar el “Dash”.
    ///</summary>
    [SerializeField]
    private bool activateDash = true;
    ///<summary>
    ///Determina si el objeto utiliza velocidad o fuerza para moverse.
    ///Si se desea utilizar fuerzas, se recomienda que se modifiquen valores del rigidbody 2D como mass, linear drag, angular drag y gravity scale.
    ///</summary>
    [SerializeField]
    private bool usesForceMovement = false;
    ///<summary>
    ///Es el nombre del botón que hará que el elemento salte.
    ///</summary>
    [SerializeField]
    private string jumpButton;
    ///<summary>
    ///Determina el botón que activará el dash, utiliza la nomenclatura de botones de Unity.
    ///</summary>
    [SerializeField]
    private string dashButton;
    ///<summary>
    ///Este es el TRANSFORM del hijo vacío del objeto (la posición de los pies del avatar del jugador).
    ///</summary>
    [SerializeField]
    private Transform feetPos;
    ///<summary>
    ///El RigidBody2D del objeto.
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
    ///Determina hasia donde se movera el jugador
    ///</summary>
    [SerializeField]
    private Vector2 moveInput;

    ///<summary>
    ///Referencia al valor original de startDashTime
    ///</summary>
    private float startingDashTime = 0;
    ///<summary>
    ///Referencia al valor original de extreJumps
    ///</summary>
    private int startJumps = 0;
    ///<summary>
    ///Indica si se esta tocando el piso.
    ///</summary>
    private bool touchingFloor = true;
    ///<summary>
    ///Indica si el dash se esta usando.
    ///</summary>
    private bool dashIsActive = false;
    ///<summary>
    ///La direccion a la que se esta moviendo el jugador con el dash.
    ///</summary>
    private Vector2 dashDirection = Vector2.zero;

    ///<summary>
    ///Inicializa variables.
    ///</summary>
    private void Start()
    {
        startingDashTime = dashTime;
        startJumps = extreJumps;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    ///<summary>
    ///Mueve al jugador
    ///</summary>
    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Move");
            moveInput = context.ReadValue<Vector2>();

            rb.velocity = moveInput * speed;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            touchingFloor = Physics2D.OverlapCircle(feetPos.position, checkRadius, floor);
            if (startJumps > 0 || touchingFloor)
            {
                rb.velocity += Vector2.up * jumpHight;
            }
            if (touchingFloor)
            {
                startJumps = extreJumps;
            }
        }
    }

    ///<summary>
    ///Hace que el jugador salte, determian la direccion del dash y aplica el dash al avatar del jugador.
    ///</summary>
    private void Update()
    {
        //if (activateDash)
        //{
        //    if (!dashIsActive && Input.GetButtonDown(dashButton) && rb.velocity != Vector2.zero)
        //    {
        //        if (rb.velocity.x < 0)
        //        {
        //            dashDirection += Vector2.left;
        //        }
        //        if (rb.velocity.x > 0)
        //        {
        //            dashDirection += Vector2.right;
        //        }
        //        dashIsActive = true;
        //    }
        //    else
        //    {
        //        if (startingDashTime < 0)
        //        {
        //            dashIsActive = false;
        //            startingDashTime = dashTime;
        //            dashDirection = Vector2.zero;
        //            rb.velocity = Vector2.zero;
        //        }
        //        else if (dashIsActive)
        //        {
        //            startingDashTime -= Time.deltaTime;
        //            rb.velocity = dashDirection * dashSpeed;
        //        }
        //    }
        //}
    }
}
