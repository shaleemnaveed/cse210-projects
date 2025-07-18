using System;

public class Reference
{
    // Attributes:
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    // Constructors:
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    // Methods:

    public string GetDisplayText()
    {
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        return $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }  
}