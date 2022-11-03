using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    Vector2 rawVector; 
    float speed = 50;

    private void FixedUpdate() 
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        rawVector = context.ReadValue<Vector2>();
    }

    public void Move()
    {
        if (rawVector.sqrMagnitude < 0.01)
            return;

        float scaledSpeed = speed * Time.deltaTime;

        var newPosition = new Vector3(rawVector.x * scaledSpeed, rawVector.y * scaledSpeed, 0f);

        transform.position += newPosition; 
    }
}
