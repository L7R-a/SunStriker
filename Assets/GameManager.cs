using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int maxMessages = 25;
    public GameObject chatPanel, textObject;
    public InputField chatBox;

    [SerializeField]
    List<Message> messagelist = new List<Message>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {

                if (chatBox.text != "help")
                {
                    SendMessageToChat(chatBox.text);
                    Command(chatBox.text);
                }
                else {

                    Command(chatBox.text);
                } 

                chatBox.text = "";
            }
        }  
    }

    public void SendMessageToChat(string text) 
    {

        if (maxMessages <= messagelist.Count)
        {
            Destroy(messagelist[0].textObject.gameObject);
            messagelist.Remove(messagelist[0]); 
        }

        Message newMessage = new Message();
        newMessage.text = text;
        GameObject newText = Instantiate(textObject, chatPanel.transform);
        newMessage.textObject = newText.GetComponent<Text>();
        newMessage.textObject.text = newMessage.text;
        messagelist.Add(newMessage);
    }

    public void Command(string command)
    {
        var rnd = new System.Random();
        List<string> commandList = new List<string>(){"die", "shield", "Shinning sunstrike"};

        int helpI = rnd.Next(commandList.Count);

        switch (command) 
        {
            case "die":
                break;

            case "shield":
                break;

            case "Shinning sunstrike":
                break;

            case "help":
                SendMessageToChat($"Try -> {commandList[helpI]}");
                break;

            default:
                break;
        }

    }
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
}