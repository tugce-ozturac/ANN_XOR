
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    public ANN ann;

    public double alpha = 0.5;

    void Awake()
    {
        // 2 input, 1 output,
        // 2 hidden layer, her katmanda 3 neuron
        ann = new ANN(2, 1, 2, 3, alpha);

        Debug.Log("Artificial Neural Network created!");
    }
}
