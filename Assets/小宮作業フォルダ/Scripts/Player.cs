using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float RotateSpeed = 720f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = InputToDirection();
        float magnitude = direction.magnitude;

        if (Mathf.Approximately(magnitude, 0f) == false)
        {
            UpdateRotation(direction);
        }
    }

    private Vector3 InputToDirection() {
        Vector3 direction = new Vector3(0f, 0f, 0f);

        if (Input.GetKey(KeyCode.D))
        {
            direction.x += 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction.x -= 1f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            direction.z += 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction.z -= 1f;
        }

        return direction.normalized;
    }

    private void UpdateRotation(Vector3 direction)
    {
        Quaternion from = transform.rotation;
        Quaternion to = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(from, to, RotateSpeed * Time.deltaTime);
    }
}