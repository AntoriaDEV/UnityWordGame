using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Versioning;

public class WordGame : MonoBehaviour
{
    [SerializeField] TMP_InputField guessChar;
    [SerializeField] Button submit;
    [SerializeField] Button reset;
    [SerializeField] TMP_Text guessesRemaining;
    [SerializeField] TMP_Text guess;
    [SerializeField] TextAsset wordList;
    string correctWord = "";
    string charGuess = "";
    string[] lettersGuessed;
    //string[] listOfWords = wordList.text.Split('\n');

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(wordList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadWords()
    {

    }
}
