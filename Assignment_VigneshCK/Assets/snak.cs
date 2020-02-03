using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
public class snak : MonoBehaviour
{
    
    public GameObject tailPrefab;
    public GameObject[] food;
    public Transform rightedge;
    public Transform leftedge;
    public Transform upedge;
    public Transform downedge;
    public int zfood;
    public int sped = 10;
    private float speed = 0.1f;
   
    Vector2 vector = Vector2.up;
    Vector2 moveVector;

    List<Transform> tail = new List<Transform>();

    bool eat = false;
    bool vertical = false;
    bool horizontal = true;

    void Start()
    {
        vector = Vector2.up * sped;
        SpawnFood();
        InvokeRepeating("Movement", 0.3f, speed);

    }

    void Update()
    {
       
        if (Input.GetKey(KeyCode.RightArrow) && horizontal)
        {
            horizontal = false;
            vertical = true;
            vector = Vector2.right*sped;
        }
        else if (Input.GetKey(KeyCode.UpArrow) && vertical)
        {
            horizontal = true;
            vertical = false;
            vector = Vector2.up*sped;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && vertical)
        {
            horizontal = true;
            vertical = false;
            vector = -Vector2.up*sped;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && horizontal)
        {
            horizontal = false;
            vertical = true;
            vector = -Vector2.right*sped;
        }
        moveVector = vector / 3f;

    }

    public void SpawnFood()
    {
        int x = (int)Random.Range(leftedge.position.x+7, rightedge.position.x-7);
        int y = (int)Random.Range(downedge.position.y+7, upedge.position.y-7);
        Instantiate(food[Random.Range (0,2)], new Vector3(x, y, zfood), Quaternion.identity);
     
    }

    void Movement()
    {

        Vector3 ta = transform.position;
        if (eat)
        {
           
            GameObject g = (GameObject)Instantiate(tailPrefab, ta, Quaternion.identity);

            tail.Insert(0, g.transform);
           
            eat = false;
        }
        else if (tail.Count > 0)
        {
            tail.Last().position = ta;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
        transform.Translate(moveVector);
    }

    void OnTriggerEnter(Collider c)
    {

        if (c.gameObject.tag == "food")
        {

            score.a += 10;
            eat = true;
            Destroy(c.gameObject);
            SpawnFood();
        }
        else if(c.gameObject.tag == "food1")
        {

            score.a += 20;
            eat = true;
            Destroy(c.gameObject);
            SpawnFood();
        }
        else if (c.gameObject.tag == "edge")
        {   
                SceneManager.LoadScene("score");   
        }



    }
}

