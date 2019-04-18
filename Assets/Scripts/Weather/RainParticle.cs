using UnityEngine;
using System.Collections;

public class RainParticle : MonoBehaviour
{
    [SerializeField]
    private int rainSpeed;

    void Start()
    {

    }

    void Update()
    {
        if (transform.position.y <= 0 && gameObject.name.Contains("(Clone)")) //checks that original prefab isn't being destroyed
        {
            Destroy(gameObject); //destroys object because it is no longer useful
        }
        else
        {
            transform.Translate(Vector3.down * rainSpeed); //else, 
        }
    }
}
