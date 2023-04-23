using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject[] Obstacles;
    public bool checkMoves = false;
   public float tileSize = 1f;
    public Vector3 targetPosition;
    public EnemyMovement _enemyMove;
    public PlayerSquare _playerSq;
    //public int x, y;
     

    void Start()
    {
        targetPosition = transform.position;
        Obstacles =GameObject.FindGameObjectsWithTag("Obstacles");
        
         // set initial position of player square
       // transform.position = new Vector3(x, y, 0);
    }
    
    void Update()
    {
        // check if player square is selected
         if (_playerSq.isSelected)
        {

           if (Input.GetKeyDown(KeyCode.RightArrow) && (transform.position.x < 13) && !CheckObstacle(new Vector3(tileSize, 0, 0)))
        {
            transform.position += new Vector3(tileSize, 0, 0);
            checkMoves = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && (transform.position.x > 0) && !CheckObstacle(new Vector3(-tileSize, 0, 0)))
        {
            transform.position += new Vector3(-tileSize, 0, 0);
            checkMoves = true;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && (transform.position.y < 8) && !CheckObstacle(new Vector3(0, tileSize, 0)))
        {
            transform.position += new Vector3(0, tileSize, 0);
            checkMoves = true;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && (transform.position.y > 0) && !CheckObstacle(new Vector3(0, -tileSize, 0)))
        {
            transform.position += new Vector3(0, -tileSize, 0);
            checkMoves = true;
        }
        }
        
         
         
    }

     bool CheckObstacle(Vector3 direction)
    {
        Vector3 targetPos = transform.position + direction;
        Collider2D obstacle = Physics2D.OverlapBox(targetPos, new Vector2(0.9f, 0.9f), 0f);
        if (obstacle != null && obstacle.CompareTag("Obstacles"))
        {
            return true;
        }
        return false;
    }
}
