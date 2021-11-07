using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class GridScript : MonoBehaviour
{ 
    public Grid grid;
    public Tile curTile;
    public AnimatedTile pushWaveLeft;
    public AnimatedTile pushWaveRight;
    public AnimatedTile pushWaveUp;
    public AnimatedTile pushWaveDown;
    public AnimatedTile pullWaveLeft;
    public AnimatedTile pullWaveRight;
    public AnimatedTile pullWaveUp;
    public AnimatedTile pullWaveDown;

    public Tile[] pushTiles;
    public Tile[] pullTiles;

    public Tilemap groundMap;
    public Tilemap toolMap;
    public Tilemap pushLeftMap;
    public Tilemap pushUpMap;
    public Tilemap pushRightMap;
    public Tilemap pushDownMap;
    public Tilemap pullLeftMap;
    public Tilemap pullUpMap;
    public Tilemap pullRightMap;
    public Tilemap pullDownMap;

    public Rigidbody2D trashrb;
    public GameObject ui;

    public string curInput = "gravity";

    private void Update()
    {
        CheckInputs();
    }

    public void CheckInputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            curInput = "push";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            curInput = "pull";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            curInput = "gravity";
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ui.GetComponent<UIController>().curLevel.attempts += 1;
            SceneManager.LoadScene(ui.GetComponent<UIController>().levelNum);
        }
    }

    public void PlaceBlock(Vector3 pos)
    {
        if(curInput == "push" && ui.GetComponent<UIController>().pushNums > 0)
        {
            PlacePushTile(pos);
            ui.GetComponent<UIController>().pushNums -= 1;
        }
        else if(curInput == "pull" && ui.GetComponent<UIController>().pullNums > 0)
        {
            PlacePullTile(pos);
            ui.GetComponent<UIController>().pullNums -= 1;
        }
    }

    public void ChangeTrashGravity()
    {
        if (trashrb.gravityScale > 0)
        {
            trashrb.gravityScale = 0;
        }
        else
        { 
            trashrb.gravityScale = 3;
        }
    }

    public void PlacePushTile(Vector3 pos)
    {
        Vector3Int tilePos = grid.LocalToCell(pos);
        int direction = ClosestEdge(pos, tilePos);
        if (direction != 5 && CheckToolGrid(tilePos)) { 
            toolMap.SetTile(tilePos, pushTiles[direction]);
            PlacePushGravity(tilePos, direction);
        }   
    }

    public void PlacePullTile(Vector3 pos)
    {
        Vector3Int tilePos = grid.LocalToCell(pos);
        int direction = ClosestEdge(pos, tilePos);
        if (direction != 5 && CheckToolGrid(tilePos))
        {
            toolMap.SetTile(tilePos, pullTiles[direction]);
            PlacePullGravity(tilePos, direction);
        }
    }

    int ClosestEdge(Vector3 pos,Vector3Int tilePos)//returns pointing [down,left,up,right]
    {
        Vector3[] edges = {new Vector3(tilePos.x+0.5f,tilePos.y+1,0), new Vector3(tilePos.x + 1, tilePos.y + 0.5f, 0),
            new Vector3(tilePos.x + 0.5f, tilePos.y, 0),new Vector3(tilePos.x,tilePos.y+0.5f,0)};//[top,right,bottom,left]
        float minDist = 1;
        int closestIndex = 5;
        for(int i=0; i < edges.Length; i++)
        {
            Debug.Log(Vector3.Distance(pos, edges[i]));
            if (Vector3.Distance(pos, edges[i])<minDist)
            {
                if (i == 0 && groundMap.HasTile(tilePos+new Vector3Int(0,1,0)))
                {
                    Debug.Log(i);
                    minDist = Vector3.Distance(pos, edges[i]);
                    closestIndex = i;
                }
                if (i == 1 && groundMap.HasTile(tilePos + new Vector3Int(1, 0, 0)))
                {
                    Debug.Log(i);
                    minDist = Vector3.Distance(pos, edges[i]);
                    closestIndex = i;
                }
                if (i == 2 && groundMap.HasTile(tilePos + new Vector3Int(0, -1, 0)))
                {
                    Debug.Log(i);
                    minDist = Vector3.Distance(pos, edges[i]);
                    closestIndex = i;
                }
                if (i == 3 && groundMap.HasTile(tilePos + new Vector3Int(-1, 0, 0)))
                {
                    Debug.Log(i);
                    minDist = Vector3.Distance(pos, edges[i]);
                    closestIndex = i;
                }
            }
        }
        return closestIndex;
    }

    bool CheckToolGrid(Vector3Int tilePos)
    {
        if (toolMap.HasTile(tilePos))
        {
            return false;
        }
        return true;
    }

    void PlacePushGravity(Vector3Int tilePos,int direction)
    {
        if(direction == 0)//down
        {
            while (!groundMap.HasTile(tilePos))
            {
                pushDownMap.SetTile(tilePos, pushWaveDown);
                tilePos += new Vector3Int(0, -1, 0);
            }
        }else if(direction == 1)//left
        {
            while (!groundMap.HasTile(tilePos))
            {
                pushLeftMap.SetTile(tilePos, pushWaveLeft);
                tilePos += new Vector3Int(-1, 0, 0);
            }
        }
        else if(direction == 2)//up
        {
            while (!groundMap.HasTile(tilePos))
            {
                pushUpMap.SetTile(tilePos, pushWaveUp);
                tilePos += new Vector3Int(0, 1, 0);
            }
        }
        else//right
        {
            while (!groundMap.HasTile(tilePos))
            {
                pushRightMap.SetTile(tilePos, pushWaveRight);
                tilePos += new Vector3Int(1, 0, 0);
            }
        }
    }

    void PlacePullGravity(Vector3Int tilePos, int direction)
    {
        if (direction == 0)//down
        {
            while (!groundMap.HasTile(tilePos))
            {
                pullDownMap.SetTile(tilePos, pullWaveUp);
                tilePos += new Vector3Int(0, -1, 0);
            }
        }
        else if (direction == 1)//left
        {
            while (!groundMap.HasTile(tilePos))
            {
                pullLeftMap.SetTile(tilePos, pullWaveRight);
                tilePos += new Vector3Int(-1, 0, 0);
            }
        }
        else if (direction == 2)//up
        {
            while (!groundMap.HasTile(tilePos))
            {
                pullUpMap.SetTile(tilePos, pullWaveDown);
                tilePos += new Vector3Int(0, 1, 0);
            }
        }
        else//right
        {
            while (!groundMap.HasTile(tilePos))
            {
                pullRightMap.SetTile(tilePos, pullWaveLeft);
                tilePos += new Vector3Int(1, 0, 0);
            }
        }
    }

    public void BeatLevel()
    {
        SceneManager.LoadScene(ui.GetComponent<UIController>().levelNum + 1);
    }
}
