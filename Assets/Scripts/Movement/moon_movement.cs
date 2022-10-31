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

    public float radius = 8f;

    // Possible control combiations
    public KeyCode switch_rotation_moon_a;
    public KeyCode speed_up_rotation_moon_a;

    public KeyCode switch_rotation_moon_b;
    public KeyCode speed_up_rotation_moon_b;

    private Vector3 planet_position;
    private bool rotating_left;


    private void Start()
    {
        rotating_left = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(switch_rotation_moon_a))
        {
            rotating_left = !rotating_left;
        }
    }

    private void FixedUpdate()
    {
        planet_position = radius * Vector3.Normalize(this.transform.position - planet.transform.position) + planet.transform.position;
        this.transform.position = planet_position;
        if (rotating_left)
        {
            transform.RotateAround(planet.transform.position, new Vector3(0, 0, 1), rotation_speed);
        }
        transform.RotateAround(planet.transform.position, new Vector3(0, 0, -1), rotation_speed);
    }

}
