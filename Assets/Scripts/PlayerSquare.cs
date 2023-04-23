using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSquare : MonoBehaviour
{
    public  int x ;
    public  int y ;
    public  bool isSelected = false;

    public static PlayerSquare selectedSquare = null;

    private void OnMouseDown()
    {
        if (isSelected)
        {
            Deselect();
        }
        else
        {
            if (selectedSquare != null)
            {
                selectedSquare.Deselect();
            }
            Select();
        }
    }

    private void Select()
    {
        isSelected = true;
        GetComponent<SpriteRenderer>().color = Color.blue;
        selectedSquare = this;
    }

    private void Deselect()
    {
        isSelected = false;
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedSquare = null;
    }
}
