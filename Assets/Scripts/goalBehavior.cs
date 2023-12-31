using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class goalBehavior : MonoBehaviour
{

    public bool playerOneTwo; // 0 for player one, 1 for player two

    public GameObject mainBall;

    public GameObject scorePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == mainBall.name)
        {
            //UnityEngine.Debug.Log("Ball Hit Goal");
            scorePanel.GetComponent<scoreManager>().updateScore(playerOneTwo);
            mainBall.GetComponent<BallPhysics>().ResetBall();
        }
    }
}
