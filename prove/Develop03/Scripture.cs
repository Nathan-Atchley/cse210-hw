class Scripture
{
    Reference _reference_na;
    List<Word> _passage_na;
    int _visibleWordCount_na;

    public Scripture(string reference_na, string passage)
    {
        _reference_na = new Reference(reference_na);
        _passage_na = new List<Word>();
        addWords(passage);
        _visibleWordCount_na = _passage_na.Count();
    }
    private void addWords(string passage_na)
    {
        string[] words_na = passage_na.Split(" ");
        for (int x = 0; x < words_na.Count(); x++)
        {
            Word word = new Word(words_na[x]);
            _passage_na.Add(word);
        }
    }

    public string toString()
    {
        string output_na = "";
        for (int x = 0; x < _passage_na.Count(); x++)
        {
            output_na += _passage_na[x].toString() + " ";
        }
        return output_na;
    }

    public void hideWords(int userChoice_na)
    {
        
        Random random_na = new Random();
        int x = 0;
        do
        {
            if (_visibleWordCount_na <= 0) {
                break;
            }
            int randomIndex_na = random_na.Next(0, _passage_na.Count());
            if (!_passage_na[randomIndex_na].getHidden())
            {
                _passage_na[randomIndex_na].setIsHidden();
                x++;
                _visibleWordCount_na--;
            }
        } while(x < userChoice_na);
    }

    public bool getIsNotAllHidden()
    {
        if (_visibleWordCount_na == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}