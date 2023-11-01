using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.1f;
   // private Vector2 offset= Vector2.zero;
    private Material mat;
    private float distance;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
       // offset = mat.GetTextureOffset("_MainTex");

    }

    // Update is called once per frame
    void Update()
    {
        distance += speed * Time.deltaTime;
        mat.SetTextureOffset("_MainTex", Vector2.right*distance);

    }
}
