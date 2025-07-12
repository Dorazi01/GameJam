using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dialog
{
    public List<DialogEntry> Level1 = new List<DialogEntry>();
    public List<DialogEntry> Level2 = new List<DialogEntry>();
    public List<DialogEntry> Level3 = new List<DialogEntry>();

    private System.Random random = new System.Random();
    private Queue<int> recentIndices = new Queue<int>();
    private const int maxRecent = 3;


    /*
      Level1.Add(new DialogEntry(1,"오늘은 {food}이 먹고 싶어.","공포", 0, 1, "우왕 {food}이당!!!!","이딴게...{food}?", "음시기안마자", "기분틀렸어"));
        Level1.Add(new DialogEntry(1, "오늘은 {food}이 먹고 싶어.", "좌절", 0, 2, "우왕 {food}이당!!!!", "이딴게...{food}?", "음시기안마자", "기분틀렸어"));
        Level1.Add(new DialogEntry(1, "오늘은 {food}이 먹고 싶어.", "무기력", 0, 3, "우왕 {food}이당!!!!", "이딴게...{food}?", "음시기안마자", "기분틀렸어"));
     */

    string[] foodNames = { "개구리파이", "피자빵", "과일케이크", "치즈식빵", "딸기도넛", "개구리머핀" };

    public Dialog()
    {

        // 대사 등록 시에는 {food} 같은 플레이스홀더 사용
        Level1.Add(new DialogEntry(1, "오늘은 {food}이(가) 먹고 싶어.", "악몽 때문에 잠을 못 잤어요", 0, 1, "이거 먹으면 좀 나아질 것 같아요, 고마워요.", "이게 {food} 맞아요...?", "맛은 괜찮은데… 그냥 그런 느낌이네요.", "기분은 좀 나아졌는데, 이건 내가 시킨 게 아닌데요?"));
        Level1.Add(new DialogEntry(1, "오늘은 {food}이 먹고 싶어.", "무언가 날 따라다니는 것 같아서요", 0, 1, "따뜻한 {food}, 덕분에 마음이 조금 놓여요.", "이딴 게 {food}라고요?", "음식은 잘 받았는데… 기분은 그대로네요.", "맛은 아닌데… 묘하게 마음이 가벼워지네요."));

        Level1.Add(new DialogEntry(1, "오늘은 {food}이 먹고 싶어.", "계속 실패만 하는 기분이에요", 0, 2, "이거라도 먹으니 위로가 되네요. 고마워요.", "이걸 {food}라고 내놓은 거예요?", "입에 맞긴 한데… 마음은 여전히 무겁네요.", "이게 내가 시킨 건 아니지만, 이상하게 힘이 나요."));
        Level1.Add(new DialogEntry(1, "오늘은 {food}이 먹고 싶어.", "제가 뭘 해도 안 되는 것 같아서요", 0, 2, "따뜻한 {food} 한 입이 위안이 되네요.", "{food}? 이런 걸 시킨 적 없는데요.", "맛은 맞는데… 위로가 되진 않네요.", "주문은 틀렸는데, 기분은 조금 나아졌어요."));

        Level1.Add(new DialogEntry(1, "오늘은 {food}이 먹고 싶어.", "아무것도 하기 싫은 하루에요", 0, 3, "그래도 이건 먹어야겠네요. 고마워요.", "이건 아니죠, {food}는 이게 아닌데.", "먹긴 했는데… 그냥 그런 하루네요.", "이게 왜인지… 기분이 좀 괜찮아졌어요."));
        Level1.Add(new DialogEntry(1, "오늘은 {food}이 먹고 싶어.", "의욕이 전혀 안 나네요", 0, 3, "{food} 덕분에 기운이 조금 나려는 걸요.", "장난하세요? {food}라며.", "음식은 그대로인데… 마음은 안 움직여요.", "맛은 별로인데… 이상하게 조금 웃고 있네요."));

        Level1.Add(new DialogEntry(1, "오늘은 {food}이 먹고 싶어.", "다른 사람보다 항상 부족한 것 같아요", 0, 4, "이런 정성 받으니 조금은 괜찮아지는 느낌이에요.", "이게 주문한 거랑 다르잖아요.", "딱 내가 원한 맛인데, 왜 이렇게 허전하죠?", "뭔가 틀렸는데… 기분은 묘하게 나아졌어요."));
        Level1.Add(new DialogEntry(1, "오늘은 {food}이 먹고 싶어.", "제 모습이 싫어요", 0, 4, "{food} 같은 걸 챙겨주는 사람도 있군요. 고마워요.", "이건 {food}가 아니잖아...", "맛은 있는데… 마음은 별로 나아지질 않네요.", "이게 {food}는 아닌데, 왠지 내가 조금 괜찮아진 느낌이에요."));

        Level1.Add(new DialogEntry(1, "오늘은 {food}이 먹고 싶어.", "앞날이 너무 불안해요", 0, 5, "{food}이라도 먹고 나면 좀 나아지겠죠. 고맙습니다.", "{food}라더니 완전 엉망이잖아.", "입은 즐거운데, 불안은 그대로네요.", "맛은 실망인데… 불안이 조금 사라진 느낌이에요."));
        Level1.Add(new DialogEntry(1, "오늘은 {food}이 먹고 싶어.", "무슨 선택을 해도 불안하네요", 0, 5, "이건 틀린 선택 아니겠죠? 고마워요.", "내가 시킨 건 {food}였거든요?", "이 맛이긴 한데… 머릿속은 여전히 복잡하네요.", "이게 내가 고른 건 아닌데, 마음이 조금 정리된 느낌이에요."));

        Level1.Add(new DialogEntry(1, "오늘은 {food}이 먹고 싶어.", "모두가 나를 무시하는 것 같아요", 0, 6, "적어도 당신은 날 챙겨주는군요. 고마워요.", "헐... {food} 이렇게 만드는 집 처음 보네.", "맛은 있었지만… 그뿐이었네요.", "뭐지… 이건 내가 시킨 건 아닌데, 마음은 가벼워졌어요."));
        Level1.Add(new DialogEntry(1, "오늘은 {food}이 먹고 싶어.", "왜 나만 이런 대우를 받아야 하죠?", 0, 6, "이걸 챙겨주는 당신 덕분에 조금은 나아졌어요.", "{food} 하나 제대로 못 하세요?", "입맛엔 맞았지만, 속은 여전히 화가 나네요.", "기분은 조금 괜찮아졌네요… 이상하네, 이게 아닌데."));
    }




    // 레벨별 랜덤 대사 반환 (최근 3개 중복 방지 + 랜덤 음식 적용)
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

        // 최근 3개 제외한 인덱스 리스트 생성
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

        // 랜덤 음식 생성
        int foodIndex = Random.Range(0, foodNames.Length);
        int moodIndex= Random.Range(0, 8);
        string foodName = foodNames[foodIndex];

        // 복사본 생성 후 플레이스홀더 치환
        DialogEntry entry = original.Clone();
        entry.CharNum = moodIndex;
        entry.Text1 = entry.Text1.Replace("{food}", foodName);
        entry.WinText = entry.WinText.Replace("{food}", foodName);
        entry.LoseText = entry.LoseText.Replace("{food}", foodName);
        entry.Food = foodIndex + 1; // 음식 번호는 1부터 시작한다고 가정

        return entry;
    }
}
