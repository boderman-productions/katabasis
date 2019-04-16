using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevel : MonoBehaviour
{
    void Update()
    {
        if (WeatherSystem.raining = true && transform.position.y <= WeatherSystem.maxWaterLevel)
        {
            transform.Translate(Vector3.back * 0.001f);
        }
        else
        {
            transform.Translate(Vector3.back * -0.001f);
        }
    }
}
