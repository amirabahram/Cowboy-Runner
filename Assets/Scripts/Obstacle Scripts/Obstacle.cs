using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D myBody;
    private float speed = -3f;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        myBody.velocity = new Vector2(speed, 0);
    }
}
