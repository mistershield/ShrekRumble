using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenetratingProjectile : ProjectileFather
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
    public List<string> CantPenetrateLayerList
    {
        get
        {
            return cantPenetrateLayerList;
        }
        set
        {
            cantPenetrateLayerList = value;
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
    ///El RigidBody2D del objeto.
    ///</summary>
    [SerializeField]
    private Rigidbody2D rb;
    ///<summary>
    ///Es una lista de Strings que indican que capas de Unity no puede penetrar el proyectil.
    ///</summary>
    [SerializeField]
    private List<string> cantPenetrateLayerList = new List<string>();

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
    ///Verifica si se necesita destruir al proyectil porque supero su distancia maxima.
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
    ///Reproduce hitSound y destruye el proyectil si detecta que colisiono con un objeto que este en una capa existente dentro de cantPenetrateLayerList.
    ///</summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.GetComponent<ProjectileFather>())
        {
            if (HitSound)
            {
                AudioSource.PlayOneShot(HitSound);
            }
            if (cantPenetrateLayerList.Contains(LayerMask.LayerToName(collision.gameObject.layer)))
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
