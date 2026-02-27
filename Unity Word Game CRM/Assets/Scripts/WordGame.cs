using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;


public class WordGame : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_Text hiddenWord;
    [SerializeField] TMP_Text lettersGuessed;
    [SerializeField] TMP_Text guessesRemaining;
    [SerializeField] Button submit;
    [SerializeField] Button reset;
    [SerializeField] TMP_InputField userInput;

    [Header("Text File")]
    [SerializeField] TextAsset wordList;

    //Variable Initalization
    char[] correctWord;
    HashSet<char> guessedLetters = new HashSet<char>();
    int guesses;
    string randomWord;

    void Start()
    {
        Button check = reset.GetComponent<Button>();
        check.onClick.AddListener(GameSetup);
        Button redo = reset.GetComponent<Button>();
        redo.onClick.AddListener(GuessLetter);
        GameSetup();
    }

    void Update()
    {

    }

    void GameSetup()
    {
        randomWord = GetWords("wordlist");
        Debug.Log(randomWord);
        guesses = 3;
        guessedLetters.Clear();
        correctWord = new char[randomWord.Length];
        for (int i = 0; i < correctWord.Length; i++)
        {
            correctWord[i] = '_';
        }
        UpdateText();
    }

    void GuessLetter()
    {
        char guess = char.ToLower(userInput.text[0]);
        userInput.text = "";

        if (guessedLetters.Contains(guess))
        {
            guessedLetters.Add(guess);
        }
        bool correctGuess = false;
        for (int i = 0; i < randomWord.Length; i++)
        {
            if (randomWord[i] == guess)
                correctWord[i] = guess;
                correctGuess = true; 
        }
        if (!correctGuess)
        {
            guesses--;
        }
        UpdateText();
    }

    string GetWords(string wordlist)
    {
        TextAsset fullWordList = Resources.Load<TextAsset>(wordlist);
        
        if (fullWordList == null)
        {
            return "";
        }

        string[] stringOfWords = fullWordList.text.Split(new[] {'\n', '\r'}, System.StringSplitOptions.RemoveEmptyEntries);
        return stringOfWords[Random.Range(0, stringOfWords.Length)].Trim();
    }



    void UpdateText()
    {
        hiddenWord.text = string.Join(" ", correctWord);
        guessesRemaining.text = $"Guesses Remaining: {guesses}";
        lettersGuessed.text = $"Letters Guessed: {string.Join(", ", guessedLetters)}";
        submit.interactable = true;
    }


}
