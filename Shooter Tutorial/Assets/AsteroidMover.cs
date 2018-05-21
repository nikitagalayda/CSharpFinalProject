using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMover : MonoBehaviour {

    public float speed;
    public float maxDistance;

    private float rotateX;
    private float rotateY;
    private float rotateZ;

    Rigidbody rb;
    void Start()
    {
        rotateX = Random.Range(-90.0f, 90.0f);
        rotateY = Random.Range(-90.0f, 90.0f);
        rotateZ = Random.Range(-90.0f, 90.0f);

        rb = GetComponent<Rigidbody>();

        rb.velocity = -Vector3.forward * speed;
    }

    void Update()
    {
        

        transform.Rotate(new Vector3(rotateX * Time.deltaTime, rotateY * Time.deltaTime, rotateZ * Time.deltaTime));

        if (transform.position.z <= -maxDistance)
        {
            DestroyObject(this.gameObject);
        }
    }
}
