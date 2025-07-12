public class DialogEntry
{
    public int CharNum { get; set; } // 캐릭터 번호 (NPC 번호)
    public string Text1 { get; set; }
    public string Text2 { get; set; } // 대사 텍스트 (추가로 사용될 수 있음)
    public int Mood { get; set; }
    //속성임 음식 아님
    public int Food { get; set; } //음식 번호 저장

    public string WinText { get; set; }

    public string LoseText { get; set; }

    public string WrongFood { get; set; } // 잘못된 음식에 대한 텍스트

    public string WrongMood { get; set; } // 잘못된 기분에 대한 텍스트

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