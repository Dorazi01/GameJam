using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager instance; // �̱��� �ν��Ͻ�
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

    //�̰� ������ ���߾����ǵ� ���� ��ü�� �Ӽ�(����)�� �ִ°� �ƴ϶� ���ϴ°� ����� �ְ�, �ű⿡ ��÷���� �󺥴� �̷��� ������ �ȴ� ������
    //������ �̷����ϸ� 6X6�̶� 36�ε�, �Ӽ� ĭ�� ���� �ϳ��� ����, ���Ŀ� �Ӽ��� �ִ°� �ƴ϶�, ������ ���Ĵ�� �����, �Ӽ��� �Ӽ���� �ִ°� ������
    //��� : ����� �� ���� ĭ �ϳ� �����, �װ� �´����� ���� �ľ��ϸ�ɵ�

    //�ʰ� ����� �� �� : ��� ���ϱ䵥, �����þ��� ����



    

    public bool SpiderCheese = false;
    public bool FrogEye = false;
    public bool StarwBerry = false;
    public bool BDoughnut = false;
    public bool PB = false;
    public bool FC = false;
    public bool CB = false;
    public bool SBD = false;
    public bool SM = false;
    public bool dough = false;

    public GameObject Dough;
    public GameObject Spider;
    public GameObject Frog;
    public GameObject Berry;
    public GameObject FrogPie;
    public GameObject PizzaBread;
    public GameObject FruitCake;
    public GameObject CheeseBread;
    public GameObject SBDoughnut;
    public GameObject SpiderMuffin;

    public GameObject RawDough; // ���� ���¸� ��Ÿ���� ����
  

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
        if (FrogPie.activeSelf || PizzaBread.activeSelf || FruitCake.activeSelf || CheeseBread.activeSelf || SBDoughnut.activeSelf || SpiderMuffin.activeSelf)
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
        if (FrogPie.activeSelf || PizzaBread.activeSelf || FruitCake.activeSelf || CheeseBread.activeSelf || SBDoughnut.activeSelf || SpiderMuffin.activeSelf)
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
        if (FrogPie.activeSelf || PizzaBread.activeSelf || FruitCake.activeSelf || CheeseBread.activeSelf || SBDoughnut.activeSelf || SpiderMuffin.activeSelf)
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
        dough = true;
        UIMananger.instance.RawDoughCreate = false;
        if (SpiderCheese == true && FrogEye == true && StarwBerry == false)
        {
            Spider.SetActive(false);
            Berry.SetActive(false);
            Frog.SetActive(false);
            RawDough.SetActive(false);
            Dough.SetActive(true);

            Debug.Log("���ӹ����� ��������ϴ�.");
        }
        else if (SpiderCheese == false && FrogEye == true && StarwBerry == true)
        {
            Spider.SetActive(false);
            Berry.SetActive(false);
            Frog.SetActive(false);
            RawDough.SetActive(false);
            Dough.SetActive(true);

            Debug.Log("��������ũ ������ ��������ϴ�.");
        }
        else if (SpiderCheese == true && FrogEye == false && StarwBerry == true)
        {
            Spider.SetActive(false);
            Berry.SetActive(false);
            Frog.SetActive(false);
            RawDough.SetActive(false);
            Dough.SetActive(true);


            Debug.Log(" ���ڻ� ������ ��������ϴ�.");
        }
        else if (SpiderCheese == true && FrogEye == false && StarwBerry == false)
        {
            Spider.SetActive(false);
            Frog.SetActive(false);
            Berry.SetActive(false);
            RawDough.SetActive(false);
            Dough.SetActive(true);
            Debug.Log("ġ��Ļ������� ��������ϴ�.");
        }
        else if (SpiderCheese == false && FrogEye == true && StarwBerry == false)
        {
            Spider.SetActive(false);
            Frog.SetActive(false);
            Berry.SetActive(false);
            RawDough.SetActive(false);
            Dough.SetActive(true);
            Debug.Log("���������ɹ����� ��������ϴ�.");
        }
        else if (SpiderCheese == false && FrogEye == false && StarwBerry == true)
        {
            Spider.SetActive(false);
            Frog.SetActive(false);
            Berry.SetActive(false);
            RawDough.SetActive(false);
            Dough.SetActive(true);
            Debug.Log("���� ���ӹ����� ��������ϴ�.");
        }
        else if (SpiderCheese == true && FrogEye == true && StarwBerry == true)
        {
            Spider.SetActive(false);
            Frog.SetActive(false);
            Berry.SetActive(false);
            RawDough.SetActive(true);
            Dough.SetActive(false);
            Debug.Log("�������� �ʴ� �������Դϴ� ���� ����'����'�� �ؼ����ֽʽÿ�.");
        }
        else if (dough == true && SpiderCheese == false && FrogEye == false && StarwBerry == false)
        {
            Debug.Log("��Ḧ �ְ� �������ֽʽÿ�.");
        }


    }

    public void Reset()
    {
        dough = false;
        FrogEye = false;
        SpiderCheese = false;
        StarwBerry = false;
        BDoughnut = false;
        PB = false;
        FC = false;
        CB = false;
        SBD = false;
        SM = false;
        GameManager.instance.curEffect= 0; // ���� ���� �ʱ�ȭ

        RawDough.SetActive(true);
        Spider.SetActive(false);
        Frog.SetActive(false);
        Berry.SetActive(false);
        Dough.SetActive(false);
        FrogPie.SetActive(false);
        PizzaBread.SetActive(false);
        FruitCake.SetActive(false);
        CheeseBread.SetActive(false);
        SBDoughnut.SetActive(false);
        SpiderMuffin.SetActive(false);
        Debug.Log("������ �� �� ȭ");
    }



    /*
     �ڽŰ��� �ִ� ��������ũ (����)3
        ����� �ִ� ġ��Ļ� (�����)4
        ��⸦ �������ִ� ���ڻ� (����)2
        �������� ���� ���� (����)5
        ������ ����.(�Ҿ�)1
        ������ ����������(�г�)6
     
     */
    public void Bake()
    {
        if (dough == true && SpiderCheese == true && FrogEye == true && StarwBerry == false)
        {
            Spider.SetActive(false);
            Berry.SetActive(false);
            Frog.SetActive(false);
            Dough.SetActive(false);

            FrogPie.SetActive(true);

            BDoughnut = true;
            FrogEye = false;
            SpiderCheese = false;
            StarwBerry = false;
            PB = false;
            FC = false;
            CB = false;
            SBD = false;
            SM = false;

            Debug.Log("������ ���������ϴ�.");
            GameManager.instance.currentAnswer = 1;
            UIMananger.instance.ActiveAnswerBasket();
        }
        else if (dough == true && SpiderCheese == true && FrogEye == false && StarwBerry == false)
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

            Debug.Log("ġ��Ļ��� ���������ϴ�.");
            GameManager.instance.currentAnswer = 4;
            UIMananger.instance.ActiveAnswerBasket();
        }
        else if (dough == true && SpiderCheese == true && FrogEye == false && StarwBerry == true)
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

            Debug.Log("���ڻ��� ���������ϴ�.");
            GameManager.instance.currentAnswer = 2;
            UIMananger.instance.ActiveAnswerBasket();
        }
        else if (dough == true && SpiderCheese == false && FrogEye == false && StarwBerry == true)
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

            Debug.Log("���� ������ ���������ϴ�.");
            GameManager.instance.currentAnswer = 5;
            UIMananger.instance.ActiveAnswerBasket();
        }
        else if (dough == true && SpiderCheese == false && FrogEye == true && StarwBerry == true)
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

            Debug.Log("��������ũ�� ���������ϴ�.");
            GameManager.instance.currentAnswer = 3;
            UIMananger.instance.ActiveAnswerBasket();
        }
        else if (dough == true && SpiderCheese == false && FrogEye == true && StarwBerry == false)
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

            Debug.Log("�ﱸ�������� ���������ϴ�.");
            GameManager.instance.currentAnswer = 6;
            UIMananger.instance.ActiveAnswerBasket();
        }
        else if (dough == false)
        {
            Debug.Log("������ ���� ������ּ���.");
        }
      
    }

}