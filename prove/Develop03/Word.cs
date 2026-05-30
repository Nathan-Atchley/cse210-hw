class Word
{
    private string _word_na;
    private string _hint_na;
    private bool _isHidden_na;

    public Word(string word_na) {
        _word_na = word_na;
        _hint_na = setHint(word_na);
        _isHidden_na = false;
    }
    public string setHint(string word_na)
    {
        int wordLength_na = word_na.Count();
        string hint_na = "";
        for (int x = 0; x < wordLength_na; x++)
        {
            hint_na += "_";
        }
        return hint_na;
    }
    public string toString()
    {
        if (_isHidden_na)
        {
            return _hint_na;
        }
        else
        {
            return _word_na;
        }
    }

    public void setIsHidden()
    {
        _isHidden_na = true;
    }

    public bool getHidden()
    {
        return _isHidden_na;
    }
}