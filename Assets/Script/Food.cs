using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Food : MonoBehaviour
{   
    float wall_size = 1.5f;
    public TilemapCollider2D tc;
    // Start is called before the first frame update
    void Start()
    {
        RaPosition();
    }

    // Update is called once per frame
    void RaPosition()
    {
        Bounds bounds = tc.bounds;
        float x = Random.Range(bounds.min.x + wall_size, bounds.max.x - wall_size);
        float y = Random.Range(bounds.min.y + wall_size, bounds.max.y - wall_size);
        this.transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {       
            RaPosition();
        }
    }
}
