using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject missle;
    public GameObject bullet;

    public GameObject SpawnLeftMissile;
    public GameObject SpawnRightMissle;

    public GameObject SpawnLeftBullet;
    public GameObject SpawnRightBullet;

    GameObject[] SpawnMissle;
    bool firedMissle = false;
    int offsetMissle = 0;
    int tMissle = 0;

    GameObject[] SpawnBullet;
    bool firedBullet = false;
    int tBullet = 0;
    // Start is called before the first frame update
    void Start()
    {
        SpawnMissle = new GameObject[2];
        SpawnMissle[0] = SpawnLeftMissile;
        SpawnMissle[1] = SpawnRightMissle;

        SpawnBullet = new GameObject[2];
        SpawnBullet[0] = SpawnLeftBullet;
        SpawnBullet[1] = SpawnRightBullet;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && !firedMissle)
        {
            Instantiate(missle, new Vector3(SpawnMissle[offsetMissle].transform.position.x, SpawnMissle[offsetMissle].transform.position.y, SpawnMissle[offsetMissle].transform.position.z + 5), Quaternion.identity);
            firedMissle = true;
            offsetMissle = (offsetMissle == 1) ? 0 : 1;
        }

        if (firedMissle)
        {
            tMissle++;
            if (tMissle == 200)
            {
                firedMissle = false;
                tMissle = 0;
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && !firedBullet)
        {
            Instantiate(bullet, new Vector3(SpawnBullet[0].transform.position.x, SpawnBullet[0].transform.position.y, SpawnBullet[0].transform.position.z + 3), Quaternion.identity);
            Instantiate(bullet, new Vector3(SpawnBullet[1].transform.position.x, SpawnBullet[1].transform.position.y, SpawnBullet[1].transform.position.z + 3), Quaternion.identity);
            firedBullet = true;
        }

        if (firedBullet)
        {
            tBullet++;
            if (tBullet == 60)
            {
                firedBullet = false;
                tBullet = 0;
            }
        }
    }
}
