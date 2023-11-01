using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDied : MonoBehaviour
{
    public delegate void EndGame();
    public static event EndGame endGame;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collector")
        {
            PlayerDiedEndGame();
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Zombie")
        {
            PlayerDiedEndGame();
        }
    }
    protected virtual void PlayerDiedEndGame()
    {
        if (endGame != null) endGame();

        Destroy(gameObject);
    }
}
