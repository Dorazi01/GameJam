using System.Collections.Generic;
using UnityEngine;

public class Dialog
{
    public List<DialogEntry> Level1 = new List<DialogEntry>();
    public List<DialogEntry> Level2 = new List<DialogEntry>();
    public List<DialogEntry> Level3 = new List<DialogEntry>();

    private System.Random random = new System.Random();

    public Dialog()
    {

        /*
         정답지 :

        자신감을 주는 과일케이크 (공포)3
        희망을 주는 치즈식빵 (무기력)4
        용기를 복돋아주는 피자빵 (좌절)2
        자존감의 딸기 도넛 (열등)5
        안정의 도넛.(불안)1
        진정의 개구리머핀(분노)6

        


        1 = 도넛 거미치즈 + 개구리알 
        2 = 피자빵 거미치즈 + 산딸기 
        3 = 과일케이크 개구리알 + 산딸기 
        4 = 치즈빵 거미치즈
        5 = 딸기도넛 산딸기
        6 = 개구리머핀 개구리알
         */
        





        Level1.Add(new DialogEntry("오늘은 도넛이 먹고 싶어.", 1, "우왕 도넛이당!!!!", "이딴게...도넛?"));
        Level1.Add(new DialogEntry("치즈가 잔뜩 들어간 빵이 필요해!", 4, "치즈가 최고지 음~", "이게 치즈라고? 지금이라도 푸른 초원을 뛰댕길것 처럼 생겼잖아!"));
        Level1.Add(new DialogEntry("개구리같이 생긴 머핀이 먹고싶어!", 6, "우왕 개구리모양 머핀이다!", "이게 개구리보여? 니 눈의 미적감각은 방금 막 태어난 3시간짜리 애기보다 구리구나!!"));
        Level1.Add(new DialogEntry("딸기맛 도넛은 있어?", 5, "아메리칸 도넛은 역시 딸기지", "따옿 라즈베리잖아!"));
        Level1.Add(new DialogEntry("나 오늘 생일이야..!", 3, "축하해줘서 고마워!!!", "어.....고마워?"));
        Level1.Add(new DialogEntry("피자빵? 이건 뭐야?", 2, "난 오늘부터 피자빵 팬이다. 피자빵을 욕하는것은 날 욕하는 것이며 어쩌구저쩌구....", "이 쓰레기같은 메뉴는 뭐지? 갔다 치워"));


        Level2.Add(new DialogEntry("", 1, "이김", "짐"));
        Level2.Add(new DialogEntry("12섞어", 2, "이김", "짐"));
        Level2.Add(new DialogEntry("12섞어", 3, "이김", "짐"));
        Level2.Add(new DialogEntry("12섞어", 4, "이김", "짐"));
        Level2.Add(new DialogEntry("", 5, "이김", "짐"));
        Level2.Add(new DialogEntry("", 6, "이김", "짐"));



        Level3.Add(new DialogEntry("스승님이 그러는데, 내가 동료보다 한참 어리숙하대.. 내가 걔보다 못한게 뭘까..?", 5, "이김", "짐"));
        Level3.Add(new DialogEntry("마력 제어 시험에서 실수했어... 난 뭘 해도 안되는걸까...", 2, "맞아 이번에는 실수없이 잘 할 수 있을거야!", "난 쓰레기야 흑흑흑흑"));
        Level3.Add(new DialogEntry("....익절할까? 아냐 오를수도 있잖아 조금만 참으면... 근데 떨어지면 어떡하지? 지금이라도??", 1, "고마워 덕분에 큰 돈을 벌었어", "너때문이야너때문이야너때문이야너때문이야너때문이야너때문이야너때문이야너때문이야"));
        Level3.Add(new DialogEntry("요즘 누가 날 따라오는 것 같아..", 3, "아하! 쓸데없는 걱정이었구나!", "너...너가 따라오는거지? 그치?"));
        Level3.Add(new DialogEntry("!@$@!$$!@$#@#", 6, "후... 고마워~", "!@#!@$!@$!@#@!#!#!#!@#@!#@!#!@#!@$!@#$!@#!@"));
        Level3.Add(new DialogEntry("..............", 4, "야호! 세상이 아름다워!", "......t('^')t"));



    }

    // 레벨별 랜덤 대사 반환
    public DialogEntry GetRandomDialog(int level)
    {
        List<DialogEntry> targetList = level switch
        {
            1 => Level1,
            2 => Level2,
            3 => Level3,
            _ => Level1
        };

        if (targetList.Count == 0)
            return null;

        int idx = random.Next(targetList.Count);
        return targetList[idx];
    }
}