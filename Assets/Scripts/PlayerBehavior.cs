using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    
   public float speed;
   public float horizontalInput;
   public float verticalInput;
   public float horizontalScreenLimit;
   public float middleScreenLimit;
   public float verticalScreenLimit;
   public GameObject bulletPrefab;
   
    // Start is called before the first frame update
    void Start()
    {
        speed = 4f;
        horizontalScreenLimit = 9.5f;
        middleScreenLimit = 0.5f;
        verticalScreenLimit = -4f;
    }

    // Update is called once per frame
    void Update()
    {
       Movement();
       Shooting();
    }
    void Movement()
    {
         horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);
        if (transform.position.x > horizontalScreenLimit || transform.position.x < -horizontalScreenLimit)
        {
            transform.position = new Vector3(-horizontalScreenLimit, transform.position.y, 0);
        }
        else if (transform.position.x < -horizontalScreenLimit)
        {
            transform.position = new Vector3(horizontalScreenLimit, transform.position.y, 0);
        }

        if (transform.position.y > middleScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, verticalScreenLimit, 0);
        }
        else if (transform.position.y < verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, middleScreenLimit, 0);
        }
    }
 
    void Shooting()
    {
    if(Input.GetKeyDown(KeyCode.Space))
    {
    Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    }
    }
 }

