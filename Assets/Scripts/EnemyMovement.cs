using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    void Start(){
        list1.Add(new Pair<int, int>(5,5));
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
    void Spawnning(){
        
            Debug.Log("Player is moving");
            // transform.position += new Vector3(moveDist, 0, 0);
            foreach(var val in list1){
                var x = val.First;
                var y = val.Second;
                if(x+1<14 && y < 9){
                    Instantiate(_tilePrefab, new Vector3(x+1, y), Quaternion.identity);
                }
                // Instantiate(_tilePrefab, new Vector3(x+1, y), Quaternion.identity);
                if(x-1 >0 && y >0 && y<9){
                    Instantiate(_tilePrefab, new Vector3(x-1, y), Quaternion.identity);
                }
                // Instantiate(_tilePrefab, new Vector3(x-1, y), Quaternion.identity);
                if(x>=0 && x<14 && y-1>0){
                Instantiate(_tilePrefab, new Vector3(x, y-1), Quaternion.identity);
                }
                // Instantiate(_tilePrefab, new Vector3(x, y-1), Quaternion.identity);
                Instantiate(_tilePrefab, new Vector3(x, y+1), Quaternion.identity);
            }
            
            for(var i=0; i<list1.Count; i++){
                var x = list1[i].First;
                var y = list1[i].Second;
                if(x+1 < 9 && y < 9 && x>=0 && y>=0){
                    list2.Add(new Pair<int, int>(x+1, y));
                }
                if(x-1 >= 0 && y<9 && x+1 < 9 && y < 9 && x>=0 && y>=0){
                    list2.Add(new Pair<int, int>(x-1, y));
                }
                if(x < 9 && y-1 >= 0 && x+1 < 9 && y < 9 && x>=0 && y>=0){
                    list2.Add(new Pair<int, int>(x, y-1)); 
                }
                if(x < 9 && y >= 0 && x+1 < 9 && y < 9 && x>=0 && y>=0){
                    list2.Add(new Pair<int, int>(x, y+1));
                }
            }

            list1.Clear();


            for(var i=0; i<list2.Count; i++){
                list1.Add(list2[i]);
            }

            list2.Clear();

    }
}
