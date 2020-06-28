using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour{

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;  //the current search center
    private List<Waypoint> path = new List<Waypoint>(); // todo make private

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.right,
        Vector2Int.left,
    };

    public List<Waypoint> GetPath() {
        if (path.Count == 0) {
            CalculatePath();

        }
        return path;
           
    }

    private void CalculatePath() {
        LoadBlocks();
        BreadthFirstSearch( );
        CreatePath();
    }


    private void CreatePath() {

        SetAsPath(endWaypoint);

        Waypoint previous = endWaypoint.exploredFrom;
        print("previous: " +previous);
        while (previous != startWaypoint) {

            previous = previous.exploredFrom;
            SetAsPath(previous);    

        }

        SetAsPath(startWaypoint);
        path.Reverse();
    }

    private void SetAsPath(Waypoint waypoint) {
        path.Add(waypoint);
        waypoint.isPlaceable = false;
    }

    private void BreadthFirstSearch() {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning) {
           
            searchCenter=queue.Dequeue();
            searchCenter.isExplored = true; 
            HaltIfEndFound();   //controllo se ho raggiunto il target
            ExploreNeighbours();
        }

    }

    private void HaltIfEndFound() {
        if (searchCenter == endWaypoint) {
            isRunning = false;
        }
    }

    private void ExploreNeighbours() {

        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions) {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;

            if(grid.ContainsKey(neighbourCoordinates)){
                QueueNewNeighbours(neighbourCoordinates);
            }
           
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates) {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour)){
            //do nothing
        }
        else{
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
        
    }

  

    private void LoadBlocks() {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints) {

            var gridPos = waypoint.GetGridPos();
            
            if (grid.ContainsKey(gridPos)) {
                Debug.LogWarning("Skipping overlapping block " + waypoint.name);
            }
            else {
                grid.Add(gridPos, waypoint);

            }

        }
        print("loaded "+ grid.Count+ " blocks");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
