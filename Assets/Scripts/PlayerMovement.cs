using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float tileSize = 1f;
    public Vector3 targetPosition;
    public bool isMoving = false;

    void Start()
    {
        targetPosition = transform.position;
    }

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
        else if (Input.GetKeyDown(KeyCode.UpArrow) && (transform.position.y < 9  ))
        {
            transform.position += new Vector3(0, tileSize, 0);
            isMoving =true;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && (transform.position.y > 0)  )
        {
            transform.position += new Vector3(0, -tileSize, 0);
            isMoving =true;
        }
         
    }
}
