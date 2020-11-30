using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cusumano Cristian Ariel
//28/11/2020

public abstract class SteerBehaviour : MonoBehaviour
{
    [UnityEngine.Range(0, 40)]
    public float weight;

    public float radius;

    public abstract Vector3 GetForce(List<BoidUtil> nearUnits, BoidUtil actualBoid, float maxSpeed, List<GameObject> foodList, List<GameObject> menaceList, Vector3 NextWaypoint);
}
