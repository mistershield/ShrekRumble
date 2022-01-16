using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticObject : SteeringBehaviors
{
    public float MinDistance
    {
        get
        {
            return minDistance;
        }
        set
        {
            minDistance = value;
        }
    }
    public float DistanceToChangeState
    {
        get
        {
            return distanceToChangeState;
        }
        set
        {
            distanceToChangeState = value;
        }
    }
    public float Delay
    {
        get
        {
            return delay;
        }
        set
        {
            delay = value;
        }
    }
    public bool Active
    {
        get
        {
            return active;
        }
        set
        {
            active = value;
        }
    }
    public GameObject ObjectiveObject
    {
        get
        {
            return objectiveObject;
        }
        set
        {
            objectiveObject = value;
        }
    }

    ///<summary>
    ///
    ///</summary>
    [SerializeField]
    private float minDistance;
    ///<summary>
    ///
    ///</summary>
    [SerializeField]
    private float distanceToChangeState;
    ///<summary>
    ///
    ///</summary>
    [SerializeField]
    private float delay;
    ///<summary>
    ///
    ///</summary>
    [SerializeField]
    private bool active = false;
    ///<summary>
    ///
    ///</summary>
    [SerializeField]
    private GameObject objectiveObject;

    ///<summary>
    ///Indica si el objeto puede seguir a su objetivo.
    ///</summary>
    private bool canFollow = false;

    ///<summary>
    ///Calcula la distancia entre el objeto magnetico y su objetivo y llama a la funcion StateMachine.
    ///</summary>
    private void Update()
    {
        this.distance = CalculateDistance(transform.position, objectiveObject.transform.position);
        StateMachine();
    }
    ///<summary>
    ///Determina que comportamiento de direccion se aplicara al objeto magnetico y llama a la funcion WaitForDelay.
    ///</summary>
    private void StateMachine()
    {
        if (active && !canFollow)
        {
            StartCoroutine(WaitForDelay());
        }
        if (canFollow && this.distance <= minDistance)
        {
            if (this.distance < distanceToChangeState)
            {
                this.acceleration += arrival(objectiveObject.transform.position, vectorPosition, velocity, MaxSpeed);
            }
            else if (this.distance >= distanceToChangeState)
            {
                this.acceleration += seek(objectiveObject.transform.position, vectorPosition, velocity, MaxSpeed, MaxForce);
            }
            AplySteering();
        }
    }
    ///<summary>
    ///Hace isTrigger al collider del objeto magnetico y permite que este siga a su objetivo despues de que el tiempo indicado por delay pase.
    ///</summary>
    private IEnumerator WaitForDelay()
    {
        yield return new WaitForSeconds(delay);
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        canFollow = true;
    }
    ///<summary>
    ///Regresa un BOOLEANO el cual indica si el objeto puede seguir a su objetivo.
    ///</summary>
    ///<return>
    ///Regresa si el objeto magnetico puede seguir a su objetivo.
    ///</return>
    public bool GetCanFollow()
    {
        return canFollow;
    }
}
