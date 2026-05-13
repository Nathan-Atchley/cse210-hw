using System;

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public string toString()
    {
        string rvalue = $"Name: {_name}\nJobs:\n";
        for (int i = 0; i < _jobs.Count(); i++)
        {
            rvalue += $"\t" + _jobs[i].toString() + $"\n";
        }
        return rvalue;
    }
}