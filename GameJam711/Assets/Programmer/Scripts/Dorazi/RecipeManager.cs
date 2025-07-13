using System.Collections;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager instance; // 싱글톤 인스턴스
    //도마 매니저 (재료통 버튼 클릭시) / (재료 불 변수 On)  / 열등, 무기력, 좌절, 공포, 분노, 불안
    /*
        자신감을 주는 과일케이크 (공포)
        희망을 주는 치즈식빵 (무기력)
        용기를 복돋아주는 피자빵 (좌절)
        자존감의 딸기 도넛 (열등)
        안정의 도넛.(불안)
        진정의 거미머핀(분노)

        
        거미치즈 + 산딸기 = 피자빵
        거미치즈 + 개구리알 = 도넛
        개구리알 + 산딸기 = 과일케이크 
        거미치즈 = 치즈식빵
        산딸기 = 딸기 도넛
        개구리알 = 개구리알 머핀
     */

    //이거 어제도 말했었던건데 음식 자체에 속성(공포)을 넣는게 아니라 원하는거 만들어 주고, 거기에 후첨가로 라벤더 이런걸 넣으면 된다 생각함
    //문제가 이렇게하면 6X6이라 36인데, 속성 칸을 따로 하나로 만들어서, 음식에 속성을 넣는게 아니라, 음식은 음식대로 만들고, 속성은 속성대로 넣는게 좋을듯
    //결론 : 여기다 빈 정보 칸 하나 만들고, 그거 맞는지에 따라 파악하면될듯

    //너가 해줘야 할 것 : 대사 정하긴데, 존나늘었음 수고



    

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
    public GameObject RawDough; // 반죽 상태를 나타내는 변수
    public GameObject BakeDough; // 오븐 트레이 위 반죽



    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }
    }

    public void SC()
    {
        if (Spider.activeSelf)
        {
            Debug.Log("이미 재료로 사용중입니다.");
            return;
        }
        if (Dough.activeSelf)
        {
            Debug.Log("이미 반죽이 완성 되었습니다.");
            return;
        }
        if (FrogPie.activeSelf || PizzaBread.activeSelf || FruitCake.activeSelf || CheeseBread.activeSelf || SBDoughnut.activeSelf || SpiderMuffin.activeSelf)
        {
            Debug.Log("이미 빵을 구우셨습니다.");
            return;
        }
        SpiderCheese = true;
        Debug.Log("거미치즈를 재료로 사용했습니다.");
        Spider.SetActive(true);
    }


    public void FE()
    {

        if (Frog.activeSelf)
        {
            Debug.Log("이미 재료로 사용중입니다.");
            return;
        }
        if (Dough.activeSelf)
        {
            Debug.Log("이미 반죽이 완성 되었습니다.");
            return;
        }
        if (FrogPie.activeSelf || PizzaBread.activeSelf || FruitCake.activeSelf || CheeseBread.activeSelf || SBDoughnut.activeSelf || SpiderMuffin.activeSelf)
        {
            Debug.Log("이미 빵을 구우셨습니다.");
            return;
        }
        FrogEye = true;
        Debug.Log("개구리눈을 재료로 사용했습니다.");
        Frog.SetActive(true);
    }

    public void SB()
    {
        if (Berry.activeSelf)
        {
            Debug.Log("이미 재료로 사용중입니다.");
            return;
        }
        if (Dough.activeSelf)
        {
            Debug.Log("이미 반죽이 완성 되었습니다.");
            return;
        }
        if (FrogPie.activeSelf || PizzaBread.activeSelf || FruitCake.activeSelf || CheeseBread.activeSelf || SBDoughnut.activeSelf || SpiderMuffin.activeSelf)
        {
            Debug.Log("이미 빵을 구우셨습니다.");
            return;
        }

        StarwBerry = true;
        Debug.Log("엘프숲의 딸기를 재료로 사용했습니다.");
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

            Debug.Log("도넛반죽을 만들었습니다.");
        }
        else if (SpiderCheese == false && FrogEye == true && StarwBerry == true)
        {
            Spider.SetActive(false);
            Berry.SetActive(false);
            Frog.SetActive(false);
            RawDough.SetActive(false);
            Dough.SetActive(true);

            Debug.Log("과일케이크 반죽을 만들었습니다.");
        }
        else if (SpiderCheese == true && FrogEye == false && StarwBerry == true)
        {
            Spider.SetActive(false);
            Berry.SetActive(false);
            Frog.SetActive(false);
            RawDough.SetActive(false);
            Dough.SetActive(true);


            Debug.Log(" 피자빵 반죽을 만들었습니다.");
        }
        else if (SpiderCheese == true && FrogEye == false && StarwBerry == false)
        {
            Spider.SetActive(false);
            Frog.SetActive(false);
            Berry.SetActive(false);
            RawDough.SetActive(false);
            Dough.SetActive(true);
            Debug.Log("치즈식빵반죽을 만들었습니다.");
        }
        else if (SpiderCheese == false && FrogEye == true && StarwBerry == false)
        {
            Spider.SetActive(false);
            Frog.SetActive(false);
            Berry.SetActive(false);
            RawDough.SetActive(false);
            Dough.SetActive(true);
            Debug.Log("개구리머핀반죽을 만들었습니다.");
        }
        else if (SpiderCheese == false && FrogEye == false && StarwBerry == true)
        {
            Spider.SetActive(false);
            Frog.SetActive(false);
            Berry.SetActive(false);
            RawDough.SetActive(false);
            Dough.SetActive(true);
            Debug.Log("딸기 도넛반죽을 만들었습니다.");
        }
        else if (SpiderCheese == true && FrogEye == true && StarwBerry == true)
        {
            Spider.SetActive(false);
            Frog.SetActive(false);
            Berry.SetActive(false);
            RawDough.SetActive(true);
            Dough.SetActive(false);
            Debug.Log("존재하지 않는 제조법입니다 제발 제조'법규'를 준수해주십시오.");
        }
        else if (dough == true && SpiderCheese == false && FrogEye == false && StarwBerry == false)
        {
            Debug.Log("재료를 넣고 반죽해주십시오.");
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
        GameManager.instance.curEffect= 0; // 현재 정답 초기화

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
        BakeDough.SetActive(false); // 추가됨
        Debug.Log("도마의 정 상 화");
    }



    /*
     자신감을 주는 과일케이크 (공포)3
        희망을 주는 치즈식빵 (무기력)4
        용기를 복돋아주는 피자빵 (좌절)2
        자존감의 딸기 도넛 (열등)5
        안정의 도넛.(불안)1
        진정의 개구리머핀(분노)6
     
     */
    public void Bake()
    {
        if (!dough)
        {
            Debug.Log("반죽을 먼저 만들어주세요.");
            return;
        }

        // 공통: 재료 비활성화 + 반죽 비활성화 + 굽는 비주얼 활성화
        Spider.SetActive(false);
        Berry.SetActive(false);
        Frog.SetActive(false);
        Dough.SetActive(false);
        BakeDough.SetActive(true);

        // 어떤 빵을 굽는지 분기
        if (SpiderCheese && FrogEye && !StarwBerry)
        {
            StartCoroutine(FinishBake(FrogPie, 1, "도넛이 구워졌습니다."));
            BDoughnut = true;
        }
        else if (SpiderCheese && !FrogEye && !StarwBerry)
        {
            StartCoroutine(FinishBake(CheeseBread, 4, "치즈식빵이 구워졌습니다."));
            CB = true;
        }
        else if (SpiderCheese && !FrogEye && StarwBerry)
        {
            StartCoroutine(FinishBake(PizzaBread, 2, "피자빵이 구워졌습니다."));
            PB = true;
        }
        else if (!SpiderCheese && FrogEye && StarwBerry)
        {
            StartCoroutine(FinishBake(FruitCake, 3, "과일케이크가 구워졌습니다."));
            FC = true;
        }
        else if (!SpiderCheese && !FrogEye && StarwBerry)
        {
            StartCoroutine(FinishBake(SBDoughnut, 5, "딸기 도넛이 구워졌습니다."));
            SBD = true;
        }
        else if (!SpiderCheese && FrogEye && !StarwBerry)
        {
            StartCoroutine(FinishBake(SpiderMuffin, 6, "깍구리머핀이 구워졌습니다."));
            SM = true;
        }
        else
        {
            Debug.Log("올바르지 않은 재료 조합입니다.");
            BakeDough.SetActive(false);
        }
    }

    private IEnumerator FinishBake(GameObject bakedGood, int answerCode, string message)
    {
        yield return new WaitForSeconds(3f);

        BakeDough.SetActive(false);
        bakedGood.SetActive(true);


        // 정답 코드 설정 및 UI 호출
        GameManager.instance.currentAnswer = answerCode;
        UIMananger.instance.ActiveAnswerBasket();
        Debug.Log(message);

        // 상태 초기화
        dough = false;
        SpiderCheese = false;
        FrogEye = false;
        StarwBerry = false;

        BDoughnut = false;
        PB = false;
        FC = false;
        CB = false;
        SBD = false;
        SM = false;
    }


}