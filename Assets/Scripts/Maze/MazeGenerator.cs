using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public Transform[] startPosition;
    public GameObject[] rooms; // 0: LR, 1: LRB, 2: LRBT, 3: LRT;

    private int directions;
    public float moveAmount = 7;

    private float timeBtwRooms;
    public float startTimeBtwRooms = 0.25f;

    public float minX;
    public float maxX;
    public float minY;

    public bool stopGeneration = false;

    public LayerMask room;


    private int downCounter;

    public void Start()
    {
        int randStartingPosition = Random.Range(0, startPosition.Length);
        transform.position = startPosition[randStartingPosition].position;
        Instantiate(rooms[2], transform.position, Quaternion.identity);

        directions = Random.Range(1, 6);
    }

    public void Update()
    {
        if (timeBtwRooms <= 0 && !stopGeneration)
        {
            Move();
            timeBtwRooms = startTimeBtwRooms;
        }
        else {
            timeBtwRooms -= Time.deltaTime;
        }
    }

    public void Move() {
        if (directions == 1 || directions == 2) {//move Right
            if (transform.position.x < maxX) {

                downCounter = 0;

                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;

                Instantiate(rooms[Random.Range(0, rooms.Length)], transform.position, Quaternion.identity);

                directions = Random.Range(1, 6);
                if (directions == 3) {
                    directions = 2;
                } else if (directions == 4) {
                    directions = 5;
                }
            }
            else
            {
                directions = 5;
            }
            
        } else if (directions == 3 || directions == 4) {//move Left
            if (transform.position.x > minX)
            {
                downCounter = 0;

                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;

                Instantiate(rooms[Random.Range(0, rooms.Length)], transform.position, Quaternion.identity);

                directions = Random.Range(3, 6);
            }
            else {
                directions = 5;
            }

            
        } else if (directions == 5) {//move Down

            downCounter++;

            if (transform.position.y > minY)
            {

                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
                if (roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>().type != 2) {

                    if (downCounter > 1)
                    {
                        roomDetection.GetComponent<RoomType>().destroyRoom();

                        Instantiate(rooms[2], transform.position, Quaternion.identity);
                    }
                    else {
                        roomDetection.GetComponent<RoomType>().destroyRoom();

                        Instantiate(rooms[Random.Range(1, 3)], transform.position, Quaternion.identity);
                    }
                    
                    
                }

                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;

                Instantiate(rooms[Random.Range(2, rooms.Length)], transform.position, Quaternion.identity);

                directions = Random.Range(1, 6);
            }
            else {
                stopGeneration = true;
            }
            
        }

    }
}
