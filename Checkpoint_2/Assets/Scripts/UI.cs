using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
public int score;
    void Start()
    {

    }
    void Update()
    { 
    
    }
      private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"){
            score++;
            Destroy(gameObject);
        }
    }
}
