using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    //���� �Ŵ��� (����� ��ư Ŭ����) / (��� �� ���� On)  / ����, �����, ����, ����, �г�, �Ҿ�
    /*
        �ڽŰ��� �ִ� ��������ũ (����)
        ����� �ִ� ġ��Ļ� (�����)
        ��⸦ �������ִ� ���ڻ� (����)
        �������� ���� ���� (����)
        ������ ����.(�Ҿ�)
        ������ �Ź̸���(�г�)

        
        �Ź�ġ�� + ����� = ���ڻ�
        �Ź�ġ�� + �������� = ����
        �������� + ����� = ��������ũ 
        �Ź�ġ�� = ġ��Ļ�
        ����� = ���� ����
        �������� = �������� ����
     */

    public bool SpiderCheese = false;
    public bool FrogEye = false;
    public bool StarwBerry = false;
    public bool BDoughnut = false;
    public bool PB = false;
    public bool FC = false;
    public bool CB = false;
    public bool SBD = false;
    public bool SM = false;

    public GameObject Dough;
    public GameObject Spider;
    public GameObject Frog;
    public GameObject Berry;
    public GameObject Doughnut;
    public GameObject PizzaBread;
    public GameObject FruitCake;
    public GameObject CheeseBread;
    public GameObject SBDoughnut;
    public GameObject SpiderMuffin;

    public void SC()
    {
        if (Spider.activeSelf)
        {
            Debug.Log("�̹� ���� ������Դϴ�.");
            return;
        }
        if (Dough.activeSelf)
        {
            Debug.Log("�̹� ������ �ϼ� �Ǿ����ϴ�.");
            return;
        }
        if (Doughnut.activeSelf || PizzaBread.activeSelf || FruitCake.activeSelf || CheeseBread.activeSelf || SBDoughnut.activeSelf || SpiderMuffin.activeSelf)
        {
            Debug.Log("�̹� ���� ����̽��ϴ�.");
            return;
        }
        SpiderCheese = true;
        Debug.Log("�Ź�ġ� ���� ����߽��ϴ�.");
        Spider.SetActive(true);
    }


    public void FE()
    {

        if (Frog.activeSelf)
        {
            Debug.Log("�̹� ���� ������Դϴ�.");
            return;
        }
        if (Dough.activeSelf)
        {
            Debug.Log("�̹� ������ �ϼ� �Ǿ����ϴ�.");
            return;
        }
        if (Doughnut.activeSelf || PizzaBread.activeSelf || FruitCake.activeSelf || CheeseBread.activeSelf || SBDoughnut.activeSelf || SpiderMuffin.activeSelf)
        {
            Debug.Log("�̹� ���� ����̽��ϴ�.");
            return;
        }
        FrogEye = true;
        Debug.Log("���������� ���� ����߽��ϴ�.");
        Frog.SetActive(true);
    }

    public void SB()
    {
        if (Berry.activeSelf)
        {
            Debug.Log("�̹� ���� ������Դϴ�.");
            return;
        }
        if (Dough.activeSelf)
        {
            Debug.Log("�̹� ������ �ϼ� �Ǿ����ϴ�.");
            return;
        }
        if (Doughnut.activeSelf || PizzaBread.activeSelf || FruitCake.activeSelf || CheeseBread.activeSelf || SBDoughnut.activeSelf || SpiderMuffin.activeSelf)
        {
            Debug.Log("�̹� ���� ����̽��ϴ�.");
            return;
        }

        StarwBerry = true;
        Debug.Log("�������� ���⸦ ���� ����߽��ϴ�.");
        Berry.SetActive(true);
    }

    public void Synthesis()
    {
        if (SpiderCheese == true && FrogEye == true && StarwBerry == false)
        {
            Spider.SetActive(false);
            Berry.SetActive(false);
            Frog.SetActive(false);
            Dough.SetActive(true);



            Debug.Log("������ ���ӹ����� ��������ϴ�.");
        }
        else if (SpiderCheese == false && FrogEye == true && StarwBerry == true)
        {
            Spider.SetActive(false);
            Berry.SetActive(false);
            Frog.SetActive(false);
            Dough.SetActive(true);


            Debug.Log("�ڽŰ��� �ִ� ��������ũ ������ ��������ϴ�.");
        }
        else if (SpiderCheese == true && FrogEye == false && StarwBerry == true)
        {
            Spider.SetActive(false);
            Berry.SetActive(false);
            Frog.SetActive(false);
            Dough.SetActive(true);


            Debug.Log("��⸦ �������ִ� ���ڻ� ������ ��������ϴ�.");
        }
        else if (SpiderCheese == true && FrogEye == false && StarwBerry == false)
        {
            Spider.SetActive(false);
            Frog.SetActive(false);
            Berry.SetActive(false);
            Dough.SetActive(true);
            Debug.Log("����� �ִ� ġ��Ļ������� ��������ϴ�.");
        }
        else if (SpiderCheese == false && FrogEye == true && StarwBerry == false)
        {
            Spider.SetActive(false);
            Frog.SetActive(false);
            Berry.SetActive(false);
            Dough.SetActive(true);
            Debug.Log("������ �Ź̸��ɹ����� ��������ϴ�.");
        }
        else if (SpiderCheese == false && FrogEye == false && StarwBerry == true)
        {
            Spider.SetActive(false);
            Frog.SetActive(false);
            Berry.SetActive(false);
            Dough.SetActive(true);
            Debug.Log("�������� ���� ���ӹ����� ��������ϴ�.");
        }


    }

    public void Reset()
    {

        FrogEye = false;
        SpiderCheese = false;
        StarwBerry = false;
        BDoughnut = false;
        PB = false;
        FC = false;
        CB = false;
        SBD = false;
        SM = false;


        Spider.SetActive(false);
        Frog.SetActive(false);
        Berry.SetActive(false);
        Dough.SetActive(false);
        Doughnut.SetActive(false);
        PizzaBread.SetActive(false);
        FruitCake.SetActive(false);
        CheeseBread.SetActive(false);
        SBDoughnut.SetActive(false);
        SpiderMuffin.SetActive(false);
        Debug.Log("������ �� �� ȭ");
    }

    public void Bake()
    {
        if (SpiderCheese == true && FrogEye == true && StarwBerry == false)
        {
            Spider.SetActive(false);
            Berry.SetActive(false);
            Frog.SetActive(false);
            Dough.SetActive(false);

            Doughnut.SetActive(true);

            BDoughnut = true;
            FrogEye = false;
            SpiderCheese = false;
            StarwBerry = false;
            PB = false;
            FC = false;
            CB = false;
            SBD = false;
            SM = false;

            Debug.Log("������ ������ ���������ϴ�.");
        }
        else if (SpiderCheese == true && FrogEye == false && StarwBerry == false)
        {
            Spider.SetActive(false);
            Berry.SetActive(false);
            Frog.SetActive(false);
            Dough.SetActive(false);

            CheeseBread.SetActive(true);

            CB = true;
            FrogEye = false;
            SpiderCheese = false;
            StarwBerry = false;
            BDoughnut = false;
            PB = false;
            FC = false;
            SBD = false;
            SM = false;

            Debug.Log("����� �ִ� ġ��Ļ��� ���������ϴ�.");
        }
        else if (SpiderCheese == true && FrogEye == false && StarwBerry == true)
        {
            Spider.SetActive(false);
            Berry.SetActive(false);
            Frog.SetActive(false);
            Dough.SetActive(false);

            PizzaBread.SetActive(true);

            PB = true;
            FrogEye = false;
            SpiderCheese = false;
            StarwBerry = false;
            BDoughnut = false;
            FC = false;
            CB = false;
            SBD = false;
            SM = false;

            Debug.Log("��⸦ �������ִ� ���ڻ��� ���������ϴ�.");
        }
        else if (SpiderCheese == false && FrogEye == false && StarwBerry == true)
        {
            Spider.SetActive(false);
            Berry.SetActive(false);
            Frog.SetActive(false);
            Dough.SetActive(false);

            SBDoughnut.SetActive(true);

            SBD = true;
            FrogEye = false;
            SpiderCheese = false;
            StarwBerry = false;
            BDoughnut = false;
            PB = false;
            FC = false;
            CB = false;
            SM = false;

            Debug.Log("�������� ���� ������ ���������ϴ�.");
        }
        else if (SpiderCheese == false && FrogEye == true && StarwBerry == true)
        {
            Spider.SetActive(false);
            Berry.SetActive(false);
            Frog.SetActive(false);
            Dough.SetActive(false);

            FruitCake.SetActive(true);

            FC = true;
            FrogEye = false;
            SpiderCheese = false;
            StarwBerry = false;
            BDoughnut = false;
            PB = false;
            CB = false;
            SBD = false;
            SM = false;

            Debug.Log("�ڽŰ��� �ִ� ��������ũ�� ���������ϴ�.");
        }
        else if (SpiderCheese == false && FrogEye == true && StarwBerry == false)
        {
            Spider.SetActive(false);
            Berry.SetActive(false);
            Frog.SetActive(false);
            Dough.SetActive(false);

            SpiderMuffin.SetActive(true);

            SM = true;
            FrogEye = false;
            SpiderCheese = false;
            StarwBerry = false;
            BDoughnut = false;
            PB = false;
            FC = false;
            CB = false;
            SBD = false;

            Debug.Log("������ �Ź̸����� ���������ϴ�.");
        }

    }

}