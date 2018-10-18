using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Circle : Obstacle {

    public float radius = 1.5f;
    public int amountOfBalls = 2;
    public int amountOfHoles = 0;
    public GameObject[] ball;
	void Start () {
        #region Verification
        if (radius < 1.5) { Debug.LogError("Radius Must be 1.5 or more"); }
        if (amountOfBalls < 2) { Debug.LogError("Amount of balls must be 2 or more"); }
        if (amountOfHoles > 0) { Debug.LogWarning("Amount of holes will override some balls"); };
        if (ball.Length < 1) { Debug.LogWarning("Ball has not been initialized"); };
        float circle = 2f * ((float)System.Math.PI) * radius;
        float amountOfBallsThatFit = circle / 0.5f;
        if (amountOfBallsThatFit < (amountOfBalls + amountOfHoles)) { Debug.LogError("The amount of balls and holes do not fit in that radius"); }

        #endregion

        movementVector = new Vector2(0f, Globals.speedY);
        
        //x2 + y2  = r2
        float eachAngle = 360f / (amountOfBalls);
        for(int x = 0; x < (amountOfBalls-amountOfHoles); x++)
        {
            double radian = (System.Math.PI / 180) * eachAngle * x;
            double ex = System.Math.Cos(radian);
            double y = System.Math.Sin(radian);
            Vector2 unitary = new Vector2((float)ex, (float)y);
            var Ball = Instantiate(ball[0], this.transform);
            Ball.transform.localPosition= unitary*radius;
        }
    }
    
    void FixedUpdate () {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, new Quaternion(0,0, transform.localRotation.z+1f,0f),Time.deltaTime);
        transform.Translate(movementVector * Time.deltaTime, Space.World);
    }
}
