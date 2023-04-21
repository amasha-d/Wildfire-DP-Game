using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject[] Obstacles;
   public float tileSize = 1f;
    public Vector3 targetPosition;
    public EnemyMovement _enemyMove;
    public bool isMoving = false;

    void Start()
    {
        targetPosition = transform.position;
        Obstacles =GameObject.FindGameObjectsWithTag("Obstacles");
    }
    /*public bool Blocked(Vector3 position){
        Vector2 newPos = new Vector2(position.x, position.y);
        foreach (var objs in Obstacles){
            if(objs.transform.position.x ==newPos.x && objs.transform.position.y == newPos.y)
            Debug.Log("It's in block");
            return true;           
        }
         return false;
    }
*/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && (transform.position.x < 14)  )
        {
           transform.position += new Vector3(tileSize, 0, 0);
            isMoving =true;
            
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && (transform.position.x > 0)  )
        {
            transform.position += new Vector3(-tileSize, 0, 0);
            isMoving =true;
            
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && (transform.position.y < 8  ))
        {
            transform.position += new Vector3(0, tileSize, 0);
            isMoving =true;
            
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && (transform.position.y > 0)  )
        {
            Debug.Log("Position" + transform.position);
                 //Debug.Log("inside If");
                transform.position += new Vector3(0, -tileSize, 0);
                isMoving =true;
                
             
        }
         
    }
}
