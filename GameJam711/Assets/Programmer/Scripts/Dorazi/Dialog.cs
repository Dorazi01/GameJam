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
        // ¿¹½Ã ´ë»ç Ãß°¡
        Level1.Add("1°ú 3 ¼¯¾î¼­ Áà");
        Level1.Add("2¸¸ ³Ö¾î¼­ Áà");
        Level2.Add("23¼¯¾î");
        Level2.Add("12¼¯¾î");
        Level3.Add("1Áà");
        Level3.Add("3Áà");
    }

    // ·¹º§º° ·£´ý ´ë»ç ¹ÝÈ¯
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