using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float minX, maxX, minZ, maxZ;
}
public class PlayerController : MonoBehaviour {


    public Boundary boundary;
    public float speed;
    public float tilt;

    public GameObject shot;//instantiate
    public Transform shotSpawn;//at shotSpawn position
    public float fireRate = 0.5f;

    private float nextFire;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();


    }
	void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(moveHorizontal*speed*Time.deltaTime, 0.0f, moveVertical * speed * Time.deltaTime);
        rb.velocity = movementVector;

        rb.position = new Vector3
            (
            Mathf.Clamp(rb.position.x, boundary.minX, boundary.maxX), 
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.minZ, boundary.maxZ)
            );

        rb.rotation = Quaternion.Euler(0, 0, rb.velocity.x * -tilt);
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //GameObject clone 
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);// as GameObject;
        }
        
    }
}
