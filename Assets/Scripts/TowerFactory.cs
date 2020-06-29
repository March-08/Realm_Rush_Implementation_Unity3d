using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour{

    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit=5;

    int numTowers=0;

    public void AddTower(Waypoint baseWaypoint) {
        if (numTowers < towerLimit) {
            InstantiateNewTower(baseWaypoint);
        }
        else {
            MoveExistingTower();    // todo move!
        }

    }

    private static void MoveExistingTower() {
        print("limit reached");
    }

    private void InstantiateNewTower(Waypoint baseWaypoint) {
        Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;
        numTowers += 1;
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
