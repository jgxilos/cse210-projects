using System;

public class Comment
{
    private string _name;
    private string _text;

    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    public string GetCommenterName()
    {
        return _name;
    }

    public string GetCommentText()
    {
        return _text;
    }
}