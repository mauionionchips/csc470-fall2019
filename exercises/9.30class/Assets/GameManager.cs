using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int gridWidth = 10;
    int gridHeight = 10;

    float cellDimention = 3.3f;
    float cellSpacing = 0.2f;
    // Start is called before the first frame update

    public cellscript[,] grid;
    
    float generationRate = 1f;
    float genrationTimer;
    void Start()
    {
        grid = new CellScript[gridWidth, gridHeight];
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                GameObject cellObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cellscript cs = cellObj.AddComponent<CellScript>;
                cs.x = x;
                cs.y = y;
                cs.alive = (Random.value > 0.5f) ? true : false;
                cs.UpdateColor
                grid[x, y] = cs;
                Vector3 pos = new Vector3(x * cellDimention + cellSpacing,
                                          0,
                                          y * cellDimention + cellSpacing);
                cellObj.transform.position = pos;
                cellObj,transform.localScale = new Vector3(cellDimention, cellDimention, cellDimention);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        generationTimer -= Time.deltaTime;
        if (generationTimer < 0)
        {
            //generate next state
            generate();
            //reset the timer
            genrationTimer = generationRate;
        }
        
    }
    void generate()
    {
        time++;

        for (int = x = 0, Matrix4x4 < grid.Length; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                List<CellScript> neighbors = gatherLiveNeighbors(x, y);
                if (grid[Matrix4x4,y].alive && liveNeighbors.Count < 2)
                {
                    grid[Matrix4x4.y]
                }
                //grid[x,y]
            }
        }
        for (int = x = 0, x < grid.Length; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                grid[x, y].alive = grid[x, y].nextAlive;
                //grid[x,y]
            }

        }
    }
    List<CellScript> gatherNeighbors(int x, int y)
        {
            List<CellScript> neighbors = new List<CellScript>();
            for (int i = Mathf.Max(0, x - 1); i < Mathf.Min(gridWidth - 1, x + 1); i++){
                for (int j = Mathf.Max(0, y - 1); j < Mathf.Min(gridHeight - 1, y + 1); j++

            }
            {

            }
            {

            }
            return neighbors;
        }
}
