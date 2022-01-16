using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public bool IsForPlayer
    {
        get
        {
            return isForPlayer;
        }
        set
        {
            isForPlayer = value;
        }
    }
    public float Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }
    public string AttackButton
    {
        get
        {
            return attackButton;
        }
        set
        {
            attackButton = value;
        }
    }
    public float SwingSpeed
    {
        get
        {
            return swingSpeed;
        }
        set
        {
            swingSpeed = value;
        }
    }
    public float ReturnSpeed
    {
        get
        {
            return returnSpeed;
        }
        set
        {
            returnSpeed = value;
        }
    }
    public float SwingAngle
    {
        get
        {
            return swingAngle;
        }
        set
        {
            swingAngle = value;
        }
    }
    public float AttackRate
    {
        get
        {
            return attackRate;
        }
        set
        {
            attackRate = value;
        }
    }
    public AudioSource AudioSource
    {
        get
        {
            return audioSource;
        }
        set
        {
            audioSource = value;
        }
    }
    public AudioClip AttackSound
    {
        get
        {
            return attackSound;
        }
        set
        {
            attackSound = value;
        }
    }

    ///<summary>
    ///Determina si el arma será utilizada por el jugador o por NPCs.
    ///</summary>
    [SerializeField]
    private bool isForPlayer;
    ///<summary>
    ///Determina el daño que puede causar el arma.
    ///</summary>
    [SerializeField]
    private float damage;
    ///<summary>
    ///Es el nombre del botón que hará que el arma ataque.
    ///</summary>
    [SerializeField]
    private string attackButton;
    ///<summary>
    ///Determina qué tan rápido rotará el arma.
    ///</summary>
    [SerializeField]
    private float swingSpeed;
    ///<summary>
    ///Determina qué tan rápido el arma rotará a su ángulo original.
    ///</summary>
    [SerializeField]
    private float returnSpeed;
    ///<summary>
    ///Determina el ángulo que abarcará el ataque del arma.
    ///</summary>
    [SerializeField]
    private float swingAngle;
    ///<summary>
    ///Determina qué tan rápido ataca el arma.
    ///</summary>
    [SerializeField]
    private float attackRate;
    ///<summary>
    ///El AudioSource del arma.
    ///</summary>
    [SerializeField]
    private AudioSource audioSource;
    ///<summary>
    ///Este es un AudioClip que es reproducido cada vez que el arma hace un ataque.
    ///</summary>
    [SerializeField]
    private AudioClip attackSound;

    ///<summary>
    ///La velocidad actual que se esta utilizando para mover el arma.
    ///</summary>
    private float currentSpeed;
    ///<summary>
    ///Indica si el arma esta atacando.
    ///</summary>
    private bool attacking = false;
    ///<summary>
    ///Indica si el arma puede atacar.
    ///</summary>
    private bool canAttack = true;
    ///<summary>
    ///Indica si el arma esta siendo usada por un NPC.
    ///</summary>
    private bool npcAttacking;
    ///<summary>
    ///El vector rotacion original del arma.
    ///</summary>
    private Quaternion originalRotation;
    ///<summary>
    ///La rotacion a la que se desea llegar al hacer un ataque.
    ///</summary>
    private Quaternion targetAttackRotation;
    ///<summary>
    ///La rotacion a la que se desea llegar actualmente.
    ///</summary>
    private Quaternion currenttargetRotation;
    ///<summary>
    ///La rotacion a la que se desea llegar actualmente.
    ///</summary>
    private Collider2D meleeWeaponCollider;

    ///<summary>
    ///Inicializa variables.
    ///</summary>
    private void Start()
    {
        originalRotation = transform.rotation;
        targetAttackRotation = Quaternion.Euler(0, 0, swingAngle);
        currenttargetRotation = targetAttackRotation;
        if (gameObject.GetComponent<Collider2D>())
        {
            meleeWeaponCollider = gameObject.GetComponent<Collider2D>();
            meleeWeaponCollider.enabled = false;
        }
    }
    ///<summary>
    ///Hase que el arma se mueva para realizar su ataque, cuando esta llega a su rotacion de ataque objetivo, hace que rote hacia su rotacion original
    ///y desactiva el collider del arma cuando esta llegue a su rotacion de ataque objetivo desactiva su collider 2D.
    ///</summary>
    private void FixedUpdate()
    {
        if (attacking && canAttack)
        {
            //Codigo basado de: https://docs.unity3d.com/ScriptReference/Transform-rotation.html
            transform.rotation = Quaternion.Slerp(transform.rotation, currenttargetRotation, Time.deltaTime * currentSpeed);
            if (!attacking || transform.rotation == targetAttackRotation)
            {
                if (currenttargetRotation == originalRotation)
                {
                    canAttack = false;
                }
                currenttargetRotation = originalRotation;
                currentSpeed = returnSpeed;
                meleeWeaponCollider.enabled = false;
            }
        }
    }
    ///<summary>
    ///Llama a la funcion que hace que el arma aga un ataque.
    ///</summary>
    private void Update()
    {
        if (((isForPlayer && Input.GetButton(attackButton)) || (!isForPlayer && npcAttacking)) && !attacking)
        {
            StartCoroutine(Attack());
        }
    }
    ///<summary>
    ///Hace un ataque con el arma si el arma es de un NPC.
    ///</summary>
    public void NpcAttack()
    {
        if (!npcAttacking && !attacking)
        {
            npcAttacking = true;
            StartCoroutine(Attack());
        }
    }
    ///<summary>
    ///Regresa una variable BOOLEANA que indica si el arma está haciendo un ataque..
    ///</summary>
    ///<return>
    ///Regresa true si el arma esta atacando.
    ///</return>
    public bool GetAttacking()
    {
        return attacking;
    }
    ///<summary>
    ///Evita que el arma pueta atacar otra vez asta que la cantidad de tiempo determinada por atackRate pase 
    ///, reproduse el sonido de ataque y activa el collider 2D del arma.
    ///</summary>
    private IEnumerator Attack()
    {
        if (attackSound && !attacking)
        {
            audioSource.PlayOneShot(attackSound);
        }
        if (transform.rotation == originalRotation)
        {
            meleeWeaponCollider.enabled = true;
            attacking = true;
            currentSpeed = swingSpeed;
        }
        yield return new WaitForSeconds(attackRate);
        currenttargetRotation = targetAttackRotation;
        if (!isForPlayer)
        {
            npcAttacking = false;
        }
        canAttack = true;
        attacking = false;
    }
}
