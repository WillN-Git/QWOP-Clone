using System;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine;

public class CSVExporter : MonoBehaviour
{
    [SerializeField, Range(0.1f, 1f)]
    private float recordDelaySeconds = 0.5f;

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
            "alive;" + 
            "time;" + 
            "a;" + 
            "z;" + 
            "o;" + 
            "p"
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
            Data.alive.ToString() + ";" + 
            Time.time.ToString() + ";" + 
            Data.a.ToString() + ";" + 
            Data.z.ToString() + ";" + 
            Data.o.ToString() + ";" + 
            Data.p.ToString() + ";"
        );

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