using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform[] Positions;
    public GameObject[] Obstacles;
    public float TimeToShowNew;
    float lastCreated = 0;
	// Use this for initialization
	void Start () {
        if (Positions.Length < 9) { Debug.LogError("Positions have not been fully initialized"); }
        if (Obstacles.Length < 1) { Debug.LogError("Obstacles have not been fully initialized"); }
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time - lastCreated > TimeToShowNew) { lastCreated = Time.time; CreateNew(); }
	}
    
    void CreateNew()
    {
        int whatObstacle = Random.Range(0, Obstacles.Length);
        var obj = Instantiate(Obstacles[whatObstacle],this.transform);
        int position = 3;
        switch (whatObstacle)
        {
            case 0:
                position = Random.Range(3,9);
                break;
            case 1:
                position = Random.Range(0,3);
                break;
        }
        obj.transform.localPosition = Positions[position].position;
    }
}
