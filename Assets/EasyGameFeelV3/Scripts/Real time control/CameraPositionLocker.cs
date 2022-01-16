using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionLocker : SteeringBehaviors
{
    public List<GameObject> ObjectList
    {
        get
        {
            return objectList;
        }
        set
        {
            objectList = value;
        }
    }
    public Vector3 StartingPosition
    {
        get
        {
            return startingPosition;
        }
        set
        {
            startingPosition = value;
        }
    }

    ///<summary>
    ///Lista de GameObjects a la cual se puede mover la camara.
    ///</summary>
    [SerializeField]
    private List<GameObject> objectList;
    ///<summary>
    ///Es la posición inicial de la camara.
    ///</summary>
    [SerializeField]
    private Vector3 startingPosition;

    ///<summary>
    ///Es la referencia de la posición ha la que se movera la camara.
    ///</summary>
    private Vector3 nextPosition;

    ///<summary>
    ///Calcual la distancia entre la camara y nextPosition y llama a la funcion StateMachine.
    ///</summary>
    private void Update()
    {
        this.distance = CalculateDistance(transform.position, nextPosition);
        StateMachine();
    }
    ///<summary>
    ///Mueve a la cámara a la posición del objeto que se encuentra en el índice positionOnList de Object List pero mantiene la posición z dada por positionZ.
    ///</summary>
    ///<param name="positionOnList">
    ///El indice del objeto al que se decea mover la camara.
    ///</param>
    ///<param name="positionZ">
    ///La posición z en la que se desea que la camara se quede.
    ///</param>
    public void LockeCamera(int positionOnList, int positionZ)
    {
        nextPosition = new Vector3(objectList[positionOnList].transform.position.x, objectList[positionOnList].transform.position.y, positionZ);
    }
    ///<summary>
    ///Funcion sovbrecartgada.
    ///Para regresar a la cámara a su posición original llame a la función de esta manera, StopLockingCamera().
    ///Para mover la cámara a la posición de un objeto que no esté dentro de Object List llame a la función de esta manera, StopLockingCamera(GameObject gameObject, int positionZ).
    ///Para mover la cámara a un vector en específico llame a la función de esta manera, StopLockingCamera(Vector3 endPosition, int positionZ). 
    ///</summary>
    ///<param name="gameObject">
    ///El objeto al que se movera la camara cuando se llame ha esta funcion.
    ///</param>
    ///<param name="positionZ">
    ///La posición z en la que se desea que la camara se quede.
    ///</param>
    public void StopLockingCamera(GameObject gameObject, int positionZ)
    {
        nextPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, positionZ);
    }
    ///<summary>
    ///Funcion sovbrecartgada.
    ///Para regresar a la cámara a su posición original llame a la función de esta manera, StopLockingCamera().
    ///Para mover la cámara a la posición de un objeto que no esté dentro de Object List llame a la función de esta manera, StopLockingCamera(GameObject gameObject, int positionZ).
    ///Para mover la cámara a un vector en específico llame a la función de esta manera, StopLockingCamera(Vector3 endPosition, int positionZ). 
    ///</summary>
    ///<param name="endPosition">
    ///Posición a la que se desea que la camara regrese.
    ///</param>
    ///<param name="positionZ">
    ///La posición z en la que se desea que la camara se quede.
    ///</param>
    public void StopLockingCamera(Vector3 endPosition, int positionZ)
    {
        nextPosition = new Vector3(endPosition.x, endPosition.y, positionZ);
    }
    ///<summary>
    ///Funcion sovbrecartgada.
    ///Para regresar a la cámara a su posición original llame a la función de esta manera, StopLockingCamera().
    ///Para mover la cámara a la posición de un objeto que no esté dentro de Object List llame a la función de esta manera, StopLockingCamera(GameObject gameObject, int positionZ).
    ///Para mover la cámara a un vector en específico llame a la función de esta manera, StopLockingCamera(Vector3 endPosition, int positionZ). 
    ///</summary>
    public void StopLockingCamera()
    {
        nextPosition = startingPosition;
    }
    ///<summary>
    ///Esta funcion cambia el "steering behavior" (el como se mueve la camara) dependiendo de distancia que existe entre la misma y su posición objetivo.
    ///</summary>
    private void StateMachine()
    {
        if (transform.position.x == nextPosition.x && transform.position.y == nextPosition.y)
        {
            transform.position = new Vector3(nextPosition.x, nextPosition.y, transform.position.z);
        }
        else
        {
            if (this.distance < 1)
            {
                this.acceleration += arrival(nextPosition, vectorPosition, velocity, MaxSpeed);
            }
            else if (this.distance >= 1)
            {
                this.acceleration += seek(nextPosition, vectorPosition, velocity, MaxSpeed, MaxForce);
            }
            AplySteering();
        }
    }
    ///<summary>
    ///Activa el objeto con CameraPositionLocker.
    ///</summary>
    public void ActivateCameraLockerObject()
    {
        this.gameObject.SetActive(true);
    }
    ///<summary>
    ///Desactiva el objeto con CameraPositionLocker.
    ///</summary>
    public void DeactivateCameraLockerObject()
    {
        this.gameObject.SetActive(false);
    }
}
