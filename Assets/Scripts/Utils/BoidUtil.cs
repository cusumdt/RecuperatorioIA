using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cusumano Cristian Ariel
//28/11/2020

public class BoidUtil : MonoBehaviour
{

    [SerializeField]
    private int MaxFood = 1;
    [SerializeField]
    private GameObject MenacePrefab;
    [SerializeField]
    private float foodCount;

    public float maxSpeed;
    public Vector3 velocity;

    void Start()
    {
        velocity = Vector3.zero;
        foodCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Food")
        {
            BoidManager.Get().FoodList.Remove(other.gameObject);
            Destroy(other.gameObject);
            foodCount++;
            if (foodCount >= MaxFood)
                TransformIntoMenace();
        }
    }

    private void TransformIntoMenace()
    {
        GameObject menace = Instantiate(MenacePrefab);
        menace.transform.position = transform.position;
        BoidManager boidGet = BoidManager.Get();
        boidGet.MenaceList.Add(menace);
        boidGet.BoidList.Remove(this);
        Destroy(this.gameObject);
    }

    public Vector3 VelocityLimiter(Vector3 _velocity, float limit)
    {
        if (_velocity.magnitude > maxSpeed)
        {
            _velocity /= _velocity.magnitude / limit;
        }

        return _velocity;
    }


}
