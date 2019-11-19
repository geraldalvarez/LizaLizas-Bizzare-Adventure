using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixBehavior : MonoBehaviour
{
    public int[,] matrix;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void printMatrix()
    {
        for (int i = 0; i < matrix.GetUpperBound(0); i++)
        {
            for (int j = 0; j < matrix.GetUpperBound(1); j++)
            {
                print("value is " + j);
            }
        }
    }
}
