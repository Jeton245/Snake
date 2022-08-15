using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;


    public void Start()
    {
        RandomPosition();
    }
    public void RandomPosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float PositionX = Random.Range(bounds.min.x, bounds.max.x);
        float PositionY = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(PositionX), Mathf.Round(PositionY), 0.0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            RandomPosition();
        }
    }
}
