using Mono.Cecil.Cil;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class NPCBehaviour : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // 스프라이트 렌더러 컴포넌트

    public static NPCBehaviour instance; // 싱글톤 인스턴스

    public Sprite currentSprite;

    public List<Sprite> normalsprites; // NPC가 가질 수 있는 스프라이트 목록

    public List<Sprite> wrongSprites; // 정답일 때 사용할 스프라이트 목록

    public List<Sprite> correctSprites; // 오답일 때 사용할 스프라이트 목록



    public float lifeTime = 40f; // NPC의 생존 시간 (초 단위)
    public float curTime = 0f; // 현재 시간

    private void Awake()
    {
        instance = this;
        Invoke("DestroyNPC", lifeTime);
        UIMananger.instance.ActiveDialogText(); // 대화창 활성화


        UIMananger.instance.ShowRandomDialog(GameManager.instance.npcLevel);

        


    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer 컴포넌트가 없습니다.");
            return;
        }
    }
    private void Update()
    {
        if (curTime < lifeTime)
        {
            curTime += Time.deltaTime; // 현재 시간 업데이트


            ReSprite();

        }


        

    }

    public void DestroyNPC()
    {
        UIMananger.instance.NpcPrefab = null;
        NPCspawnmanager.instance.isSpawned = false; // NPC가 제거되었음을 표시
        NPCspawnmanager.instance.spawnCooldown = 5f; // 쿨타임 초기화
        Destroy(gameObject);
        UIMananger.instance.UnActiveDialogText(); // 대화창 비활성화
    }

    int curSprNum = 0;
    private void ReSprite()
    {
        if (spriteRenderer && curSprNum != UIMananger.instance.NpcsprNum)
        {
            curSprNum = UIMananger.instance.NpcsprNum; // 현재 스프라이트 번호 가져오기
            //Debug.Log("스프라이트 렌더러가 존재합니다.");
            spriteRenderer.sprite = normalsprites[UIMananger.instance.NpcsprNum];
        }
    }
}
