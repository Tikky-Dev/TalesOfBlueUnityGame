using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public Transform[] startPosition;
    public GameObject[] rooms;

    public void Start()
    {
        int randStartingPosition = Random.Range(0, startPosition.Length);
        transform.position = startPosition[randStartingPosition].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);
    }
}
