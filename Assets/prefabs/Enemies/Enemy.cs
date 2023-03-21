using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject impact;
    public GameObject explosion;
    public Material damaged;

    [SerializeField]
    int health;
    bool notDestroyed = true;
    bool hasCollide = false;
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

            Player.score++;

            GameObject.Find("Canvas").GetComponent<Text>().text = "Score: " + Player.score + "\nHealth: " + Player.health;
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
            GameObject impact_instant = Instantiate(impact, collision.transform);
            impact_instant.transform.SetParent(transform, true);

            health -= 10;
        }
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 2;

            GameObject impact_instant = Instantiate(impact, collision.transform);
            impact_instant.transform.SetParent(transform, true);

            gameObject.GetComponent<Material>();
        }

        if (collision.gameObject.tag == "Player" && !hasCollide)
        {
            health = 0;

            Player.health--;

            GameObject.Find("Canvas").GetComponent<Text>().text = "Score: " + Player.score + "\nHealth: " + Player.health;

            hasCollide = true;
        }
    }
}
