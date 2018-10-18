using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GameController : MonoBehaviour {

    public float speedY,speedX;
	void Start () {
        Globals.speedY = speedY;
        Globals.speedX = speedX;
    }
}
