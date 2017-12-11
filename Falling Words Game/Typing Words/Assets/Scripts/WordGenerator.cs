using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerators {

    private static TextAsset dictionary = (TextAsset)Resources.Load("dictionary");
    private static string[] wordList = dictionary.text.Split(' ');

    public static string getRandomWord() {
        int randomIndex = Random.Range(0, wordList.Length);
        return wordList[randomIndex];
    }
	
}
