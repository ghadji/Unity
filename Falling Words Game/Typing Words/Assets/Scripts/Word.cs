
[System.Serializable]
public class Word {

    public string word;

    private int typedIndex;

    private DisplayWord display;

    public Word(string word, DisplayWord display) {
        this.word = word;
        typedIndex = 0;

        this.display = display;
        display.setWord(this.word);
    }

    public char getNextLetter() {
        return word[typedIndex];
    }

    public void RegisterTypedLetter() {
        typedIndex++;
        display.removeLetter();
        //remove/highlight letter
    }

    public bool isTyped() {
        bool wordTyped = (typedIndex >= word.Length);

        if (wordTyped) {
            display.removeWord();
        }

        return wordTyped;
    }

}
