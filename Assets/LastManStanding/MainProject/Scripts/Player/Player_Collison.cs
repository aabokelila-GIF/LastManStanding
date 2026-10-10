using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collison : MonoBehaviour
{


    private GameObject currentHexagon;

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + Vector3.up,
                            Vector3.down,
                            out hit,
                            5f))
        {
            if (hit.collider.CompareTag("Hexagon"))
            {
                if (currentHexagon != hit.collider.gameObject)
                {
                    currentHexagon = hit.collider.gameObject;

                    Hexagon_Destroyed hex =
                        currentHexagon.GetComponent<Hexagon_Destroyed>();

                    if (hex != null)
                    {
                        hex.TouchHexagon();
                    }
                }
            }
            else
            {
                currentHexagon = null;
            }
        }
        else
        {
            currentHexagon = null;
        }
    }
}
/* 
 int counnter = 0; 

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Hexagon"))
        {
           counnter++;
            MeshRenderer Hexa_meshRenderer = hit.gameObject.GetComponent<MeshRenderer>();
            Debug.Log("Counter is: " + counnter);

            if (Hexa_meshRenderer != null)

            { 
                Hexa_meshRenderer.material.color = Color.red;
           
            }
        }
    }
} 






 */