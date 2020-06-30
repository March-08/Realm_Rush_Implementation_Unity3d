using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour{

    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit=5;
    [SerializeField] GameObject towerParentTransform;    
    Queue<Tower> towerQueue = new Queue<Tower>();

    public Waypoint baseWaypoint;   //where the tower is standing on

    int numTowers=0;

    public void AddTower(Waypoint baseWaypoint) {

        int numTowers = towerQueue.Count;

        if (numTowers<towerLimit) {
            InstantiateNewTower(baseWaypoint);
        }
        else {
            MoveExistingTower(baseWaypoint);    // todo move!
        }

    }

    private  void MoveExistingTower(Waypoint newBaseWaypoint) {
        var oldTower = towerQueue.Dequeue();
        
        oldTower.baseWaypoint.isPlaceable = true;
        newBaseWaypoint.isPlaceable = false;
        oldTower.baseWaypoint = newBaseWaypoint;
        oldTower.transform.position = newBaseWaypoint.transform.position;

        towerQueue.Enqueue(oldTower);



    }

    private void InstantiateNewTower(Waypoint baseWaypoint) {
        var newTower=Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.SetParent(towerParentTransform.transform);
        baseWaypoint.isPlaceable = false;
        numTowers += 1;
        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;
        towerQueue.Enqueue(newTower);



    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
