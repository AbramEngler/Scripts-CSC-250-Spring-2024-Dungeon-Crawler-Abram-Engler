using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class ClassGenerator : MonoBehaviour
{
    void Start()
    {
        displayClass("Assets/Data Files/CryptoData.json");

        // foreach (string fieldName in fieldNames) debug statement to check if fields have lost their double quotes and colon
        // {
        //     Debug.Log(fieldName);
        // }

    }
    static int CountOfCharacter(string text, char character)
    {
        int count = 0;
        foreach (char c in text)
        {
            if (c == character)
            {
                count++;
            }
        }
        return count;
    }
    public void displayClass(string filePath)
    {
        int colonCount = 0; 
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                colonCount += CountOfCharacter(line, ':');
            }
        }

        string[] fieldNames = new string[colonCount];

        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            int index = 0; 
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(':');

                if (parts.Length == 2)
                {
                    string fieldName = parts[0].Trim().Trim('"');
                    fieldNames[index++] = fieldName;
                }
            }
        }

        Debug.Log("[System.Serializable]\n");
        Debug.Log("public class " + fieldNames[0] + "\n");

        //print fields
        for(int i = 1; i < fieldNames.Length; i++)
        {
            Debug.Log("public string " + fieldNames[i] + ";\n");
        }

        //print constructor
        Debug.Log("public " + fieldNames[0] + "(");
        for(int i = 1; i < fieldNames.Length; i++)
        {
            Debug.Log("string " + fieldNames[i] + ", ");
        }

        //assigning field values
        for(int i = 1; i < fieldNames.Length; i++)
        {
            Debug.Log("this." + fieldNames[i] + " = " + fieldNames[i] + "\n");
        }
    }
}
