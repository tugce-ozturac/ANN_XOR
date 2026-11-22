
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer
{
    public int numberOfNeurons;

    public List<Neuron> neurons = new List<Neuron>();

    public Layer(int numberOfNeurons, int numberOfInputs)
    {
        this.numberOfNeurons = numberOfNeurons;

        for (int i = 0; i < numberOfNeurons; i++)
        {
            neurons.Add(new Neuron(numberOfInputs));
        }
    }
}
