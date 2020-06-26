using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerBe : MonoBehaviour
{
    private float speed = 1.0f;
    private float acceleration = 0.2f;
    private float maxSpeed = 3.2f;

    [HideInInspector]
    public bool moveCamera;

    private float easySpeed = 3.2f;
    private float mediumSpeed = 3.7f;
    private float hardSpeed = 4.2f;

    void Start()
    {

        if (GamePreferences.GetEasyDifficultyState() == 0)
        {
           maxSpeed = easySpeed;
        }

        if (GamePreferences.GetMediumDifficultyState() == 0)
        {
           maxSpeed = mediumSpeed;
        }

        if (GamePreferences.GetHardDifficultyState() == 0)
        {
           maxSpeed = hardSpeed;
        }

        moveCamera = true;
    }

    void Update()
    {
        if (moveCamera)
        {
            MoveCamera();
        }
    }

    void MoveCamera()
    {

        Vector3 temp = transform.position;

        float oldY = temp.y;

        float newY = temp.y - (speed * Time.deltaTime);

        temp.y = Mathf.Clamp(temp.y, oldY, newY);

        transform.position = temp;

        speed += acceleration * Time.deltaTime;

        if (speed > maxSpeed)
            speed = maxSpeed;

    }
}
