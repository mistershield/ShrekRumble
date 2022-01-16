using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///Este codigo debe de estar en una camara diferente a la principal de otra forma la camara no para de moverse.
///</summary>
public class CameraController : SteeringBehaviors
{
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
    public float SeekingBehaviourDistance
    {
        get
        {
            return seekingBehaviourDistance;
        }
        set
        {
            seekingBehaviourDistance = value;
        }
    }
    public float ArrivingBehaviourDistance
    {
        get
        {
            return arrivingBehaviourDistance;
        }
        set
        {
            arrivingBehaviourDistance = value;
        }
    }
    public float StopMovingDistance
    {
        get
        {
            return stopMovingDistance;
        }
        set
        {
            stopMovingDistance = value;
        }
    }
    public string CameraControllerbutton
    {
        get
        {
            return cameraControllerButton;
        }
        set
        {
            cameraControllerButton = value;
        }
    }
    public GameObject ReferenceObject
    {
        get
        {
            return referenceObjet;
        }
        set
        {
            referenceObjet = value;
        }
    }
    public Camera ReferenceCamera
    {
        get
        {
            return referenceCamera;
        }
        set
        {
            referenceCamera = value;
        }
    }
    ///<summary>
    ///Determina qué tan lejos puede estar la cámara del objeto de referencia.
    ///</summary>
    [SerializeField]
    private float maxDistance;
    ///<summary>
    ///Determina cuando el comportamiento de “Seguir” se activará, el comportamiento es activado si la distancia entre el objeto y su objetivo es mayor o igual a este valor.
    ///</summary>
    [SerializeField]
    private float seekingBehaviourDistance;
    ///<summary>
    ///Determina cuando el comportamiento de “Llegada” se activará, el comportamiento es activado si la distancia entre el objeto y su objetivo es menor a este valor.
    ///</summary>
    [SerializeField]
    private float arrivingBehaviourDistance;
    ///<summary>
    ///Determina cuando el objeto debe de parar de moverse, el objeto deja de moverse si la distancia entre el objeto y su objetivo es menor a este valor.
    ///</summary>
    [SerializeField]
    private float stopMovingDistance;
    ///<summary>
    ///Determina el botón que activará el comportamiento del objeto (que mueva la cámara), utiliza la nomenclatura de botones de Unity.
    ///</summary>
    [SerializeField]
    private string cameraControllerButton;
    ///<summary>
    ///Determina la posición original de la cámara, la posición original de la cámara será la misma que la posición de este objeto.
    ///</summary>
    [SerializeField]
    private GameObject referenceObjet;
    ///<summary>
    ///Determina la posición del cursor dentro del mundo del juego.
    ///La camara de referencia deve de ser ortografica y su display objetivo deve de ser menor que el de la camara con este codigo.
    ///</summary>
    [SerializeField]
    private Camera referenceCamera;

    ///<summary>
    ///Es la distancia que hay entre el objetivo y la posición actual de la camara.
    ///</summary>
    private float goingDistance;
    ///<summary>
    ///Determina si la camara esta llendo a su objetivo.
    ///</summary>
    private bool going = false;
    ///<summary>
    ///Determina si la camara llego a su objetivo.
    ///</summary>
    private bool arrived = false;
    ///<summary>
    ///Determina si la camara esta regresando a su posición original.
    ///</summary>
    private bool returning = false;
    ///<summary>
    ///Es un vector temporal que se utiliza como referencia al objetivo de la camara.
    ///</summary>
    private Vector3 tmpVector;

    ///<summary>
    ///Cuando se preciona cameraControllerButton, determina el objetivo de la camara y se llama a la funcion StateMachine.
    ///</summary>
    private void Update()
    { 
        this.distance = CalculateDistance(transform.position, referenceObjet.transform.position);
        if (Input.GetButton(cameraControllerButton))
        {
            returning = false;
            Vector3 pos = referenceCamera.ScreenToWorldPoint(Input.mousePosition);
            float distance2 = Mathf.Sqrt(Mathf.Pow(referenceObjet.transform.position.x - pos.x, 2) + Mathf.Pow(referenceObjet.transform.position.y - pos.y, 2));
            //Si la distancia entre la camara y la posición del cursor dentro del mundo del juego es mayor a la distancia maxima se crea un punto en la distancia maxDistance dentro
            //de la recta imaginaria entre la camara y la posición del cursor dentro del mundo del juego, este punto es utilizado como el objetivo de la camara.
            if (distance2 > maxDistance)
            {
                float x = distance2 / maxDistance;
                Vector2 tmpVector2 = new Vector2((referenceObjet.transform.position.x * -1) + pos.x, (referenceObjet.transform.position.y * -1) + pos.y);
                pos = new Vector2(tmpVector2.x/x + referenceObjet.transform.position.x, tmpVector2.y/x + referenceObjet.transform.position.y);
            }
            if (!arrived)
            {
                going = true;
                tmpVector = new Vector3(pos.x, pos.y, transform.position.z);
                goingDistance = CalculateDistance(transform.position, tmpVector);
            }
            else
            {
                transform.position = new Vector3(pos.x, pos.y, transform.position.z);
            }
        }
        if (Input.GetButtonUp(cameraControllerButton))
        {
            returning = true;
            going = false;
            arrived = false;
        }
        StateMachine();
    }
    ///<summary>
    ///Esta funcion cambia el "steering behavior" (el como se mueve la camara) dependiendo de distancia que existe entre la misma y su objetivo (cuando esta llendo al punto objetivo) 
    ///o su posición original (si esta rtegresando a s upocicion original) y el estado de las variables going y returning.
    ///</summary>
    private void StateMachine()
    {
        //Si going es verdadero la camara se mueve hacia su objetivo
        if (going)
        {
            if (goingDistance < stopMovingDistance)
            {
                arrived = true;
                going = false;
                transform.position = new Vector3(tmpVector.x, tmpVector.y, transform.position.z);
            }
            else if (goingDistance < arrivingBehaviourDistance)
            {
                this.acceleration += arrival(tmpVector, vectorPosition, velocity, MaxSpeed);
            }
            else if (goingDistance >= seekingBehaviourDistance)
            {
                this.acceleration += seek(tmpVector, vectorPosition, velocity, MaxSpeed, MaxForce);
            }
            AplySteering();
        }
        //Si returning es verdadero la camara se mueve hacia su posición original.
        if (returning)
        {
            if (returning && this.distance < stopMovingDistance)
            {
                returning = false;
                transform.position = new Vector3(referenceObjet.transform.position.x, referenceObjet.transform.position.y, transform.position.z);
            }
            if (returning && this.distance < arrivingBehaviourDistance)
            {
                this.acceleration += arrival(referenceObjet.transform.position, vectorPosition, velocity, MaxSpeed);
            }
            else if (returning && this.distance >= seekingBehaviourDistance)
            {
                this.acceleration += seek(referenceObjet.transform.position, vectorPosition, velocity, MaxSpeed, MaxForce);
            }
            AplySteering();
        }
    }
}
