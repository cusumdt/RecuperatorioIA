using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cusumano Cristian Ariel
//28/11/2020

public class DestroyFood : MonoBehaviour
{
    private float time;
    [SerializeField]
    private float destroyTime;

    void Start()
    {
        time = destroyTime;

    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        { 
            BoidManager.Get().FoodList.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
