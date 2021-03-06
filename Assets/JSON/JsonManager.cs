﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonManager : MonoBehaviour {
    [SerializeField] private DrawerManager m_drawerManager;
    [SerializeField] private string jsonUrl = "http://test.local/simple.json";

    
    //Server JSON - ARRAY/OBJECT
    void Start()
    {
        string url = jsonUrl;
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));        
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
            JsonVertexInfo[] objects = JsonHelper.getJsonArray<JsonVertexInfo>(www.text);
            m_drawerManager.loadDraw(objects);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
    
}
