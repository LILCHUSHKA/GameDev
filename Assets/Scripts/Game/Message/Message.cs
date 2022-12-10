[System.Serializable]
public class Message
{
    public string theme, whom, description, date;

    public int index;

    public bool isRead;

    public void GetMessageData(string _theme, string _whom, string _description, string _date)
    {
        theme = _theme;
        whom = _whom;
        description = _description;
        date = _date;
    }

    
}