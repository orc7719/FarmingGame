using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    float speed = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("left click detected");
            StopCoroutine("CharacterMovement");
            StartCoroutine("CharacterMovement");
        }
    }
    Vector2 Get2DMousePosition()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector2(pos.x, pos.y);
    }
    IEnumerator CharacterMovement()
    {
        Vector2 targetPosition = Get2DMousePosition();
        Vector2 originalPosition = transform.position;
        Vector2 directionVector = targetPosition - originalPosition;
        directionVector.Normalize();
        while (!ProximityCheck(transform.position, targetPosition))
        {
            transform.position = AddVector(transform.position, (directionVector * speed));
            yield return null;
        }
        yield return null;
    }
    bool ProximityCheck(Vector2 a, Vector2 b)
    {
        // We make the proximity check twice the speed because this gives a few frames for the check to hit
        // Not the best approach, I know.
        if (Vector2.Distance(a, b) < (speed * 2))
        {
            return true;
        }
        else
        {
            Debug.Log("proximity check failed");
            return false;
        }
    }
    Vector2 AddVector(Vector2 subject, Vector2 delta)
    {
        float newX = subject.x + delta.x;
        float newY = subject.y + delta.y;
        return new Vector2(newX, newY);
    }
}
