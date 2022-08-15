using UnityEngine;
using System.Collections.Generic;
public class SnakeMove : MonoBehaviour
{
    private List<Transform> _segments = new List<Transform>();
    private Vector2 _direction = Vector2.right;
    public Transform segmentPrefab;

    public int inistalition = 4;
    public void Start()
    {
        Restart();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
           _direction = Vector2.up;
        }else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
        }
    }

    public void FixedUpdate()
    {
        for(int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
             Mathf.Round(this.transform.position.x) + _direction.x,
             Mathf.Round(this.transform.position.y) + _direction.y,
             0.0f
            );
    }

    public void Restart()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i < this.inistalition; i++)
        {
            _segments.Add(Instantiate(segmentPrefab));
        }

            this.transform.position = Vector3.zero;
        
    }
    public void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = _segments[_segments.Count -1].position;
        _segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Food")
        {
            Grow();
        }else if (other.tag == "Obstacal")
        {
            Restart();
        }
    }

}
