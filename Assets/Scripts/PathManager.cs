using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public int gridWidth = 16;
    public int gridHeight = 8;

    public int minPathLength = 30;

    public GridCellObject[] pathCellObjects;
    public GridCellObject[] sceneryCellObjects;
    
    private PathGenerator pathGenerator; 
    public bool mapCreated = false;

    public Vector3 startTilePosition;

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

        StartCoroutine(LayGrid(pathCells));
    }

    IEnumerator LayGrid(List<Vector2Int> pathCells)
    {
        yield return LayPathCells(pathCells);
        yield return LaySceneryCells();
        yield return mapCreated = true;
    }

    private IEnumerator LayPathCells(List<Vector2Int> pathCells){

        foreach (Vector2Int pathCell in pathCells)
        {
            int neighbourValue = pathGenerator.getCellNeighbourValue(pathCell.x, pathCell.y);

            GameObject pathTile = pathCellObjects[neighbourValue].cellPrefab;
            GameObject pathTileCell = Instantiate(pathTile, new Vector3(pathCell.x, 0f, pathCell.y), Quaternion.identity);
            pathTileCell.transform.Rotate(0f, pathCellObjects[neighbourValue].yRotation, 0f, Space.Self);

            if(neighbourValue == 2) startTilePosition = new Vector3(pathCell.x, 0f, pathCell.y);

            yield return new WaitForSeconds(0.025f);
        }
        
        yield return null;
    }

    IEnumerator LaySceneryCells()
    {
        for (int y = gridHeight; y > 0; y--)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                if(pathGenerator.CellIsEmpty(x, y))
                {
                    int randomSceneryCellIndex = Random.Range(0, sceneryCellObjects.Length);
                    Instantiate(sceneryCellObjects[randomSceneryCellIndex].cellPrefab, new Vector3(x, 0f, y), Quaternion.identity);
                    yield return new WaitForSeconds(0.0025f);
                }
            }
        }
        yield return null;
    }
}
