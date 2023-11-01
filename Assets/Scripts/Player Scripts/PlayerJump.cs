using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private AudioClip jumpSound;
    private float jumpForce = 12f,forwardForce = 0.0f;
    private Rigidbody2D myBody;
    private bool canJump;
    private Button jumpButton;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        jumpButton = GameObject.Find("Jump Button").GetComponent<Button>();
        jumpButton.onClick.AddListener(() => Jump());
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(myBody.velocity.y) <5 && myBody.transform.position.y < 0.5)
        {
            canJump = true;
        }
    }
    public void Jump()
    {
        if(canJump)
        {
            canJump = false;
            if(transform.position.x <0)
            {
                forwardForce = 1f;
            }
            else
            {
                forwardForce = 0f;
            }
            myBody.velocity = new Vector2(forwardForce,jumpForce);
        }

    }
    
}
