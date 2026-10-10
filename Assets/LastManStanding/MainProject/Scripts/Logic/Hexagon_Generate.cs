using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon_Generate : MonoBehaviour
{
    [SerializeField] private GameObject hexPrefab;
    [SerializeField] private int columns = 9;
    [SerializeField] private int rows = 5;

    private void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        MeshRenderer renderer = hexPrefab.GetComponentInChildren<MeshRenderer>();

        float hexWidth = renderer.bounds.size.x;
        float hexDepth = renderer.bounds.size.z;

        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                float posX = x * (hexWidth * 0.75f);

                float posZ = y * hexDepth;

                if (x % 2 == 1)
                    posZ += hexDepth * 0.5f;

                Vector3 localPos = new Vector3(posX, 0f, posZ);

                GameObject hex = Instantiate(
                    hexPrefab,
                    transform
                );

                hex.transform.localPosition = localPos;
            }
        }
    }
}