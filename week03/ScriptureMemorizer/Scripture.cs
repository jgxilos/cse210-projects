public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int numberOfWordsToHide)
    {
        Random random = new Random();
        for (int i = 0; i < numberOfWordsToHide; i++)
        {
            int index = random.Next(_words.Count);
            if (!_words[index].IsHidden()) 
            {
                _words[index].Hide();
            }
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public string GetDisplayText()
    {
        string referenceLine = _reference.GetDisplayText();
        string textLine = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{referenceLine}\n{textLine}";
    }
}