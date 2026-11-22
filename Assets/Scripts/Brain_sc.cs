
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain_sc : MonoBehaviour
{
    public int epochs = 100000;

    public double targetError = 0.001;

    Brain brain;

    // XOR giriş verileri
    List<List<double>> trainingInputs =
        new List<List<double>>()
    {
        new List<double>() { 0, 0 },
        new List<double>() { 0, 1 },
        new List<double>() { 1, 0 },
        new List<double>() { 1, 1 }
    };

    // Beklenen XOR çıktıları
    List<List<double>> trainingOutputs =
        new List<List<double>>()
    {
        new List<double>() { 0 },
        new List<double>() { 1 },
        new List<double>() { 1 },
        new List<double>() { 0 }
    };

    void Start()
    {
        brain = GetComponent<Brain>();

        if (brain == null || brain.ann == null)
        {
            Debug.LogError("Brain veya ANN bulunamadi!");
            return;
        }

        TrainNetwork();

        TestNetwork();
    }

    // Eğitim işlemi
    void TrainNetwork()
    {
        double error = 0;

        for (int epoch = 0; epoch < epochs; epoch++)
        {
            for (int i = 0; i < trainingInputs.Count; i++)
            {
                brain.ann.Run(
                    trainingInputs[i],
                    trainingOutputs[i]
                );
            }

            error = CalculateError();

            if (epoch % 10000 == 0)
            {
                Debug.Log(
                    "Epoch: " + epoch +
                    " | Sum of Squared Error: " + error
                );
            }

            if (error < targetError)
            {
                Debug.Log(
                    "Training completed at epoch: " + epoch
                );

                break;
            }
        }

        Debug.Log("Final Error: " + error);
    }

    // Toplam karesel hata hesabı
    double CalculateError()
    {
        double totalError = 0;

        for (int i = 0; i < trainingInputs.Count; i++)
        {
            List<double> result = brain.ann.Run(
                trainingInputs[i],
                null
            );

            double difference =
                trainingOutputs[i][0] - result[0];

            totalError += difference * difference;
        }

        return totalError;
    }

    // Eğitim sonrası test
    void TestNetwork()
    {
        Debug.Log("----- XOR TEST RESULTS -----");

        for (int i = 0; i < trainingInputs.Count; i++)
        {
            List<double> result = brain.ann.Run(
                trainingInputs[i],
                null
            );

            int roundedResult =
                Mathf.RoundToInt((float)result[0]);

            Debug.Log(
                trainingInputs[i][0] + " XOR " +
                trainingInputs[i][1] +
                " = " + result[0] +
                " | Rounded: " + roundedResult
            );
        }
    }
}
