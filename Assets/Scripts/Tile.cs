using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
      [SerializeField] private Color _onecolor;
    [SerializeField] private GameObject _highlight;
 
   

  void OnMouseEnter() { 
        _highlight.SetActive(true);
    }
 
    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}
