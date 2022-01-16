using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncieProjectile : ProjectileFather
{
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
    public float MaxDistance
    {
        get
        {
            return maxDistance;
        }
        set
        {
            maxDistance = value;
        }
    }
    public int Bounces
    {
        set
        {
            bounces = value;
        }
        get
        {
            return bounces;
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
    ///Determina qué tan rápido se moverá el proyectil.
    ///</summary>
    [SerializeField]
    private float speed;
    ///<summary>
    ///Determina la distancia máxima que puede viajar el proyectil antes de destruirse.
    ///</summary>
    [SerializeField]
    private float maxDistance;
    ///<summary>
    ///Determina el numero de rebotes que puede hacer el proyectil antes de ser destruido.
    ///</summary>
    [SerializeField]
    private int bounces = 0;
    ///<summary>
    ///El RigidBody2D del objeto.
    ///</summary>
    [SerializeField]
    private Rigidbody2D rb;

    ///<summary>
    ///Duracion de HitSound
    ///</summary>
    private float hitSoundLength = 0;

    ///<summary>
    ///Inicializa variables e impulsa al projectil
    ///</summary>
    private void Start()
    {
        initialPosition = transform.position;
        if (HitSound)
        {
            hitSoundLength = HitSound.length;
        }
        rb.AddForce(gameObject.transform.right * speed, ForceMode2D.Impulse);
    }
    ///<summary>
    ///Verifica si se necesita destruir al proyectil dado a que supero su distancia maxima.
    ///</summary>
    private void FixedUpdate()
    {
        this.distance = CalculateDistance(initialPosition, transform.position);
        if (this.distance > maxDistance)
        {
            StartCoroutine(DestroyProyectile());
        }
    }
    ///<summary>
    ///Reproduce HitSound y le resta 1 a Bounces cuando el proyectil tiene una colision,
    ///si Bounces es igual o menor a 0 (cuando el numero de rebotes que realiza es igual a Bounces) la funcion inicia el proceso de destruccion del proyectil.
    ///</summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.GetComponent<ProjectileFather>())
        {
            bounces -= 1;
            if (HitSound && !AudioSource.isPlaying)
            {
                AudioSource.PlayOneShot(HitSound);
            }
            if (bounces <= 0)
            {
                StartCoroutine(DestroyProyectile());
            }
        }
    }
    ///<summary>
    ///Destruye el proyectil cuando hitSound termina de reproducirse.
    ///</summary>
    private IEnumerator DestroyProyectile()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(hitSoundLength);
        Destroy(gameObject);
    }
}
