using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameController GameController;
    void OnTriggerEnter2D(Collider2D col)
    {
        
        string tag = col.gameObject.tag;
        if (tag == "Bird" || tag == "Enemy" || tag == "Obstacle")
        {
            Destroy(col.gameObject);
            GameController.GetComponent<GameController>().isDestroyed = true;
            
        }
    }
}

