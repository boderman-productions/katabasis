using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float speed;
    public float jumpSpeed;

    private Rigidbody player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 jmp = new Vector3(0, 50, 0);
            player.AddForce(jmp * speed);
        }

    }

    void FixedUpdate()
    {
        float moveHor = Input.GetAxis("Horizontal") * speed;
        float moveVer = Input.GetAxis("Vertical") * speed;

        moveHor *= Time.deltaTime;
        moveVer *= Time.deltaTime;

        Vector3 move = new Vector3(moveHor, 0.0f, moveVer);

        player.AddForce(move * speed);
    }
}
