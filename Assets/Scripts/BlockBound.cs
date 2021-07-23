using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBound : MonoBehaviour
{
    float xBound = 4f;
    float yBound = -4f;
    Vector3 horizontal = new Vector3(1, 0, 0);
    Vector3 vertical = new Vector3(0, -1, 0);
    float offset = 0.5f;
    public bool isItPossible;
    public bool CheckBounds()
    {
        if (transform.position.x + offset < xBound)
        {
            return true;
        }
        if (transform.position.x + offset > -xBound)
        {
            return true;
        }
        if (transform.position.y + offset > yBound)
        {
            return true;
        }
        return false;
    }

}
