using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Camera camera;
    public GameObject spawn;

    Rigidbody rigidbody;

    public GameObject engine1;
    public GameObject engine2;

    float velocityxy = 200;
    float velocityz = 10;

    public static int health = 3;
    public static int score = 0;
    public static bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive) { 
            rigidbody.AddForce(Vector3.forward * velocityz * 75, ForceMode.Acceleration);

            if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                setOrigRotY();
            }

            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                setOrigRotX();
            }

            if (Input.GetKey(KeyCode.W) && transform.position.y < 15f)
            {
                rigidbody.AddForce(Vector3.up * velocityxy, ForceMode.Acceleration);
                transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(-0.173648253f, transform.rotation.y, transform.rotation.z, 0.984807789f), Time.deltaTime * 5);

            }
            else if (transform.position.y >= 15)
            {
                rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
                transform.position = new Vector3(transform.position.x, 15f, transform.position.z);

                setOrigRotY();
            }
            else
            {
                rigidbody.velocity = rigidbody.velocity * 0.95f * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S) && transform.position.y > -14.9f)
            {
                rigidbody.AddForce(Vector3.down * velocityxy, ForceMode.Acceleration);
                transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(0.173648164f, transform.rotation.y, transform.rotation.z, 0.984807789f), Time.deltaTime * 5);

            }
            else if (transform.position.y <= -15f)
            {
                rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
                transform.position = new Vector3(transform.position.x, -15f, transform.position.z);

                setOrigRotY();

            }
            else
            {
                rigidbody.velocity = rigidbody.velocity * 0.95f * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A) && transform.position.x > -30)
            {
                rigidbody.AddForce(Vector3.left * velocityxy, ForceMode.Acceleration);

                transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(transform.rotation.x, transform.rotation.y, 0.173648164f, 0.984807789f), Time.deltaTime * 5);
            }
            else if (transform.position.x <= -30)
            {
                rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);
                transform.position = new Vector3(-30, transform.position.y, transform.position.z);

                setOrigRotX();
            }
            else
            {
                rigidbody.velocity = rigidbody.velocity * 0.95f * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D) && transform.position.x < 30)
            {
                rigidbody.AddForce(Vector3.right * velocityxy, ForceMode.Acceleration);

                transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(transform.rotation.x, transform.rotation.y, -0.173648253f, 0.984807789f), Time.deltaTime * 5);
            }
            else if (transform.position.x >= 30)
            {
                rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);
                transform.position = new Vector3(30, transform.position.y, transform.position.z);

                setOrigRotX();
            }
            else
            {
                rigidbody.velocity = rigidbody.velocity * 0.95f * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.E))
            {
                if (velocityz < 25)
                {
                    velocityz += 5f * Time.deltaTime;
                }
            }

            if (Input.GetKey(KeyCode.Q))
            {
                if (velocityz > 5)
                {
                    velocityz -= 5f * Time.deltaTime;
                }
            }

            if (velocityz < 7.5f)
            {
                setMin();
            }
            else
            {
                setMax();
            }

            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, transform.position.z - 40);

            if (camera.transform.position.x <= 5 && camera.transform.position.x >= -5)
            {
                camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3(transform.position.x, transform.position.y, camera.transform.position.z), Time.deltaTime * 0.5f);
            }
            else
            {
                if (camera.transform.position.x < 0)
                {
                    camera.transform.position = new Vector3(camera.transform.position.x + 0.01f, camera.transform.position.y, camera.transform.position.z);
                }
                else
                {
                    camera.transform.position = new Vector3(camera.transform.position.x - 0.01f, camera.transform.position.y, camera.transform.position.z);

                }
            }

            spawn.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y, transform.position.z + 500);
        }

        if (health <= 0 && alive)
        {
            GameObject.Find("Canvas").GetComponent<Text>().text = "Game Over";

            alive = false;

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActiveRecursively(false);
            }

            rigidbody.velocity = Vector3.zero;

            Spawn.spawning = false;
        }
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

    void setOrigRotX()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(transform.rotation.x, 0, 0, 1), Time.deltaTime * 2.5f);
    }

    void setOrigRotY()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(0, transform.rotation.y, transform.rotation.z, 1), Time.deltaTime * 2.5f);
    }
}
