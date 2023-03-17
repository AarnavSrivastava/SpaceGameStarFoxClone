using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject impact;
    public GameObject explosion;
    public Material damaged;
    int health = 10;
    bool notDestroyed = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && notDestroyed)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<ParticleSystem>().Stop();
            Instantiate(explosion, transform);

            notDestroyed = false;

            int score = int.Parse(GameObject.Find("Canvas").GetComponent<Text>().text.Substring(7));

            score++;

            GameObject.Find("Canvas").GetComponent<Text>().text = "Score: " + score;
        }

        if (transform.position.z <= GameObject.Find("Player").transform.position.z-50)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Missile")
        {
            health -= 10;
        }
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;

            Instantiate(impact, transform);

            gameObject.GetComponent<Material>();
        }
    }
}
