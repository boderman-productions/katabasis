using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherSystem : MonoBehaviour
{
    public static float minWaterLevel;
    public static float maxWaterLevel;
    public static bool raining;
    public GameObject Rain;
    public float rainInterval; //how often rain falls
    public float rainVariation;

    void Start()
    {
        StartCoroutine(TimedUpdateRoutine());
        minWaterLevel = 1f;
        maxWaterLevel = 15f;
        raining = true;
    }

    void Update()
    {
    }

    IEnumerator TimedUpdateRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(rainInterval);
            Instantiate(Rain, new Vector3(transform.position.x + Random.Range(-rainVariation, rainVariation), 100 + Random.Range(-rainVariation , rainVariation *20), transform.position.z + Random.Range(-rainVariation, rainVariation)), Quaternion.identity); //instantiates random droplet at random coordinates above terrain map
        }
    }
}