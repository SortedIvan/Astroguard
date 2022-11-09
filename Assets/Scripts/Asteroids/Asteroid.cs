using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private GameObject Planet;
    private float damageUponHit;
    private float size;
    private float movementSpeed = 10f;
    private Vector2 moveDirection;


    private void Start()
    {
        Planet = GameObject.Find("Planet");
        moveDirection = ((Vector2)Planet.transform.position - new Vector2(transform.position.x, transform.position.y)).normalized* movementSpeed;
        transform.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 15f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Planet"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Moon"))
        {
            Destroy(gameObject);
        }

    }

}
