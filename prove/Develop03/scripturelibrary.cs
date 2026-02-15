using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    public void HideRandomWords(int count)
    {
        Random rnd = new Random();
        for (int i = 0; i < count; i++)
        {
            int index = rnd.Next(_words.Count);
            _words[index].Hide();
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
                return false;
        }
        return true;
    }

    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + "\n";

        foreach (Word w in _words)
        {
            result += w.GetDisplayText() + " ";
        }

        return result.Trim();
    }
}
