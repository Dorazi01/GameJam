using System.Collections.Generic;
using UnityEngine;

public class Dialog
{
    public List<string> Level1 = new List<string>();
    public List<string> Level2 = new List<string>();
    public List<string> Level3 = new List<string>();

    private System.Random random = new System.Random();

    public Dialog()
    {
        // ���� ��� �߰�
        Level1.Add("1�� 3 ��� ��");
        Level1.Add("2�� �־ ��");
        Level2.Add("23����");
        Level2.Add("12����");
        Level3.Add("1��");
        Level3.Add("3��");
    }

    // ������ ���� ��� ��ȯ
    public string GetRandomDialog(int level)
    {
        List<string> targetList = level switch
        {
            1 => Level1,
            2 => Level2,
            3 => Level3,
            _ => Level1
        };

        if (targetList.Count == 0)
            return string.Empty;

        int idx = random.Next(targetList.Count);
        return targetList[idx];
    }
}