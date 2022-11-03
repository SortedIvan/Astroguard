using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    [Header("Adjustable Variables")]
    public GameObject moonA;
    public GameObject moonB;
    public GameObject planet;
    public float rotationSpeedMoonA;
    public float rotationSpeedMoonB;
    public float radiusOrbitMoonA = 6f;
    public float radiusOrbitMoonB = 11f;
    public float maxRotationSpeed;
    public float slowDownRate = 0.8f; // The bigger the value, the faster it slows down

    private float initRotSpeedA, initRotSpeedB;

    [Header("Controls")] // Controls customizable for moon movement
    public KeyCode switchRotationMoonA;
    public KeyCode speedRotationMoonA;
    public KeyCode switchRotationMoonB;
    public KeyCode speedRotationMoonB;

    private Vector3 moonPositionA;
    private Vector3 moonPositionB;
    private bool rotatingLeftA;
    private bool rotatingLeftB;

    // True when speed-up key is released to get to optimal speed
    private bool slowDownB, slowDownA;

    private void Start()
    {
        rotatingLeftA = false;
        rotatingLeftB = false;
        initRotSpeedA = rotationSpeedMoonA;
        initRotSpeedB = rotationSpeedMoonB;
    }

    private void Update()
    {
        ControlMoons();
    }



    private void FixedUpdate()
    {
        RotateMoonA();
        RotateMoonB();
        SlowDownMoons();
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
            slowDownA = false;
            if (maxRotationSpeed <= rotationSpeedMoonA)
            {
                rotationSpeedMoonA = maxRotationSpeed;
            }
            rotationSpeedMoonA += (float)Time.deltaTime;
        }
        if (Input.GetKeyUp(speedRotationMoonA))
        {
            slowDownA = true;
        }
        #endregion

        #region Moon B Controls
        if (Input.GetKeyDown(switchRotationMoonB))
        {
            rotatingLeftB = !rotatingLeftB;
        }

        if (Input.GetKey(speedRotationMoonB))
        {
            slowDownB = false;
            if (maxRotationSpeed <= rotationSpeedMoonB)
            {
                rotationSpeedMoonB = maxRotationSpeed;
            }
            rotationSpeedMoonB += (float)Time.deltaTime;
        }
        if (Input.GetKeyUp(speedRotationMoonB))
        {
            slowDownB = true;
        }
        #endregion
    }

    private void SlowDownMoons()
    {
        if (slowDownA)
        {
            if (rotationSpeedMoonA <= initRotSpeedA)
            {
                rotationSpeedMoonA = initRotSpeedA;
                slowDownA = false;
            }
            rotationSpeedMoonA -= (float)Time.deltaTime * slowDownRate;
        }
        if (slowDownB)
        {
            if (rotationSpeedMoonB <= initRotSpeedB)
            {
                rotationSpeedMoonB = initRotSpeedB;
                slowDownB = false;
            }
            rotationSpeedMoonB -= (float)Time.deltaTime * slowDownRate;
        }
    }

    private void RotateMoonA()
    {
        moonPositionA = radiusOrbitMoonA * Vector3.Normalize(moonA.transform.position - planet.transform.position) + planet.transform.position;
        moonA.transform.position = moonPositionA;
        if (rotatingLeftA)
        {
            moonA.transform.RotateAround(planet.transform.position, new Vector3(0, 0, 1), rotationSpeedMoonA);
        }
        else
        {
            moonA.transform.RotateAround(planet.transform.position, new Vector3(0, 0, -1), rotationSpeedMoonA);
        }
    }

    private void RotateMoonB()
    {
        moonPositionB = radiusOrbitMoonB * Vector3.Normalize(moonB.transform.position - planet.transform.position) + planet.transform.position;
        moonB.transform.position = moonPositionB;
        if (rotatingLeftB)
        {
            moonB.transform.RotateAround(planet.transform.position, new Vector3(0, 0, 1), rotationSpeedMoonB);
        }
        else
        {
            moonB.transform.RotateAround(planet.transform.position, new Vector3(0, 0, -1), rotationSpeedMoonB);
        }
    }   
}
