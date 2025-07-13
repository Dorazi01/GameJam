// Dialog.cs
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialog
{
    public List<DialogEntry> Level1 = new List<DialogEntry>();
    public List<DialogEntry> Level2 = new List<DialogEntry>();
    public List<DialogEntry> Level3 = new List<DialogEntry>();

    private System.Random random = new System.Random();
    private Queue<int> recentIndices = new Queue<int>();
    private const int maxRecent = 3;

    string[] foodNames = { "개구리파이", "피자빵", "과일케이크", "치즈식빵", "딸기도넛", "개구리머핀" };

    public Dialog()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Level1")
        {
            AddLevel1();
        }
        else if (sceneName == "Level2")
        {
            AddLevel1();
            AddLevel2();
        }
        else if (sceneName == "Level3")
        {
            AddLevel2();
            AddLevel3();
        }
    }

    void AddLevel1()
    {
        Level1.Add(new DialogEntry(1, "오늘은 {food}이(가) 먹고 싶어요.", "악몽 때문에 잠을 못 잤어요", 0, 1, "이거 먹으면 좀 나아질 것 같아요, 고마워요.", "이게 {food} 맞아요...?", "맛은 괜찮은데… 그냥 그런 느낌이네요.", "기분은 좀 나아졌는데, 이건 내가 시킨 게 아닌데요?"));
        Level1.Add(new DialogEntry(1, "오늘은 {food}좀 주실래요?", "무언가 날 따라다니는 것 같아서요", 0, 1, "따뜻한 {food}, 덕분에 마음이 조금 놓여요.", "이딴 게 {food}라고요?", "음식은 잘 받았는데… 기분은 그대로네요.", "맛은 아닌데… 묘하게 마음이 가벼워지네요."));
        Level1.Add(new DialogEntry(1, "{food}, {food}하나만 있다면 오늘이 완벽할 거에요.", "계속 실패만 하는 기분이에요", 0, 2, "이거라도 먹으니 위로가 되네요. 고마워요.", "이걸 {food}라고 내놓은 거예요?", "입에 맞긴 한데… 마음은 여전히 무겁네요.", "이게 내가 시킨 건 아니지만, 이상하게 힘이 나요."));
        Level1.Add(new DialogEntry(1, "오늘은 {food} 주문할게요.", "제가 뭘 해도 안 되는 것 같아서요", 0, 2, "따뜻한 {food} 한 입이 위안이 되네요.", "{food}? 이런 걸 시킨 적 없는데요.", "맛은 맞는데… 위로가 되진 않네요.", "주문은 틀렸는데, 기분은 조금 나아졌어요."));
        Level1.Add(new DialogEntry(1, "오늘은 {food}이(가) 먹고 싶어.", "다른 사람보다 항상 부족한 것 같아요", 0, 4, "이런 정성 받으니 조금은 괜찮아지는 느낌이에요.", "이게 주문한 거랑 다르잖아요.", "딱 내가 원한 맛인데, 왜 이렇게 허전하죠?", "뭔가 틀렸는데… 기분은 묘하게 나아졌어요."));
        Level1.Add(new DialogEntry(1, "{food}주세요.", "제 모습이 싫어요", 0, 4, "{food} 같은 걸 챙겨주는 사람도 있군요. 고마워요.", "이건 {food}가 아니잖아...", "맛은 있는데… 마음은 별로 나아지질 않네요.", "이게 {food}는 아닌데, 왠지 내가 조금 괜찮아진 느낌이에요."));
        Level1.Add(new DialogEntry(1, "오늘은 {food}이(가) 먹고 싶어.", "앞날이 너무 불안해요", 0, 5, "{food}이라도 먹고 나면 좀 나아지겠죠. 고맙습니다.", "{food}라더니 완전 엉망이잖아.", "다른 빵이 더 맛있었으려나....", "맛은 실망인데… 불안이 조금 사라진 느낌이에요."));
        Level1.Add(new DialogEntry(1, "오늘은 {food}주세요.", "무슨 선택을 해도 불안하네요", 0, 5, "이건 틀린 선택 아니겠죠? 고마워요.", "내가 시킨 건 {food}였거든요?", "이 맛이긴 한데… 머릿속은 여전히 복잡하네요.", "이게 내가 고른 건 아닌데, 마음이 조금 정리된 느낌이에요."));
        Level1.Add(new DialogEntry(1, "오늘은 {food}하나 주문할게요.", "모두가 나를 무시하는 것 같아요", 0, 6, "적어도 당신은 날 챙겨주는군요. 고마워요.", "헐... {food} 이렇게 만드는 집 처음 보네.", "맛은 있었지만… 그뿐이었네요.", "뭐지… 이건 내가 시킨 건 아닌데, 마음은 가벼워졌어요."));
        Level1.Add(new DialogEntry(1, "{food}.", "왜 나만 이런 대우를 받아야 하죠?", 0, 6, "이걸 챙겨주는 당신 덕분에 조금은 나아졌어요.", "{food} 하나 제대로 못 하세요?", "입맛엔 맞았지만, 속은 여전히 화가 나네요.", "기분은 조금 괜찮아졌네요… 이상하네, 이게 아닌데."));
    }

    void AddLevel2()
    {
        Level2.Add(new DialogEntry(1, "오늘은 {food}주세요.", "악몽 때문에 잠을 못 잤어요", 0, 1, "이거 먹으면 좀 나아질 것 같아요, 고마워요.", "이게 {food} 맞아요...?", "맛은 괜찮은데… 그냥 그런 느낌이네요.", "기분은 좀 나아졌는데, 이건 내가 시킨 게 아닌데요?"));

        Level2.Add(new DialogEntry(1, "{food}어떨까요?.", "계속 실패만 하는 기분이에요", 0, 2, "이거라도 먹으니 위로가 되네요. 고마워요.", "이걸 {food}라고 내놓은 거예요?", "입에 맞긴 한데… 마음은 여전히 무겁네요.", "이게 내가 시킨 건 아니지만, 이상하게 힘이 나요."));

        Level2.Add(new DialogEntry(1, "{food}.", "아무것도 하기 싫은 하루에요", 0, 3, "그래도 이건 먹어야겠네요. 고마워요.", "이건 아니죠, {food}는 이게 아닌데.", "먹긴 했는데… 그냥 그런 하루네요.", "이게 왜인지… 기분이 좀 괜찮아졌어요."));

        Level2.Add(new DialogEntry(1, "오늘은 {food}이(가) 먹고 싶어.", "다른 사람보다 항상 부족한 것 같아요", 0, 4, "이런 정성 받으니 조금은 괜찮아지는 느낌이에요.", "이게 주문한 거랑 다르잖아요.", "딱 내가 원한 맛인데, 왜 이렇게 허전하죠?", "뭔가 틀렸는데… 기분은 묘하게 나아졌어요."));

        Level2.Add(new DialogEntry(1, "오늘은 {food}이(가) 먹고 싶어.", "앞날이 너무 불안해요", 0, 5, "{food}이라도 먹고 나면 좀 나아지겠죠. 고맙습니다.", "{food}라더니 완전 엉망이잖아.", "입은 즐거운데, 불안은 그대로네요.", "주문한건 아니긴 한데.. 불안이 조금 사라진 느낌이네요."));

        Level2.Add(new DialogEntry(1, "주세요,{food}.", "모두가 나를 무시하는 것 같아요", 0, 6, "적어도 당신은 날 챙겨주는군요. 고마워요.", "헐... {food} 이렇게 만드는 집 처음 보네.", "맛은 있었지만… 그뿐이었네요.", "뭐지… 이건 내가 시킨 건 아닌데, 마음은 가벼워졌어요."));

        Level2.Add(new DialogEntry(1, "푹신한 {food} 주세요.", "어젯밤에 들은 소리들이 머릿속을 떠나질 않아요. 괜찮다고 스스로를 다독이지만 손끝이 계속 떨려요.", 0, 1, "차분히 숨을 쉬고 이걸 한 입 먹으니… 조금은 현실로 돌아온 것 같아요. 정말 고마워요.", "이게… {food}라구요?", "맛은 있었는데, 그 맛조차 믿음이 안 가요. 현실이 맞는지 헷갈려요.", "내가 주문한 건 아닌데, 이상하게… 마음 깊은 곳에서 뭔가 가라앉는 느낌이에요."));

        Level2.Add(new DialogEntry(1, "{food}이라도 먹지 않으면 무너져버릴 것 같아요.", "계획했던 건 다 틀어지고, 노력은 허사가 되는 느낌이에요. 이렇게 계속 살아야 하나 싶을 정도로 지쳤어요.", 0, 2, "따뜻한 맛이 그대로 위로로 느껴져요. 오늘만은 스스로를 조금 안아주고 싶네요. 고마워요.", "난 그냥 또 하나의 실패를 삼킨 기분이에요.", "입은 즐거운데 마음은 여전히 밑바닥이에요. 잠깐의 위안일 뿐이겠죠.", "내가 시킨 건 아니지만, 이상하게 다시 시작해볼 수 있을 것 같아요. 조금은."));

        Level2.Add(new DialogEntry(1, "{food}으로 하나만 줘. 그냥 뭐라도 먹고 싶다는 생각이 드는 게 다행인 하루예요.", "창밖을 봐도 아무 감정이 없고, 웃긴 영상을 봐도 아무렇지 않아요. 감정이 텅 비었달까.", 0, 3, "이 맛… 오랜만에 뭔가 느껴지는 기분이에요. 그게 좋은 감정인지 아직은 잘 모르겠지만요.", "뭐, 어차피 아무 기대도 안 했으니까요.", "맛은 있는데요… 이게 기쁨이 맞는 감정인지조차 헷갈려요.", "내가 시킨 건 아니지만… 묘하게 안에서 뭔가 움직이기 시작했어요."));

        Level2.Add(new DialogEntry(1, "{food}이라면 나도… ", "계속 비교하게 돼요. 나보다 잘난 사람들, 빛나는 사람들. 그 앞에서 나는 너무 초라하죠.", 0, 4, "이 정성… 나도 누군가에게 이렇게 받아도 되는 존재였나요? 잠깐이지만 마음이 따뜻했어요.", "이게 내가 시킨 {food}인가요?", "맛은 있었지만, 왜 더 작아진 느낌이 들까요. 내 몫이 아닌 것 같은 기분이에요.", "이건 내가 주문한 건 아니지만… 이상하게 내 안의 목소리가 조금은 조용해졌어요."));

        Level2.Add(new DialogEntry(1, "제 머리를 당장 {food}(이)라도 먹어야 멈출 수 있을 것 같아요.", "내일은 뭘 준비해야 하지? 이게 맞는 선택일까? 무수한 가능성 속에서 길을 잃은 기분이에요.", 0, 5, "이 따뜻함… 적어도 지금만은 복잡한 생각에서 벗어날 수 있었어요. 고마워요.", "이게 {food}라니… 완전 계획에서 어긋났어요.", "입은 만족스러운데도, 머릿속은 여전히 복잡해요. 아무것도 정리되지 않았어요.", "내가 원한 건 아니지만, 신기하게도 잠깐은 불안이 멈춘 것 같아요."));

        Level2.Add(new DialogEntry(1, "하루종일 감정을 참느라 진이 빠졌어요. {food}이라도 제대로 나와야 덜 화날 것 같아요.", "모든 게 나를 억누르는 것 같았어요. 나만 이상한 사람처럼 몰아붙이고… 참는 것도 지쳤어요.", 0, 6, "이 {food}, 나를 위한 거라는 게 느껴졌어요. 그래서인지… 눈물이 나려 해요. 고마워요.", "이게 {food}라고요? 농담도 참… 장난하자는 거예요?", "맛은 있었지만요, 감정은 쉽게 식지 않네요. 먹는다고 다 풀리진 않죠.", "이건 내가 고른 건 아니지만… 마음이 스르르 놓여지는 기분이에요. 신기하네요."));
    }

    void AddLevel3()
    {

        Level3.Add(new DialogEntry(1, "오늘은 {food}이(가) 생각나더라고요. 그냥... 이유는 잘 모르겠어요.", "밤새 들려오던 그 소리들… 아무 일도 없었지만, 이상하게 무서웠어요.", 0, 1, "이걸 먹고 나니 조금은… 괜찮아지는 듯한 기분이 들어요. 뭐였더라, 그 감정이?", "{food} 맞긴 한가요? 왠지 더 낯설어졌어요.", "입 안에선 익숙한 맛인데, 마음은 어딘가 더 멀어져요.", "이건 내가 고른 게 아닌데… 잠시, 숨 쉴 틈이 생긴 것 같네요."));

        Level3.Add(new DialogEntry(1, "{food}(이)면 괜찮을 것 같기도 하고… 사실 잘 모르겠어요.", "몇 번이고 해봤지만 또 실패했어요. 어느 순간부터는 기대조차 안 하게 되네요.", 0, 2, "입에 퍼지는 온기가… 묘하게 나를 붙잡아주는 기분이에요.", "이게 {food}라면… 난 뭘 잘못 알고 있었나봐요.", "먹고 있으면서도 마음이 계속 아래로 가라앉네요.", "내가 원했던 건 아닌데, 이상하게 손끝이 다시 움직여요."));

        Level3.Add(new DialogEntry(1, "{food}(이)나 먹어야겠죠. 뭐라도 해야 하는 날이니까요.", "창밖은 밝은데, 안은 깜깜해요. 가끔 그런 날이 있죠.", 0, 3, "한 입 먹고 나니… 뭔가 살아있는 느낌이 잠깐 스쳐갔어요.", "{food}라고요? 하긴, 딱히 다를 것도 없죠.", "맛은 있는데 그걸 느끼는 내가 낯설어요.", "이건 내가 고른 건 아닌데, 조금은 깨어난 기분이에요."));

        Level3.Add(new DialogEntry(1, "{food}은(는)… 그냥, 남들도 좋아하잖아요.", "비춰보면 알 수 있어요. 누구나 반짝이는데, 난 좀 어두운 것 같거든요.", 0, 4, "이런 것도 받는구나, 나도. 아직은 좀 어색하네요.", "{food}? 아니겠죠, 아무래도.", "이건 내 몫이 아니라고 느끼는 건… 나 때문이겠죠.", "주문한 건 아니지만, 조용했던 속이 조금씩 움직여요."));

        Level3.Add(new DialogEntry(1, "머리가 너무 시끄러워요. {food}(이)라도 먹으면 조용해질까요?", "하나만 틀어져도 다 무너질 것 같아요. 별일도 아닌데 계속 신경이 곤두서요.", 0, 5, "잠깐이지만… 지금은 조금 조용하네요. 그거면 충분하죠.", "이게 계획한 {food}는 아니었을 텐데… 흐트러졌네요.", "먹고 있는데도 머릿속은 여전히 시끄러워요.", "이게 내가 고른 건 아니었지만, 묘하게 마음이 조용해졌어요."));

        Level3.Add(new DialogEntry(1, "솔직히 말해서… {food} 하나라도 마음대로 안 나오면 정말 폭발할지도 몰라요.", "참는 게 습관이 되어버렸어요. 근데 그런 날 있잖아요. 더는 못 참겠는 날.", 0, 6, "이 맛… 이상하게 눈물이 나려 해요. 분명 맛 때문만은 아닐 텐데.", "{food}이라니… 이건 좀 심하네요.", "맛은 좋은데요, 안에 쌓인 건 아직 그대로예요.", "이건 내가 시킨 건 아니지만, 왜인지 화가 좀 가라앉았어요."));

    }

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

        List<int> candidateIndices = new List<int>();
        for (int i = 0; i < targetList.Count; i++)
        {
            if (!recentIndices.Contains(i))
                candidateIndices.Add(i);
        }

        if (candidateIndices.Count == 0)
        {
            for (int i = 0; i < targetList.Count; i++)
                candidateIndices.Add(i);
        }

        int chosenIndex = candidateIndices[random.Next(candidateIndices.Count)];

        recentIndices.Enqueue(chosenIndex);
        if (recentIndices.Count > maxRecent)
            recentIndices.Dequeue();

        DialogEntry original = targetList[chosenIndex];

        int foodIndex = Random.Range(0, foodNames.Length);
        int moodIndex = Random.Range(0, 8);
        string foodName = foodNames[foodIndex];

        DialogEntry entry = original.Clone();
        entry.CharNum = moodIndex;
        entry.Text1 = entry.Text1.Replace("{food}", foodName);
        entry.WinText = entry.WinText.Replace("{food}", foodName);
        entry.LoseText = entry.LoseText.Replace("{food}", foodName);
        entry.Food = foodIndex + 1;

        return entry;
    }
}
