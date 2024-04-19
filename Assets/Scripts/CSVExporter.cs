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

    private Data data = new Data();

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
        data.GenerateNewDataCO();
        Record();

        yield return new WaitForSeconds(recordDelaySeconds);

        yield return RecordConstantlyCO();
    }

    public void AddHeaders()
    {
        sb.AppendLine("startDist;speed;inclination;rightThighSpeed;leftThighSpeed;rightCalfSpeed;leftCalfSpeed;rightThighAngle;leftThighAngle;rightCalfAngle;leftCalfAngle;alive;time");
    }

    public void Record()
    {
        decimal time = Decimal.Round((decimal)Time.time, 2);
        sb.AppendLine("");
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
