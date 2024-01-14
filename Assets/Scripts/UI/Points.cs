using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Points : MonoBehaviour
{
    public int count = 0;
    public TMP_Text countText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        DisplayCount();
    }

    public void DisplayCount()
    {
        countText.text = count.ToString();
    }
}
