using System;

class Program
{
    static void Main(string[] args)
    {
        // Create Job instances
        Job job1 = new Job()
        {
            _jobTitle = "Software Engineer",
            _company = "Microsoft",
            _startYear = 2019,
            _endYear = 2022
        };

        Job job2 = new Job()
        {
            _jobTitle = "Manager",
            _company = "Apple",
            _startYear = 2022,
            _endYear = 2023
        };

        // Create instance of Resume
        Resume myResume = new Resume()
        {
            _name = "Allison Rose"
        };

        // Adding jobs to the resume
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Show complete resume
        myResume.Display();
    }
}