using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///La grabedad del rb deve ser de 0.
///</summary>
public class TopDownController : MonoBehaviour
{
    //Este codigo esta vazado en los videos https://www.youtube.com/watch?v=j111eKN8sJw&t=2s y 
    //https://www.youtube.com/watch?v=w4YV8s9Wi3w&list=PLLTae1_1NyOOqKBz2WXeqrWRhvD0ttv5L&index=16&t=284s
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
    ///Determina el botón que activará el dash, utiliza la nomenclatura de botones de Unity.
    ///</summary>
    [SerializeField]
    private string dashButton;
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
    ///Sirve como referencia que indica hacia donde el jugador desea moverse verticalmente.
    ///</summary>
    private float moveInputVertical;
    ///<summary>
    ///Referencia al valor original de startDashTime.
    ///</summary>
    private float startingDashTime = 0;
    ///<summary>
    ///Indica si el dash se esta usando.
    ///</summary>
    private bool dashIsActive = false;
    ///<summary>
    ///La direccion a la que se esta moviendo el jugador con el dash.
    ///</summary>
    private Vector2 dashDirection = Vector2.zero;

    ///<summary>
    ///Inicializa startingDashTime.
    ///</summary>
    private void Start()    
    {
        startingDashTime = dashTime;
    }
    ///<summary>
    ///Mueve al jugador.
    ///</summary>
    private void FixedUpdate()
    {
        moveInputHorizontal = Input.GetAxisRaw("Horizontal");
        moveInputVertical = Input.GetAxisRaw("Vertical");
        if (startingDashTime == dashTime || !activateDash)
        {
            if (usesForceMovement)
            {
                rb.AddForce(new Vector2(moveInputHorizontal * speed, moveInputVertical * speed), ForceMode2D.Impulse);
            }
            else
            {
                rb.velocity = new Vector2(moveInputHorizontal * speed, moveInputVertical * speed);
            }
        }
    }
    ///<summary>
    ///Determina la direccion del dash y aplica el dash al jugador.
    ///</summary>
    private void Update()
    {
        if (activateDash)
        {
            if (!dashIsActive && Input.GetButtonDown(dashButton) && rb.velocity != Vector2.zero)
            {    
                if (rb.velocity.y > 0)
                {
                    dashDirection += Vector2.up;
                }
                if (rb.velocity.y < 0)
                {
                    dashDirection += Vector2.down;
                }
                if (rb.velocity.x < 0)
                {
                    dashDirection += Vector2.left;
                }
                if (rb.velocity.x > 0)
                {
                    dashDirection += Vector2.right;
                }
                dashIsActive = true;    
            }
            else
            {
                if (startingDashTime < 0)
                {
                    dashIsActive = false;
                    startingDashTime = dashTime;
                    dashDirection = Vector2.zero;
                    rb.velocity = Vector2.zero;
                }
                else if(dashIsActive)
                {
                    startingDashTime -= Time.deltaTime;
                    rb.velocity = dashDirection * dashSpeed;
                }
            }
        }
    }
}
