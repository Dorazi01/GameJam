public class DialogEntry
{
    public int CharNum { get; set; } // ĳ���� ��ȣ (NPC ��ȣ)
    public string Text1 { get; set; }
    public string Text2 { get; set; } // ��� �ؽ�Ʈ (�߰��� ���� �� ����)
    public int Mood { get; set; }
    //�Ӽ��� ���� �ƴ�
    public int Food { get; set; } //���� ��ȣ ����

    public string WinText { get; set; }

    public string LoseText { get; set; }

    public string WrongFood { get; set; } // �߸��� ���Ŀ� ���� �ؽ�Ʈ

    public string WrongMood { get; set; } // �߸��� ��п� ���� �ؽ�Ʈ

    public DialogEntry(int num ,string text1, string text2, int food , int value, string winText, string loseText,  string wrongFood, string wrongMood  )
    {
        CharNum = num;

        Text1 = text1;

        Text2 = text2;

        Food = food;

        Mood = value;

        WinText = winText;

        LoseText = loseText;

        WrongFood = wrongFood;

        WrongMood = wrongMood;
    }
    public DialogEntry Clone()
    {
        return new DialogEntry(CharNum, Text1, Text2, Food, Mood, WinText, LoseText, WrongFood, WrongMood);
    }
}