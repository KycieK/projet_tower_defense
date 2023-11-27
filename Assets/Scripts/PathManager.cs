using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{


    public int gridWidth = 16;
    public int gridHeight = 8;

    public int minPathLength = 30;

    public GameObject pathTile; 

    private PathGenerator pathGenerator; 

    // Start is called before the first frame update
    void Start()
    {
        pathGenerator = new PathGenerator(gridWidth, gridHeight);

        List<Vector2Int> pathCells = pathGenerator.GeneratePath();
        int pathSize = pathCells.Count;

        while(pathSize < minPathLength)
        {
            pathCells = pathGenerator.GeneratePath();
            pathSize = pathCells.Count;
        }

        StartCoroutine(LayPathCells(pathCells));
    }

    private IEnumerator LayPathCells(List<Vector2Int> pathCells){

        foreach (Vector2Int pathCell in pathCells)
        {
            Instantiate(pathTile, new Vector3(pathCell.x, 0f, pathCell.y), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
        
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
