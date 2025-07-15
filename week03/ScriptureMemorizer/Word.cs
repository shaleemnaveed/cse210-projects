using System;
using System.Collections.Generic;

public class Word
{
    // Attributes:
    private string _text;
    private bool _isHidden;

    // Constructors:
    public Word(string text)
    {
        _text = text;
    }

    // Methods:
    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        return _text;
    }
}