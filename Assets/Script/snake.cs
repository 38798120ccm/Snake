using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class snake : MonoBehaviour
{
    private Vector2 direcation = Vector2.right;
    List<Transform> segments = new List<Transform> {};
    public Transform segmentprefab;
    int initial_lenght = 2;
    int scores;
    public TextMeshProUGUI scores_board;
    void Start()
    {
        Restartstage();
    }
    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && direcation != Vector2.down)
        {
            direcation = Vector2.up;
        }
        else if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && direcation != Vector2.right)
        {
            direcation = Vector2.left;
        }
        else if((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && direcation != Vector2.up)
        {
            direcation = Vector2.down;
        }
        else if((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && direcation != Vector2.left)
        {
            direcation = Vector2.right;
        }
    }
    void FixedUpdate()
    {
        for (int i = segments.Count-1;i > 0;i--)
        {
            segments[i].position = segments[i-1].position;
        }
        this.transform.position = new Vector2(this.transform.position.x + direcation.x,this.transform.position.y + direcation.y);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Food")
        {
            Grow();
            scores++;
            ChangeScore(scores);
        }
        if(collider.tag == "Wall" || collider.tag == "Player")
        {
            Restartstage();
        }
    }
    void Grow()
    {
        Transform segment = Instantiate(segmentprefab);
        segment.position = segments[segments.Count-1].position;
        segments.Add(segment);
    }
    void Restartstage()
    {
        for(int i = 1;i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(this.transform);
        transform.position = Vector2.zero;
        for(int i = 0; i < initial_lenght; i++)
        {
            Grow();
        }
        scores = 0;
        ChangeScore(scores);
    }
    void ChangeScore(int score)
    {   
        scores_board.text = "Score:" + score;
    }
}
