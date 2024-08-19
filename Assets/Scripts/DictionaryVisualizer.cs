using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictiona : MonoBehaviour
{
    public CustomDictionary customDictionary = new CustomDictionary();
    public Dictionary<string, Sprite> mydictionary = new Dictionary<string, Sprite>();
    void Start()
    {
       mydictionary = customDictionary.initializeDictionary();
       Debug.Log(mydictionary.Count);
    }

   
}
[Serializable]
public class CustomDictionary
{
    public List<DictionaryItem> customDictionary = new List<DictionaryItem>();
    public Dictionary<string, Sprite> dictionary = new Dictionary<string, Sprite>();
    public Dictionary<string, Sprite> initializeDictionary()
    {
        foreach(var item in customDictionary)
        {
            if(!dictionary.ContainsKey(item.key))dictionary.Add(item.key, item.value);
        }
        return dictionary;
    }

}
[Serializable]
public class DictionaryItem
{
    public string key;
    public Sprite value;
}