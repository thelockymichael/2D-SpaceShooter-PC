using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InControl;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    private Rigidbody rb;


    // Audio
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    public void shootLaser()
    {
     
    }

     void Update()
    {
      
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(audio);
            audio.Play();
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }         
    }

   
    // Update is called once per frame
    void FixedUpdate()
    {

      
        

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        //float moveHorizontalPC = Input.GetAxis("Horizontal");
       // float moveVerticalPC = Input.GetAxis("Vertical");

        // float moveHorizontal = Input.GetAxis("Horizontal");
        //  float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
