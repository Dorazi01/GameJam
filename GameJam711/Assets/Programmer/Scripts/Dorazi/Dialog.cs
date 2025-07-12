using System.Collections.Generic;
using UnityEngine;

public class Dialog
{
    public List<DialogEntry> Level1 = new List<DialogEntry>();
    public List<DialogEntry> Level2 = new List<DialogEntry>();
    public List<DialogEntry> Level3 = new List<DialogEntry>();

    private System.Random random = new System.Random();

    // �ֱ� 3���� �ε����� ������ ť
    private Queue<int> recentIndices = new Queue<int>();

    // �ִ� ���� ����
    private const int maxRecent = 3;

    public Dialog()
    {

        /*
         ������ :

        �ڽŰ��� �ִ� ��������ũ (����)3
        ����� �ִ� ġ��Ļ� (�����)4
        ��⸦ �������ִ� ���ڻ� (����)2
        �������� ���� ���� (����)5
        ������ ����.(�Ҿ�)1
        ������ ����������(�г�)6

        


        1 = ���� �Ź�ġ�� + �������� 
        2 = ���ڻ� �Ź�ġ�� + ����� 
        3 = ��������ũ �������� + ����� 
        4 = ġ� �Ź�ġ��
        5 = ���⵵�� �����
        6 = ���������� ��������
         */
        





        Level1.Add(new DialogEntry("������ ������ �԰� �;�.", 1, "��� �����̴�!!!!", "�̵���...����?"));
        Level1.Add(new DialogEntry("ġ� �ܶ� �� ���� �ʿ���!", 4, "ġ� �ְ��� ��~", "�̰� ġ����? �����̶� Ǫ�� �ʿ��� �ٴ��� ó�� �����ݾ�!"));
        Level1.Add(new DialogEntry("���������� ���� ������ �԰�;�!", 6, "��� ��������� �����̴�!", "�̰� ����������? �� ���� ���������� ��� �� �¾ 3�ð�¥�� �ֱ⺸�� ��������!!"));
        Level1.Add(new DialogEntry("����� ������ �־�?", 5, "�Ƹ޸�ĭ ������ ���� ������", "���� ������ݾ�!"));
        Level1.Add(new DialogEntry("�� ���� �����̾�..!", 3, "�������༭ ����!!!", "��.....����?"));
        Level1.Add(new DialogEntry("���ڻ�? �̰� ����?", 2, "�� ���ú��� ���ڻ� ���̴�. ���ڻ��� ���ϴ°��� �� ���ϴ� ���̸� ��¼����¼��....", "�� �����ⰰ�� �޴��� ����? ���� ġ��"));


        Level2.Add(new DialogEntry("", 1, "�̱�", "��"));
        Level2.Add(new DialogEntry("12����", 2, "�̱�", "��"));
        Level2.Add(new DialogEntry("12����", 3, "�̱�", "��"));
        Level2.Add(new DialogEntry("12����", 4, "�̱�", "��"));
        Level2.Add(new DialogEntry("", 5, "�̱�", "��"));
        Level2.Add(new DialogEntry("", 6, "�̱�", "��"));



        Level3.Add(new DialogEntry("���´��� �׷��µ�, ���� ���Ẹ�� ���� ����ϴ�.. ���� �º��� ���Ѱ� ����..?", 5, "�̱�", "��"));
        Level3.Add(new DialogEntry("���� ���� ���迡�� �Ǽ��߾�... �� �� �ص� �ȵǴ°ɱ�...", 2, "�¾� �̹����� �Ǽ����� �� �� �� �����ž�!", "�� ������� ��������"));
        Level3.Add(new DialogEntry("....�����ұ�? �Ƴ� �������� ���ݾ� ���ݸ� ������... �ٵ� �������� �����? �����̶�??", 1, "���� ���п� ū ���� ������", "�ʶ����̾߳ʶ����̾߳ʶ����̾߳ʶ����̾߳ʶ����̾߳ʶ����̾߳ʶ����̾߳ʶ����̾�"));
        Level3.Add(new DialogEntry("���� ���� �� ������� �� ����..", 3, "����! �������� �����̾�����!", "��...�ʰ� ������°���? ��ġ?"));
        Level3.Add(new DialogEntry("!@$@!$$!@$#@#", 6, "��... ����~", "!@#!@$!@$!@#@!#!#!#!@#@!#@!#!@#!@$!@#$!@#!@"));
        Level3.Add(new DialogEntry("..............", 4, "��ȣ! ������ �Ƹ��ٿ�!", "......t('^')t"));



    }

    // ������ ���� ��� ��ȯ (�ֱ� 3�� �ֹ��� �ߺ� �� �ǰ�)
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

        // �ĺ� �ε��� ����Ʈ ���� (�ֱ� 3�� �ε��� ����)
        List<int> candidateIndices = new List<int>();
        for (int i = 0; i < targetList.Count; i++)
        {
            if (!recentIndices.Contains(i))
                candidateIndices.Add(i);
        }

        // ���� �ĺ��� ���ٸ�(��ü�� �ֱٿ� ��������) ��� �ε����� �ĺ��� (�ߺ� ���)
        if (candidateIndices.Count == 0)
        {
            for (int i = 0; i < targetList.Count; i++)
            {
                candidateIndices.Add(i);
            }
        }

        // �ĺ� �߿��� ���� ����
        int chosenIndex = candidateIndices[random.Next(candidateIndices.Count)];

        // �ֱ� �ε��� ť�� �߰�
        recentIndices.Enqueue(chosenIndex);
        if (recentIndices.Count > maxRecent)
        {
            recentIndices.Dequeue();
        }

        return targetList[chosenIndex];
    }
}