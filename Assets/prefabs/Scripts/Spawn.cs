using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject ship1;
    public GameObject ship2;
    public GameObject ship3;

    public GameObject ship4;
    public GameObject ship5;
    public GameObject ship6;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies()
    {
        int rand = Random.Range(0,6);

        float x = Random.Range(-10,10);
        float y = Random.Range(-10, 10);

        Vector3 position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);

        switch (rand)
        {
            case 0:
                Instantiate(ship1, position, transform.rotation);
                break;
            case 1:
                Instantiate(ship2, position, transform.rotation);
                break;
            case 2:
                Instantiate(ship3, position, transform.rotation);
                break;
            case 3:
                Instantiate(ship4, position, transform.rotation);
                break;
            case 4:
                Instantiate(ship5, position, transform.rotation);
                break;
            case 5:
                Instantiate(ship6, position, transform.rotation);
                break;
        }
    }
}
