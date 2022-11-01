using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    [Header("Adjustable Variables")]
    [SerializeField] private GameObject moonA;
    [SerializeField] private GameObject moonB;
    public float rotationSpeedMoonA;
    public float rotationSpeedMoonB;
    public float radiusOrbitMoonA = 6f;
    public float radiusOrbitMoonB = 11f;
    public float maxRotationSpeed;

    [Header("Controls")]
    public KeyCode switchRotationMoonA;
    public KeyCode speedRotationMoonA;
    public KeyCode switchRotationMoonB;
    public KeyCode speedRotationMoonB;

    private Vector3 moonPositionA;
    private Vector3 moonPositionB;
    private bool rotatingLeftA;
    private bool rotatingLeftB;


    private void Start()
    {
        rotatingLeftA = false;
        rotatingLeftB = false;
        // Instead of assigning in inspector, we find the objects by name
        moonA = GameObject.Find("MoonA");
        moonB = GameObject.Find("MoonB");
    }

    private void Update()
    {

    }


    private void FixedUpdate()
    {
        ControlMoons();
        RotateMoonA();
        RotateMoonB();
    }

    // Given the controls by the player, the moons can either switch their rotation
    // or speed up slowly.
    private void ControlMoons()
    {
        #region Moon A Controls
        if (Input.GetKeyDown(switchRotationMoonA))
        {
            rotatingLeftA = !rotatingLeftA;
        }

        if (Input.GetKey(speedRotationMoonA))
        {
            if (maxRotationSpeed <= rotationSpeedMoonA)
            {
                rotationSpeedMoonA = maxRotationSpeed;
            }
            rotationSpeedMoonA += (float)Time.deltaTime;
        }
        #endregion

        #region Moon B Controls
        if (Input.GetKeyDown(switchRotationMoonB))
        {
            rotatingLeftB = !rotatingLeftB;
        }

        if (Input.GetKey(speedRotationMoonB))
        {
            if (maxRotationSpeed <= rotationSpeedMoonB)
            {
                rotationSpeedMoonB = maxRotationSpeed;
            }
            rotationSpeedMoonB += (float)Time.deltaTime;
        }
        #endregion
    }

    private void RotateMoonA()
    {
        moonPositionA = radiusOrbitMoonA * Vector3.Normalize(moonA.transform.position - transform.position) + transform.position;
        moonA.transform.position = moonPositionA;
        if (rotatingLeftA)
        {
            transform.RotateAround(transform.position, new Vector3(0, 0, 1), rotationSpeedMoonA);
        }
        else
        {
            transform.RotateAround(transform.position, new Vector3(0, 0, -1), rotationSpeedMoonA);
        }
    }

    private void RotateMoonB()
    {
        moonPositionB = radiusOrbitMoonB * Vector3.Normalize(moonB.transform.position - transform.position) + transform.position;
        moonB.transform.position = moonPositionB;
        if (rotatingLeftB)
        {
            transform.RotateAround(transform.position, new Vector3(0, 0, 1), rotationSpeedMoonB);
        }
        else
        {
            transform.RotateAround(transform.position, new Vector3(0, 0, -1), rotationSpeedMoonB);
        }
    }
}
