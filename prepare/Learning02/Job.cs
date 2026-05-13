using System;

public class Job
{
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    public string toString()
    {
        string rvalue = $"{_jobTitle} ({_company}) {_startYear}-{_endYear}";
        return rvalue;
    }

}