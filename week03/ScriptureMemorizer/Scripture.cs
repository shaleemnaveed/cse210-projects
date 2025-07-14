using System;
using System.Collections.Generic;

public class Scripture
{
    // Attributes:
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    // Constructors:
    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    // Methods:
    public void HideRandomWords(int numberToHide)
    {
        int hidden = 0;
        Random random = new Random();

        while (hidden < numberToHide)
        {
            int index = random.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hidden++;
            }
            if (IsCompletelyHidden())
            {
                break;
            }
        }
    }

    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();
        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }
        return $"{_reference.GetDisplayText()} {string.Join(" ", displayWords)}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}