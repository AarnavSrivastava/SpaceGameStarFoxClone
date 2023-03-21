using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 300, ForceMode.Acceleration);

        if (transform.position.z > GameObject.Find("Player").transform.position.z + 50)
        {
            Destroy(gameObject.transform.parent);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            Destroy(gameObject.transform.parent);
    }
}
