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
      Level1.Add(new DialogEntry(1,"������ {food}�� �԰� �;�.","����", 0, 1, "��� {food}�̴�!!!!","�̵���...{food}?", "���ñ�ȸ���", "���Ʋ�Ⱦ�"));
        Level1.Add(new DialogEntry(1, "������ {food}�� �԰� �;�.", "����", 0, 2, "��� {food}�̴�!!!!", "�̵���...{food}?", "���ñ�ȸ���", "���Ʋ�Ⱦ�"));
        Level1.Add(new DialogEntry(1, "������ {food}�� �԰� �;�.", "�����", 0, 3, "��� {food}�̴�!!!!", "�̵���...{food}?", "���ñ�ȸ���", "���Ʋ�Ⱦ�"));
     */

    string[] foodNames = { "����������", "���ڻ�", "��������ũ", "ġ��Ļ�", "���⵵��", "����������" };

    public Dialog()
    {

        // ��� ��� �ÿ��� {food} ���� �÷��̽�Ȧ�� ���
        Level1.Add(new DialogEntry(1, "������ {food}��(��) �԰� �;�.", "�Ǹ� ������ ���� �� ����", 0, 1, "�̰� ������ �� ������ �� ���ƿ�, ������.", "�̰� {food} �¾ƿ�...?", "���� ���������� �׳� �׷� �����̳׿�.", "����� �� �������µ�, �̰� ���� ��Ų �� �ƴѵ���?"));
        Level1.Add(new DialogEntry(1, "������ {food}�� �԰� �;�.", "���� �� ����ٴϴ� �� ���Ƽ���", 0, 1, "������ {food}, ���п� ������ ���� ������.", "�̵� �� {food}����?", "������ �� �޾Ҵµ��� ����� �״�γ׿�.", "���� �ƴѵ��� ���ϰ� ������ ���������׿�."));

        Level1.Add(new DialogEntry(1, "������ {food}�� �԰� �;�.", "��� ���и� �ϴ� ����̿���", 0, 2, "�̰Ŷ� ������ ���ΰ� �ǳ׿�. ������.", "�̰� {food}��� ������ �ſ���?", "�Կ� �±� �ѵ��� ������ ������ ���̳׿�.", "�̰� ���� ��Ų �� �ƴ�����, �̻��ϰ� ���� ����."));
        Level1.Add(new DialogEntry(1, "������ {food}�� �԰� �;�.", "���� �� �ص� �� �Ǵ� �� ���Ƽ���", 0, 2, "������ {food} �� ���� ������ �ǳ׿�.", "{food}? �̷� �� ��Ų �� ���µ���.", "���� �´µ��� ���ΰ� ���� �ʳ׿�.", "�ֹ��� Ʋ�ȴµ�, ����� ���� ���������."));

        Level1.Add(new DialogEntry(1, "������ {food}�� �԰� �;�.", "�ƹ��͵� �ϱ� ���� �Ϸ翡��", 0, 3, "�׷��� �̰� �Ծ�߰ڳ׿�. ������.", "�̰� �ƴ���, {food}�� �̰� �ƴѵ�.", "�Ա� �ߴµ��� �׳� �׷� �Ϸ�׿�.", "�̰� �������� ����� �� �����������."));
        Level1.Add(new DialogEntry(1, "������ {food}�� �԰� �;�.", "�ǿ��� ���� �� ���׿�", 0, 3, "{food} ���п� ����� ���� ������ �ɿ�.", "�峭�ϼ���? {food}���.", "������ �״���ε��� ������ �� ��������.", "���� �����ε��� �̻��ϰ� ���� ���� �ֳ׿�."));

        Level1.Add(new DialogEntry(1, "������ {food}�� �԰� �;�.", "�ٸ� ������� �׻� ������ �� ���ƿ�", 0, 4, "�̷� ���� ������ ������ ���������� �����̿���.", "�̰� �ֹ��� �Ŷ� �ٸ��ݾƿ�.", "�� ���� ���� ���ε�, �� �̷��� ��������?", "���� Ʋ�ȴµ��� ����� ���ϰ� ���������."));
        Level1.Add(new DialogEntry(1, "������ {food}�� �԰� �;�.", "�� ����� �Ⱦ��", 0, 4, "{food} ���� �� ì���ִ� ����� �ֱ���. ������.", "�̰� {food}�� �ƴ��ݾ�...", "���� �ִµ��� ������ ���� �������� �ʳ׿�.", "�̰� {food}�� �ƴѵ�, ���� ���� ���� �������� �����̿���."));

        Level1.Add(new DialogEntry(1, "������ {food}�� �԰� �;�.", "�ճ��� �ʹ� �Ҿ��ؿ�", 0, 5, "{food}�̶� �԰� ���� �� ����������. �����ϴ�.", "{food}����� ���� �������ݾ�.", "���� ��ſ, �Ҿ��� �״�γ׿�.", "���� �Ǹ��ε��� �Ҿ��� ���� ����� �����̿���."));
        Level1.Add(new DialogEntry(1, "������ {food}�� �԰� �;�.", "���� ������ �ص� �Ҿ��ϳ׿�", 0, 5, "�̰� Ʋ�� ���� �ƴϰ���? ������.", "���� ��Ų �� {food}���ŵ��?", "�� ���̱� �ѵ��� �Ӹ����� ������ �����ϳ׿�.", "�̰� ���� �� �� �ƴѵ�, ������ ���� ������ �����̿���."));

        Level1.Add(new DialogEntry(1, "������ {food}�� �԰� �;�.", "��ΰ� ���� �����ϴ� �� ���ƿ�", 0, 6, "��� ����� �� ì���ִ±���. ������.", "��... {food} �̷��� ����� �� ó�� ����.", "���� �־������� �׻��̾��׿�.", "������ �̰� ���� ��Ų �� �ƴѵ�, ������ �����������."));
        Level1.Add(new DialogEntry(1, "������ {food}�� �԰� �;�.", "�� ���� �̷� ��츦 �޾ƾ� ����?", 0, 6, "�̰� ì���ִ� ��� ���п� ������ ���������.", "{food} �ϳ� ����� �� �ϼ���?", "�Ը��� �¾�����, ���� ������ ȭ�� ���׿�.", "����� ���� ���������׿䡦 �̻��ϳ�, �̰� �ƴѵ�."));
    }




    // ������ ���� ��� ��ȯ (�ֱ� 3�� �ߺ� ���� + ���� ���� ����)
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

        // �ֱ� 3�� ������ �ε��� ����Ʈ ����
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

        // ���� ���� ����
        int foodIndex = Random.Range(0, foodNames.Length);
        int moodIndex= Random.Range(0, 8);
        string foodName = foodNames[foodIndex];

        // ���纻 ���� �� �÷��̽�Ȧ�� ġȯ
        DialogEntry entry = original.Clone();
        entry.CharNum = moodIndex;
        entry.Text1 = entry.Text1.Replace("{food}", foodName);
        entry.WinText = entry.WinText.Replace("{food}", foodName);
        entry.LoseText = entry.LoseText.Replace("{food}", foodName);
        entry.Food = foodIndex + 1; // ���� ��ȣ�� 1���� �����Ѵٰ� ����

        return entry;
    }
}
