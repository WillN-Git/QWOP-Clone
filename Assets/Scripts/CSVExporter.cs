using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class CSVExporter : MonoBehaviour
{
    [SerializeField]
    private float recordDelaySeconds = 0.5f;

    private StringBuilder sb = new StringBuilder();

    void Start()
    {
        AddHeaders();
        recordConstantly();
    }

    public void recordConstantly()
    {
        StartCoroutine(RecordConstantlyCO());
    }

    private IEnumerator RecordConstantlyCO()
    {
        Record();

        yield return new WaitForSeconds(recordDelaySeconds);

        yield return RecordConstantlyCO();
    }

    public void AddHeaders()
    {
        sb.AppendLine(
            "rightThighSpeed;" + 
            "leftThighSpeed;" +
            "rightCalfSpeed;" +
            "leftCalfSpeed;" +
            "leftElbowSpeed;" +
            "rightElbowSpeed;" +
            "leftShoulderSpeed;" +
            "rightShoulderSpeed;" +
            "rightThighAngle;" +
            "leftThighAngle;" +
            "rightCalfAngle;" +
            "leftCalfAngle;" +
            "leftElbowAngle;" +
            "rightElbowAngle;" +
            "leftShoulderAngle;" +
            "rightShoulderAngle;" +
            "time"
        );
    }

    public void Record()
    {
        decimal time = Decimal.Round((decimal)Time.time, 2);
        sb.AppendLine(
            Data.rightThighSpeed.ToString() + ";" + 
            Data.leftThighSpeed.ToString() + ";" + 
            Data.rightCalfSpeed.ToString() + ";" + 
            Data.leftCalfSpeed.ToString() + ";" + 
            Data.leftElbowSpeed.ToString() + ";" + 
            Data.rightElbowSpeed.ToString() + ";" + 
            Data.leftShoulderSpeed.ToString() + ";" + 
            Data.rightShoulderSpeed.ToString() + ";" + 
            Data.rightThighAngle.ToString() + ";" + 
            Data.leftThighAngle.ToString() + ";" + 
            Data.rightCalfAngle.ToString() + ";" + 
            Data.leftCalfAngle.ToString() + ";" + 
            Data.leftElbowAngle.ToString() + ";" + 
            Data.rightElbowAngle.ToString() + ";" + 
            Data.leftShoulderAngle.ToString() + ";" + 
            Data.rightShoulderAngle.ToString() + ";" + 
            Data.alive
        );

        SaveToFile(sb.ToString());
    }
    public void SaveToFile(string content)
    {
        // The target file path e.g.
        var folder = Application.streamingAssetsPath;

        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

        var filePath = Path.Combine(folder, "export_test.csv");

        using (var writer = new StreamWriter(filePath, false))
        {
            writer.Write(content);
        }
    }
}
