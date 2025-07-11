public class DialogEntry
{
    public string Text { get; set; }
    public int Value { get; set; }

    public string WinText { get; set; }

    public string LoseText { get; set; }

    public DialogEntry(string text, int value, string winText, string loseText)
    {
        Text = text;
        Value = value;
        WinText = text;
        LoseText = loseText;
    }
}