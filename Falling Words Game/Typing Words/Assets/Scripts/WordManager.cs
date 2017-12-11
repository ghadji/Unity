using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

    public List<Word> words;

    public WordSpawner wordSpawner;

    private bool hasActiveWord;
    private Word activeWord;

    public UIManager uiManager;

    public void addWord() {
        Word word = new Word(WordGenerators.getRandomWord(), wordSpawner.spawnWord());

        words.Add(word);
    }

    public void typeLetter(char letter) {
        if (hasActiveWord) {
            if (activeWord.getNextLetter() == letter) {
                activeWord.RegisterTypedLetter();
            }
        } else {
            foreach(Word word in words) {
                if (word.getNextLetter() == letter) {
                    activeWord = word;
                    hasActiveWord = true;
                    word.RegisterTypedLetter();
                    break;
                }
            }
        }

        if (hasActiveWord && activeWord.isTyped()) {
            hasActiveWord = false;
            removeWord(activeWord);
            uiManager.updateScore();
        }
    }
    
    public void removeWord(Word word) {
        words.Remove(word);
    }

}
