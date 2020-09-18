using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    public MazeGenerator mazeGenerator;
    public LayerMask room;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= mazeGenerator.minX && transform.position.x <= mazeGenerator.maxX && transform.position.y >= mazeGenerator.minY) {
            Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
            if (roomDetection == null && mazeGenerator.stopGeneration) {
                Instantiate(mazeGenerator.rooms[Random.Range(0, mazeGenerator.rooms.Length)], transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
