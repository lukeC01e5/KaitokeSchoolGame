using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipTrap : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;

    private SpriteRenderer sprite;

    public float oldPosition;
    public bool movingRight = false;
    public bool movingLeft = false;

    private void Start()
    {
        oldPosition = transform.position.x;
        sprite = GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            sprite.flipX = true;
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                sprite.flipX = false;
                currentWaypointIndex = 0;
            }
        }
       
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
