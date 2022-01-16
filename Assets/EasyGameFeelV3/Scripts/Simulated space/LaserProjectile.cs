using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : ProjectileFather
{
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
    public float PositionScale
    {
        get
        {
            return positionScale;
        }
        set
        {
            positionScale = value;
        }
    }
    public float TimeScale
    {
        get
        {
            return timeScale;
        }
        set
        {
            timeScale = value;
        }
    }
    public BoxCollider2D LaserBoxCollider
    {
        get
        {
            return laserBoxCollider;
        }
        set
        {
            laserBoxCollider = value;
        }
    }
    public SpriteMask LaserSpriteMask
    {
        get
        {
            return laserSpriteMask;
        }
        set
        {
            laserSpriteMask = value;
        }
    }

    ///<summary>
    ///Esta es una variable BOOLEANA que determina si el proyectil sera disparado por un jugador o por un NPC. 
    ///Si el láser es de un jugador este se destruirá cuando el jugador deje de presionar el botón derecho del ratón, 
    ///de lo contrario este solo será destruido cuando se llame a la fusión DestroyLaser.
    ///</summary>
    [SerializeField]
    private bool isFromPlayer;
    ///<summary>
    ///Determina por cuánto se moverá el Collider y el LayerMask del láser cada vez que el tiempo Time Scale pasa.
    ///</summary>
    [SerializeField]
    private float positionScale;
    ///<summary>
    ///Determina cuánto tiempo debe de pasar entre cada desplazamiento del Collider y LayerMask del láser.
    ///</summary>
    [SerializeField]
    private float timeScale;
    ///<summary>
    ///Es el LayerMask que utiliza el elemento.
    ///</summary>
    [SerializeField]
    private SpriteMask laserSpriteMask;
    ///<summary>
    ///Es el BoxCollider2D del láser.
    ///</summary>
    [SerializeField]
    private BoxCollider2D laserBoxCollider;

    ///<summary>
    ///Indica si se puede escalar el LayerMask.
    ///</summary>
    private bool canScaleLayerMask = true;
    ///<summary>
    ///Indica si se quiere destruir el laser.
    ///</summary>
    private bool destroyLaser = false;
    ///<summary>
    ///Referencia del objeto hijo con SpriteMask del laser.
    ///</summary>
    private GameObject spriteMask;
    ///<summary>
    ///La posición original del spriteMask.
    ///</summary>
    private Vector3 originalSpriteMaskPosition;
    ///<summary>
    ///El offser original de boxcollider del laser.
    ///</summary>
    private Vector2 originalBoxColliderOffset;
    ///<summary>
    ///El tamaño original del boxcollider del laser.
    ///</summary>
    private Vector2 originalBoxColliderSize;

    ///<summary>
    ///Inicializa las variabvles.
    ///</summary>
    private void Start()
    {
        spriteMask = laserSpriteMask.gameObject;
        originalSpriteMaskPosition = spriteMask.transform.localPosition;
        originalBoxColliderOffset = laserBoxCollider.offset;
        spriteMask.transform.localPosition = new Vector3(-spriteMask.transform.localPosition.x + spriteMask.transform.localScale.x * -1, 0, 0);
        laserBoxCollider.offset = new Vector2((laserBoxCollider.size.x / 2 - laserBoxCollider.offset.x) * -1, 0);
        originalBoxColliderSize = laserBoxCollider.size;
        laserBoxCollider.size = new Vector2(0, originalBoxColliderSize.y);
    }
    ///<summary>
    ///Inicia elproceso de destruccion de laser cuando detecta que el jugador dega de precionar el boton de disparo.
    ///</summary>
    private void Update()
    {
        if (isFromPlayer && Input.GetKeyUp(KeyCode.Mouse0))
        {
            destroyLaser = true;
        }
    }
    ///<summary>
    ///Inicia elproceso de creacion de laser y el de destruccion de laser.
    ///</summary>
    private void FixedUpdate()
    {
        if (spriteMask.transform.localPosition.x < 0 && canScaleLayerMask && !destroyLaser)
        {
            canScaleLayerMask = false;
            StartCoroutine(ScaleSpriteMask(positionScale, timeScale));
        }

        if (destroyLaser && canScaleLayerMask)
        {
            canScaleLayerMask = false;
            StartCoroutine(ScaleSpriteMask(positionScale * -1, timeScale));
        }
    }
    ///<summary>
    ///Reproduce HitSound cuando el laser es triggereado.
    ///</summary>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (HitSound && !AudioSource.isPlaying)
        {
            AudioSource.PlayOneShot(HitSound);
        }
    }
    ///<summary>
    ///Pone como verdadero a destroyLaser y desactiva el boxcollider del laser.
    ///</summary>
    public void DestroyLaser()
    {
        destroyLaser = true;
        laserBoxCollider.enabled = false;
    }
    ///<summary>
    ///Escala y mueve al boxcollider y al layerMask y detruye el laser si destroyLaser es verdadero.
    ///</summary>
    ///<param name="localPositionScale">
    ///El valor por el que se esclara el boxCollider y el layerMask.
    ///</param>
    ///<param name="localTimescale">
    ///El tiempo ques e esperara para escalar y mover el boxCollider y el layerMask.
    ///</param>
    IEnumerator ScaleSpriteMask(float localPositionScale, float localTimescale)
    {
        yield return new WaitForSeconds(localTimescale);

        spriteMask.transform.localPosition += new Vector3(localPositionScale, 0, 0);

        laserBoxCollider.size += new Vector2(localPositionScale, 0);
        laserBoxCollider.offset += new Vector2(localPositionScale / 2, 0);

        if (laserBoxCollider.size.x > originalBoxColliderSize.x)
        {
            laserBoxCollider.size = originalBoxColliderSize;
            laserBoxCollider.offset = originalBoxColliderOffset;
        }

        if (spriteMask.transform.localPosition.x >= originalSpriteMaskPosition.x && !destroyLaser)
        {
            spriteMask.transform.localPosition = originalSpriteMaskPosition;
            laserBoxCollider.size = originalBoxColliderSize;
            laserBoxCollider.offset = originalBoxColliderOffset;
            laserBoxCollider.enabled = true;
        }

        if (destroyLaser && spriteMask.transform.localPosition.x <= spriteMask.transform.localScale.x * -1)
        {
            Destroy(gameObject);
        }

        canScaleLayerMask = true;
    }
}
