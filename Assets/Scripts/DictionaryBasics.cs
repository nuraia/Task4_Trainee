using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using System.Reflection;

public class DictionaryBasics : MonoBehaviour
{
    public List<string> Name = new List<string>();
    public List<Sprite> Image = new List<Sprite>();
    public TextMeshProUGUI employeeName;
    public Image employeeImage;
    public Sprite employeeSprite;
    int prefix;
    
    void Start()
    {
        prefix = 0;
    }
    [ContextMenu("AddEntry")]
    public void AddEntry()
    {
        string newString = "abc" + prefix;
        if (!SearchEntry(newString))
        {
            Name.Add(newString);
            prefix++;
            Image.Add(employeeSprite);
            DisplayItem(Name.Count - 1);
        }
        else
        {
            Debug.Log("Name exits!");
        }
    }
    [ContextMenu("SearchEntry")]
    public bool SearchEntry(string name)
    {
        //string name = "abc";
        return Name.Contains(name);
    }
    [ContextMenu("RemoveEntry")]
    public void RemoveEntry()
    {
        if (Name.Count > 0) DisplayItem(Math.Max(Name.Count - 2, 0));
        else
        {
            employeeName.text = "";
            employeeImage.sprite = null;
            return;
        }
        Name.RemoveAt(Name.Count - 1);
        Image.RemoveAt(Image.Count - 1);
    }


    void DisplayItem(int index)
    {

        employeeName.text = Name[index];
        employeeImage.sprite = Image[index];
            //Debug.Log($"Employee name {employee.Key}, Image {employee.Value}");
        
    }
}
