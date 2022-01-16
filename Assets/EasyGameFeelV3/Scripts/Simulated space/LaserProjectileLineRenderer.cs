using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectileLineRenderer : ProjectileFather
{
    //Codigo basado en https://www.youtube.com/watch?v=vdci2oxVaoA&t=73s
    public float MaxRange
    {
        get
        {
            return maxRange;
        }
        set
        {
            maxRange = value;
        }
    }
    public bool IsFromPlayer
    {
        get
        {
            return isFromPlayer;
        }
        set
        {
            isFromPlayer = value;
        }
    }
    public GameObject HitObject
    {
        get
        {
            return hitObject;
        }
        set
        {
            hitObject = value;
        }
    }
    public LineRenderer LaserLineRenderer
    {
        get
        {
            return laserLineRenderer;
        }
        set
        {
            laserLineRenderer = value;
        }
    }

    ///<summary>
    ///Es el largo máximo que el láser puede tener.
    ///</summary>
    [SerializeField]
    private float maxRange;
    ///<summary>
    ///Determina si el proyectil sera disparado por un jugador o por un NPC. 
    ///Si el láser es de un jugador este se destruirá cuando el jugador deje de presionar el botón derecho del ratón, 
    ///de lo contrario este solo será destruido cuando se llame a la fusión DestroyLaser.
    ///</summary>
    [SerializeField]
    private bool isFromPlayer;
    ///<summary>
    ///Este es el GameObject hijo del láser que puede interactuar con el mundo del juego.
    ///</summary>
    [SerializeField]
    private GameObject hitObject;
    ///<summary>
    ///Es el LineRenderer del objeto láser.
    ///</summary>
    [SerializeField]
    private LineRenderer laserLineRenderer;

    ///<summary>
    ///Indica si se desea destruir el laser desde codigo.
    ///</summary>
    private bool destroyLaser = false;
    ///<summary>
    ///Indica si se desea destruir el laser.
    ///</summary>
    private bool destroy = false;

    ///<summary>
    ///Inicializa variables.
    ///</summary>
    private void Start()
    {
        ProjectileFather tmp = HitObject.GetComponent<ProjectileFather>();
        tmp.Damage = Damage;
        tmp.AudioSource = AudioSource;
        if (HitSound)
        {
            tmp.HitSound = HitSound;
        }
    }
    ///<summary>
    ///Determina el largo del laser, si este coliciono con un objeto y ademas destruye el laser si destroy es verdadero.
    ///</summary>
    private void FixedUpdate()
    {
        laserLineRenderer.SetPosition(0, transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, maxRange);
        if (hit)
        {
            if (!AudioSource.isPlaying && HitSound)
            {
                AudioSource.PlayOneShot(HitSound);
            }
            laserLineRenderer.SetPosition(1, hit.point);
            hitObject.transform.position = new Vector2(hit.point.x, hit.point.y);
        }
        else
        {
            laserLineRenderer.SetPosition(1, (transform.right * maxRange) + transform.position);
            hitObject.transform.position = (transform.right * maxRange) + transform.position;
        }
        if (destroy)
        {
            Destroy(gameObject);
        }
    }
    ///<summary>
    ///Revisa si se desea destruir el laser.
    ///</summary>
    private void Update()
    {
        if ((isFromPlayer && Input.GetKeyUp(KeyCode.Mouse0)) || destroyLaser)
        {
            destroy = true;
        }
    }
    ///<summary>
    ///Indica que se desea destruir el laser.
    ///</summary>
    public void DestroyLaser()
    {
        destroyLaser = true;
    }
}
