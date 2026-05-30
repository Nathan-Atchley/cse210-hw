class Reference
{
    private string _book_na;
    private int _chapter_na;
    private int _startVerse_na;
    private int _endVerse_na;

    public Reference(string fullReference_na)
    {
        var (book_na, chapter_na, startVerse_na, endVerse_na) = splitReference(fullReference_na);
        _book_na = book_na;
        _chapter_na = chapter_na;
        _startVerse_na = startVerse_na;
        _endVerse_na = endVerse_na;
    }
    
    //Used google to research how to return multiple data types
    private (string book_na, int chapter_na, int startVerse_na, int endVerse_na) splitReference(string fullReference_na){
        // used this website for splitting a string example:
        // https://learn.microsoft.com/en-us/dotnet/api/system.string.split?view=netframework-4.8.1&viewFallbackFrom=net-10.0
        char[] separators = new char[] {' ', ':'};
        string[] splitReference_na = fullReference_na.Split(separators);
        string book_na = splitReference_na[0];
        int chapter_na = int.Parse(splitReference_na[1]);
        int startVerse_na;
        int endVerse_na;
        if (splitReference_na[2].Contains('-'))
        {
            string[] verseParts_na = splitReference_na[2].Split('-');
            startVerse_na = int.Parse(verseParts_na[0]);
            endVerse_na = int.Parse(verseParts_na[1]);
        }
        else
        {
            startVerse_na = int.Parse(splitReference_na[2]);
            endVerse_na = startVerse_na;
        }
        return (book_na, chapter_na, startVerse_na, endVerse_na);
    }
    public string toString()
    {
        if (_endVerse_na == _startVerse_na)
        {
            return $"{_book_na} {_chapter_na}: {_startVerse_na}";    
        }
        else
        {
            return $"{_book_na} {_chapter_na}: {_startVerse_na}-{_endVerse_na}";
        }
        
    }
}