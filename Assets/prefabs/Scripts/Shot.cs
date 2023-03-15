using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject missle;
    public GameObject SpawnLeft;
    public GameObject SpawnRight;

    List<GameObject> spawns;
    bool fired = false;
    int offset = 0;
    int t = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawns.Add(SpawnLeft);
        spawns.Add(SpawnRight);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !fired)
        {
            Instantiate(missle, new Vector3(spawns[offset].transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            fired = true;
            offset = (offset == 1) ? 0 : 1;
        }

        if (fired)
        {
            t++;
            if (t == 200)
            {
                fired = false;
                t = 0;
            }
        }
    }
}
