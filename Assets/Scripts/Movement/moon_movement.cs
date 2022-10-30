using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moon_movement : MonoBehaviour
{
    public GameObject planet;
    public GameObject moon_a;
    public GameObject moon_b;
    public float rotation_speed;
    public bool player_is_controlling_a;
    public bool player_is_controlling_b;

    private float radius = 2f;


    //int[] array1 = new int[] { 1, 3, 5, 7, 9 };
    private KeyCode[] movement_keys_a = new KeyCode[]
    {
        KeyCode.Q, KeyCode.W
    };

    private KeyCode[] movement_keys_b = new KeyCode[]
    {
       KeyCode.O, KeyCode.P
    };

    // Update is called once per frame
    void Update()
    {
        set_player_controlling_moon_a();
        set_player_controlling_moon_b();
        circular_motion();
    }

    private void circular_motion()
    {
        Vector3 circleCenter = new Vector3(planet.transform.position.x, planet.transform.position.y, 0);
        if (player_is_controlling_a)
        {
            Vector3 offset = moon_a.transform.position - circleCenter;
            offset.Normalize();
            offset = offset * radius;
            moon_a.transform.position = offset;
        }
        if (player_is_controlling_b)
        {
            Vector3 offset = moon_b.transform.position - circleCenter;
            offset.Normalize();
            offset = offset * radius;
            moon_b.transform.position = offset;
        }


    }

    private void set_player_controlling_moon_a()
    {
        for (int i = 0; i < movement_keys_a.Length; i++)
        {
            if (Input.GetKey(movement_keys_a[i]))
            {
                player_is_controlling_a = true;
                if (movement_keys_a[i] == KeyCode.Q)
                {
                    //moon_a.transform.position += rotation_speed * Time.deltaTime * Vector3.up;
                    moon_a.GetComponent<Rigidbody2D>().MovePosition(new Vector2(1, 0) * rotation_speed * Time.deltaTime);
                }
                if (movement_keys_a[i] == KeyCode.W)
                {
                    //moon_a.transform.position += rotation_speed * Time.deltaTime * Vector3.down;
                    moon_a.GetComponent<Rigidbody2D>().MovePosition(new Vector2(0, 1) * rotation_speed * Time.deltaTime);
                }
            }
            if (Input.GetKeyUp(movement_keys_a[i]) && player_is_controlling_a)
            {
                player_is_controlling_a = false;
            }

        }
    }

    private void set_player_controlling_moon_b()
    {
        for (int i = 0; i < movement_keys_b.Length; i++)
        {
            if (Input.GetKey(movement_keys_b[i]))
            {
                player_is_controlling_b = true;
            }
            if (Input.GetKeyUp(movement_keys_b[i]) && player_is_controlling_b)
            {
                player_is_controlling_b = false;
            }
           
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
