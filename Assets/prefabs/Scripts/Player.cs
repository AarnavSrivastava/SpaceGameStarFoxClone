using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera camera;
    Rigidbody rigidbody;

    private Vector3 start;
    private Vector3 des;
    private float fraction = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();

        start = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        des = new Vector3(transform.position.x, 10f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && transform.position.y < 20)
        {
            rigidbody.AddForce(Vector3.up * 10, ForceMode.Acceleration);
        }
        else if (transform.position.y >= 20)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
            transform.position = new Vector3(transform.position.x, 19.99999f, transform.position.z);
        }
        else
        {
            rigidbody.velocity = rigidbody.velocity * 0.95f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S) && transform.position.y > -20)
        {
            rigidbody.AddForce(Vector3.down * 10, ForceMode.Acceleration);
        }
        else if (transform.position.y <= -20)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
            transform.position = new Vector3(transform.position.x, -19.99999f, transform.position.z);
        }
        else
        {
            rigidbody.velocity = rigidbody.velocity * 0.95f * Time.deltaTime;
        }

        camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3(camera.transform.position.x, transform.position.y + 6, transform.position.z - 30), Time.deltaTime * 0.5f);
    }
}
