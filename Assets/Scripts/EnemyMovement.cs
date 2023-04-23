using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pair<T, U>
{
    public T First { get; set; }
    public U Second { get; set; }
 
    public Pair(T first, U second) {
        this.First = first;
        this.Second = second;
    }
 
    public override string ToString() {
        return $"({First}, {Second})";
    }
};


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public PlayerMovement _player;
    [SerializeField] private Tile _tilePrefab;
    // private int x =3, y=2;
    private List<Pair<int,int>> list1 = new List<Pair<int,int>>();
    private List<Pair<int,int>> list2 = new List<Pair<int,int>>();
    public float delay = 0.5f;
    float timer;
    static int NUM_ROWS = 14;
    static int NUM_COLS = 9;
    int[,] visited = new int[NUM_ROWS, NUM_COLS];

    void Start(){
        for(int i=0;i<NUM_ROWS;i++){
            for(int j=0;j<NUM_COLS;j++){
                visited[i,j] = -1;
            }
        }
        list1.Add(new Pair<int, int>(5,5));
        visited[5,5] = 1;
    }
  
    //private float moveDist = 1f;
    void Update()
    {
        
        if(_player.isMoving){
    

         timer += Time.deltaTime;
        if (timer > delay)
        {
            Spawnning();
        _player.isMoving = false;
        }
        
        }
        
    }

    public bool isValid(int x, int y) {
        return x >= 0 && x < NUM_ROWS && y>=0 && y < NUM_COLS;
    }

    public void Spawnning(){
        
            Debug.Log("Player is moving");
            // transform.position += new Vector3(moveDist, 0, 0);
            foreach(var val in list1){
                var x = val.First;
                var y = val.Second;
                
                int[] dx = new int []{0, 1, 0, -1};
                int[] dy = new int []{1, 0, -1, 0};

                for(int i=0;i<4;i++) {
                    int x1 = x + dx[i];
                    int y1 = y + dy[i];
                    if (isValid(x1, y1) && visited[x1,y1] == -1) {
                        visited[x1, y1] = 1;
                        Instantiate(_tilePrefab, new Vector3(x1, y1), Quaternion.identity);
                        list2.Add(new Pair<int, int>(x1, y1)); 
                    }
                }
                
            }
            

            list1.Clear();


            for(var i=0; i<list2.Count; i++){
                list1.Add(list2[i]);
            }

            list2.Clear();

    }
}
