using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int points = 100; // how many points to give tht player upon collection
    // Start is called before the first frame update
    void Start()
    {
        points = Random.Range(100, 200);
        float scale = ((float)points) / 100;
        transform.localScale = new Vector3(scale, scale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<PlayerController>().addPoints(points);
            Destroy(this.gameObject); // уничтожит объект после столкновения
        }
    }
}
