using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera camera;
    Rigidbody rigidbody;

    public GameObject engine1;
    public GameObject engine2;

    public GameObject reticle;

    float velocityxy = 100;
    float velocityz = 10;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(Vector3.forward * velocityz, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.W) && transform.position.y < 15f)
        {
            rigidbody.AddForce(Vector3.up * velocityxy, ForceMode.Acceleration);
        }
        else if (transform.position.y >= 15)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
            transform.position = new Vector3(transform.position.x, 15f, transform.position.z);
        }
        else
        {
            rigidbody.velocity = rigidbody.velocity * 0.95f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S) && transform.position.y > -15f)
        {
            rigidbody.AddForce(Vector3.down * velocityxy, ForceMode.Acceleration);
        }
        else if (transform.position.y <= -15f)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
            transform.position = new Vector3(transform.position.x, -15f, transform.position.z);
        }
        else
        {
            rigidbody.velocity = rigidbody.velocity * 0.95f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x > -30)
        {
            rigidbody.AddForce(Vector3.left * velocityxy, ForceMode.Acceleration);
        }
        else if (transform.position.x <= -30)
        {
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);
            transform.position = new Vector3(-30, transform.position.y, transform.position.z);
        }
        else
        {
            rigidbody.velocity = rigidbody.velocity * 0.95f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < 30)
        {
            rigidbody.AddForce(Vector3.right * velocityxy, ForceMode.Acceleration);
        }
        else if (transform.position.x >= 30)
        {
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);
            transform.position = new Vector3(30, transform.position.y, transform.position.z);
        }
        else
        {
            rigidbody.velocity = rigidbody.velocity * 0.95f * Time.deltaTime;
        }

        if (!Input.anyKey)
        {
            setMin();
        }
        else
            setMax();

        if (Input.GetKey(KeyCode.Space))
        {
            velocityz = rigidbody.velocity * 0.95f * Time.deltaTime;
        }

        var rotationAngle = Quaternion.LookRotation(reticle.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * 10);

        camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, transform.position.z - 40);
        reticle.transform.position = new Vector3(reticle.transform.position.x, reticle.transform.position.y, transform.position.z + 50);
    }

    void setMin()
    {
        engine1.GetComponent<ParticleSystem>().startSize = 5;
        engine2.GetComponent<ParticleSystem>().startSize = 5;
    }

    void setMax()
    {
        engine1.GetComponent<ParticleSystem>().startSize = 7;
        engine2.GetComponent<ParticleSystem>().startSize = 7;
    }
}
