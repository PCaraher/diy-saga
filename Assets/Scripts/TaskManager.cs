using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TaskManager : MonoBehaviour {


    public int columns = 2;
    public int rows = 5;
    public GameObject task;
    private Transform taskHolder;

    private List<Vector3> gridPositions = new List<Vector3>();


    void InitialiseList()
    {
        gridPositions.Clear();

        for (int x = -columns; x < columns - 1; x++)
        {

            for (int y = -rows; y < rows - 1; y++)
            {

                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }


    void TaskPlacement()
    {

        taskHolder = new GameObject("Tasks").transform;

        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = task;

                GameObject instance =
                    Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(taskHolder);
            }
        }
    }

    Vector3 RandomPosition ()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);

        Vector3 randomPosition = gridPositions[randomIndex];

        gridPositions.RemoveAt(randomIndex);

        return randomPosition;

    }

    void LayoutOjectAtRandom(int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();

            Instantiate(task, randomPosition, Quaternion.identity);
        }
    }


    public void SetupScene()
    {
        InitialiseList();
        LayoutOjectAtRandom(1, 4);
    }

  
}
