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
        transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 100, ForceMode.Acceleration);

        if (transform.position.z > GameObject.Find("Player").transform.position.z + 50)
        {
            Destroy(gameObject);
        }
    }
}
