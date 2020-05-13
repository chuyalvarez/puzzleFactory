using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem: MonoBehaviour
{
    [SerializeField]
    private int gridSize=10;
    [SerializeField]
    private int gridScale=1;

    private Tile[,] grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Tile[gridSize, gridSize];
        for(int i=0;i<gridSize;i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                grid[i, j] = new Tile();
            }
        } 
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var calc = CalculateGridSpace(ray.GetPoint(10));
            if (calc.valid)
            {
                AddMachine(calc.x, calc.y);
            }
            
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var calc = CalculateGridSpace(ray.GetPoint(10));
            if (calc.valid)
            {
                AddToStorage(calc.x, calc.y);
            }
        }

    }


    private (bool valid, int x,int y) CalculateGridSpace(Vector3 point)
    {
        int x = (int)Mathf.Floor(point.x / gridScale);
        int y = (int)Mathf.Floor(point.y / gridScale);
        if (x < 0 || x > gridSize || y < 0 || y > gridSize)
        {
            return (false,-1,-1);
        }
        else
        {
            return (true,x, y);
        }
        
    }

    private void AddMachine(int posx,int posy)
    {
        grid[posx, posy].SetContent(new Machine());
        Debug.Log("Clicked= x:" + posx + " y:" + posy + " val:" + grid[posx, posy].GetContent().getStorage());
    }

    private void AddToStorage(int posx, int posy)
    {
        grid[posx, posy].GetContent().setStorage("Iron");
        Debug.Log("Clicked= x:" + posx + " y:" + posy + " val:" + grid[posx, posy].GetContent().getStorage());
    }
}
