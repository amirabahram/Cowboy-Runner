using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstacles;

    private List<GameObject> obstaclesSpawning = new List<GameObject>();

    private void Awake()
    {
        InitializeObstacles();
    }
    private void Start()
    {
        StartCoroutine(SpawnRandomObstacle());
    }
    void InitializeObstacles()
    {
        int index = 0;
        for(int i = 0 ; i< obstacles.Length * 3 ; i++)
        {
            GameObject obj = Instantiate(obstacles[index],new Vector3(transform.position.x,
                transform.position.y, -2), Quaternion.identity) as GameObject;
            obstaclesSpawning.Add(obj);
            obstaclesSpawning[i].SetActive(false);
            index++;
            if(index == obstacles.Length) index = 0;
        }
    }

    void Shuffle()
    {
        for (int i = 0; i < obstaclesSpawning.Count; i++)
        {
            GameObject temp = obstacles[i];
            int randomIndex = Random.Range(i, obstaclesSpawning.Count);
            obstacles[i] = obstacles[randomIndex];
            obstacles[randomIndex] = temp;
        }
    }

    IEnumerator SpawnRandomObstacle()
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 4.5f));
        int index = Random.Range(0, obstaclesSpawning.Count);
        while (true)
        {
            if (!obstaclesSpawning[index].activeInHierarchy)
            {
                obstaclesSpawning[index].SetActive(true);
                obstaclesSpawning[index].transform.position = new Vector3(transform.position.x,
                transform.position.y, -2);
                break;
            }
            else
            {
                index = Random.Range(0,obstaclesSpawning.Count);

            }
        }
        StartCoroutine(SpawnRandomObstacle());
    }
}
