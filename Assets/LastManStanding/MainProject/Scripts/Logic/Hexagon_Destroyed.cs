using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon_Destroyed : MonoBehaviour
{

    int touchCount = 0;
    bool isDestroying = false;

    public void TouchHexagon()
    {
        touchCount++;

        if (touchCount == 1)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if (touchCount == 2 && !isDestroying)
        {
            isDestroying = true;

            GetComponent<MeshRenderer>().material.color = Color.black;
            StartCoroutine(DestroyHexagon());
        }
    }
    IEnumerator DestroyHexagon()
    {
        yield return new WaitForSeconds(3f);

        Destroy(gameObject);

    }
}
