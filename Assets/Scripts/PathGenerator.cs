using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;

public class PathGenerator
{
    private int width, height; 
    private List<Vector2Int> pathCells; 


    public PathGenerator(int width, int height)
    {
        this.width = width; 
        this.height = height;
    }

    


    public List<Vector2Int> GeneratePath()
    {
        pathCells = new List<Vector2Int>();
        int y = (int)(height/2);
        int x = 0;

         /*
        for (int x = 0; x < width; x++)
        {
            pathCells.Add(new Vector2Int(x, y));
        }   
        */     

        while (x < width)
        {
            pathCells.Add(new Vector2Int(x, y));

            bool validMove = false;

            while (!validMove)
            {
                int move = Random.Range(0,3);

                if (move == 0 || x % 2 == 0 || x > (width - 2))
                {
                    x++; 
                    validMove = true;
                }
                else if (move == 1 && CellIsEmpty(x, y + 1) && y < (height - 2))
                {
                    y++;
                    validMove = true;
                }
                else if (move == 2 && CellIsEmpty(x, y - 1) && y > 2)
                {
                    y--; 
                    validMove = true;
                }
            }
        }

        return pathCells;
    }

    public bool CellIsEmpty(int x, int y)
    {
        return !pathCells.Contains(new Vector2Int(x,y));
    }

    //inverse de cellisempty
    public bool CellIsTaken(int x, int y)
    {
        return pathCells.Contains(new Vector2Int(x,y));
    }


    /*
    Pour trouver les deux cases adjascentes et savoir quel gameobject et quelle rotation faire
    En gros le schema est : 
        8
      2 C 4
        1
    Avec C la case sur laquelle on met le skin
    */
    public int getCellNeighbourValue(int x, int y)
    {
        int returnValue = 0; 

        if(CellIsTaken(x, y - 1))
        {
            returnValue += 1; 
        }
        if(CellIsTaken(x - 1, y))
        {
            returnValue += 2; 
        }
        if(CellIsTaken(x + 1, y))
        {
            returnValue += 4; 
        }
        if(CellIsTaken(x, y + 1))
        {
            returnValue += 8; 
        }

        return returnValue;
    }

    
}
