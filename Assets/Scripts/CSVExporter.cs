using System;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine;

public class CSVExporter : MonoBehaviour
{
    [SerializeField] private float recordDelaySeconds = 0.5f;

    private readonly StringBuilder sb = new();

    private readonly Data data = new();

    private string file_tag = "";

    private bool record = true;
    
    private void Start()
    {
        
        // Get the current time
        DateTime currentTime = DateTime.Now;

        // Format the time as "_hour_minute_second"
        file_tag = currentTime.ToString("ddd_MM_YYYY-HH_mm_ss");
        
        AddHeaders();
        recordConstantly();
        
    }

    private void OnDestroy()
    {
        record = false;
    }

    public void recordConstantly()
    {
        StartCoroutine(RecordConstantlyCO());
    }

    private IEnumerator RecordConstantlyCO()
    {
        while (record)
        {
            data.GenerateNewDataCO();
            Record();
        
            yield return new WaitForSeconds(recordDelaySeconds);
        }
    }

    public void AddHeaders()
    {
        sb.AppendLine(
            "startDist;speed;inclination;rightThighSpeed;leftThighSpeed;rightCalfSpeed;leftCalfSpeed;rightThighAngle;leftThighAngle;rightCalfAngle;leftCalfAngle;alive;time");
    }

    public void Record()
    {
        decimal time = decimal.Round((decimal)Time.time, 2);
        sb.AppendLine(data.startDist + ";" + data.speed + ";" + data.inclination + ";" + data.rightThighSpeed + ";" +
                      data.leftThighSpeed + ";" + data.rightCalfSpeed + ";" + data.leftCalfSpeed + ";" +
                      data.rightThighAngle + ";" + data.leftThighAngle + ";" + data.rightCalfAngle + ";" +
                      data.leftCalfAngle + ";" + data.alive + ";" + time);
        SaveToFile(sb.ToString());
    }

    public void SaveToFile(string content)
    {
        // The target file path e.g.
        string folder = Application.streamingAssetsPath;

        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
        
        string filePath = Path.Combine(folder, $"export_test_{file_tag}.csv");

        using (StreamWriter writer = new(filePath, false))
        {
            writer.Write(content);
        }
    }
}