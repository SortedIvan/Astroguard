using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    [SerializeField] private GameObject planet;
    private bool rotating_left;
    public float speed;
    private Vector3 zAxis = new Vector3(0, 0, -1);


    private void Start()
    {
        this.planet = GameObject.Find("Planet");
        rotating_left = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rotating_left = !rotating_left;
        }
        transform.RotateAround(planet.transform.position, zAxis, speed);
    }


    // Update is called once per fram

    private void SwitchPosition()
    {

    }


    //private void FixedUpdate()
    //{
    //    if (rotating_left)
    //    {
    //        transform.Rotate(planet.transform.position.x, planet.transform.position.y, -1f * Time.deltaTime * 5f);
    //    }
    //    transform.Rotate(planet.transform.position.x, planet.transform.position.y, 1f * Time.deltaTime * 5f);
    //}
}
