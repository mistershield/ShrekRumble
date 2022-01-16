using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviors : MonoBehaviour
{
    public float MaxSpeed
    {
        get
        {
            return maxSpeed;
        }
        set
        {
            maxSpeed = value;
        }
    }
    public float MaxForce
    {
        get
        {
            return maxForce;
        }
        set
        {
            maxForce = value;
        }
    }

    ///<summary>
    ///Determina la velocidad máxima que el objeto puede tener.
    ///</summary>
    [SerializeField]
    private float maxSpeed;
    ///<summary>
    ///Determina la fuerza máxima que el movimiento del objeto puede tener.
    ///</summary>
    [SerializeField]
    private float maxForce;

    ///<summary>
    ///Referencia a la distancia entre dos puntos.
    ///</summary>
    protected float distance;
    ///<summary>
    ///Es la aceleracion del objeto.
    ///</summary>
    protected Vector2 acceleration;
    ///<summary>
    ///Es la pocicion del objeto.
    ///</summary>
    protected Vector2 vectorPosition;
    ///<summary>
    ///Es la velocidad calculada del objeto.
    ///</summary>
    protected Vector2 velocity;

    ///<summary>
    ///Calcula la distancia entre dos puntos.
    ///</summary>
    ///<param name="pos1">
    ///La primera posición de referencia.
    ///</param>
    ///<param name="pos2">
    ///La segunda posición de referencia.
    ///</param>
    ///<return>
    ///Regresa la distancia entre los dospuntos.
    ///</return>
    public float CalculateDistance(Vector3 pos1, Vector3 pos2)
    {
        return Mathf.Sqrt(Mathf.Pow(pos2.x - pos1.x, 2) + Mathf.Pow(pos2.y - pos1.y, 2));
    }
    ///<summary>
    ///Aplica el comportamiento de direccion
    ///</summary>
    public void AplySteering()
    {
        vectorPosition = transform.position;
        velocity += acceleration;
        vectorPosition += velocity;
        transform.position = new Vector3(vectorPosition.x, vectorPosition.y, transform.position.z);
        acceleration *= 0;
    }
    ///<summary>
    ///Hace que un objeto se mueve a una pocicion en especifico
    ///</summary>
    ///<param name="target">
    ///El hobjetivo hacia donde se desea moverse.
    ///</param>
    ///<param name="position">
    ///La posición actual del objeto.
    ///</param>
    ///<param name="velocity">
    ///La velocidad a la que se movera el objeto.
    ///</param>
    ///<param name="maxspeed">
    ///La velocidad maxima que puede tener el objeto.
    ///</param>
    ///<param name="maxforce">
    ///La fuerza maxima que puede tener el objeto.
    ///</param>
    ///<return>
    ///Regresa el vector hacia donde se movera el objeto.
    ///</return>
    public Vector2 seek(Vector2 target, Vector2 position, Vector2 velocity, float maxspeed, float maxforce)
    {
        Vector2 desired = target - position;
        desired.Normalize();
        desired *= maxspeed;
        Vector2 steer = desired - velocity;
        Vector2.ClampMagnitude(steer, maxforce);
        return steer;
    }
    ///<summary>
    ///Hace que cuando un objeto este cerca de un punto en especifico deshacelere hasta llegar a este punto.
    ///</summary>
    ///<param name="target">
    ///El hobjetivo hacia donde se desea moverse.
    ///</param>
    ///<param name="position">
    ///La posición actual del objeto.
    ///</param>
    ///<param name="velocity">
    ///La velocidad a la que se movera el objeto.
    ///</param>
    ///<param name="maxspeed">
    ///La velocidad maxima que puede tener el objeto.
    ///</param>
    ///<return>
    ///Regresa el vector hacia donde se movera el objeto.
    ///</return>
    public Vector2 arrival(Vector2 target, Vector2 position, Vector2 velocity, float maxspeed)
    {
        float perc = 3;
        Vector2 tv = target;
        tv *= (-1);
        tv.Normalize();
        tv *= (0);
        Vector2 behind = target + (tv);
        Vector2 desired = behind - (position);
        float d = desired.magnitude;
        desired.Normalize();
        if (d < perc)
        {
            desired *= (maxspeed);
            desired *= (d / perc);
        }
        else
        {
            desired *= (maxspeed);
        }
        Vector2 steer = desired - (velocity);
        return steer;
    }
}
