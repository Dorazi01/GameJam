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
        





        Level1.Add(new DialogEntry("������ ������ �԰� �;�.", 1, "�̱�", "��"));
        Level1.Add(new DialogEntry("ġ� �ܶ� �� ���� �ʿ���!", 4, "�̱�", "��"));
        Level1.Add(new DialogEntry("���������� ���� ������ �԰�;�!", 6, "�̱�", "��"));
        Level1.Add(new DialogEntry("����� ������ �־�?", 5, "�̱�", "��"));
        Level1.Add(new DialogEntry("�� ���� �����̾�..!", 3, "�̱�", "��"));
        Level1.Add(new DialogEntry("���ڻ�? �̰� ����?", 2, "�̱�", "��"));


        Level2.Add(new DialogEntry("", 1, "�̱�", "��"));
        Level2.Add(new DialogEntry("12����", 2, "�̱�", "��"));
        Level2.Add(new DialogEntry("12����", 3, "�̱�", "��"));
        Level2.Add(new DialogEntry("12����", 4, "�̱�", "��"));
        Level2.Add(new DialogEntry("", 5, "�̱�", "��"));
        Level2.Add(new DialogEntry("", 6, "�̱�", "��"));



        Level3.Add(new DialogEntry("���´��� �׷��µ�, ���� ���Ẹ�� ���� ����ϴ�.. ���� �º��� ���Ѱ� ����..?", 5, "�̱�", "��"));
        Level3.Add(new DialogEntry("���� ���� ���迡�� �Ǽ��߾�... �� �� �ص� �ȵǴ°ɱ�...", 2, "�̱�", "��"));
        Level3.Add(new DialogEntry("....�����ұ�? �Ƴ� �������� ���ݾ� ���ݸ� ������... �ٵ� �������� �����? �����̶�??", 1, "�̱�", "��"));
        Level3.Add(new DialogEntry("���� ���� �� ������� �� ����..", 3, "�̱�", "��"));
        Level3.Add(new DialogEntry("!@$@!$$!@$#@#", 6, "�̱�", "��"));
        Level3.Add(new DialogEntry("..............", 4, "�̱�", "��"));



    }

    // ������ ���� ��� ��ȯ
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