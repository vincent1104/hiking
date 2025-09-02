using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro; // 注意加上 TextMeshPro
using UnityEngine;

public class GRUOnnxRuntimeMobile : MonoBehaviour
{
    [Header("ONNX Model")]
    public string onnxFileName = "GRU.onnx";
    public string inputName = "input";
    public string outputName = "output";

    [Header("Input shape")]
    public int seqLen = 500;
    public int featureDim = 1;

    [Header("UI")]
    public TMP_Text outputText; // 拖入你在 Canvas 上的 TMP Text

    private InferenceSession _session;

    void Start()
    {
        string modelPath = System.IO.Path.Combine(Application.streamingAssetsPath, onnxFileName);
        _session = new InferenceSession(modelPath);

        var inputTensor = MakeRandomInputTensor(1, seqLen, featureDim);
        var inputs = new List<NamedOnnxValue>
        {
            NamedOnnxValue.CreateFromTensor(inputName, inputTensor)
        };

        using var results = _session.Run(inputs);

        foreach (var r in results)
        {
            if (r.Name == outputName)
            {
                var outputTensor = r.AsTensor<float>();
                float[] data = outputTensor.ToArray();

                string display = $"Output length: {data.Length}\n";
                if (data.Length > 0)
                {
                    display += $"Output[0]: {data[0]}\n";
                    for (int i = 0; i < data.Length && i < 10; i++) // 只顯示前10個
                    {
                        display += $"[{i}] = {data[i]:F4}\n";
                    }
                }

                // 將結果寫入 TMP Text
                if (outputText != null)
                    outputText.text = display;
                else
                    Debug.LogWarning("請在 Inspector 拖入 TMP_Text");
            }
        }
    }

    Tensor<float> MakeRandomInputTensor(int batch, int seq, int feat)
    {
        var dims = new int[] { batch, seq, feat };
        var tensor = new DenseTensor<float>(dims);
        var rnd = new System.Random();

        for (int b = 0; b < batch; b++)
            for (int t = 0; t < seq; t++)
                for (int f = 0; f < feat; f++)
                {
                    double u1 = 1.0 - rnd.NextDouble();
                    double u2 = 1.0 - rnd.NextDouble();
                    float val = (float)(Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2));
                    tensor[b, t, f] = val;
                }

        return tensor;
    }

    void OnDestroy()
    {
        _session?.Dispose();
    }
}
