using Mono.Cecil.Cil;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class NPCBehaviour : MonoBehaviour
{
    public static NPCBehaviour instance; // 싱글톤 인스턴스
    public Sprite sptriter;

    float lifeTime = 40f; // NPC의 생존 시간 (초 단위)
    public float curTime = 0f; // 현재 시간

    private void Awake()
    {
        
        instance = this;
        Invoke("DestroyNPC", 40f);
        UIMananger.instance.ActiveDialogText(); // 대화창 활성화


        UIMananger.instance.ShowRandomDialog(GameManager.instance.npcLevel);
    }

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.sprite = sprite;
        spriteRenderer.sortingOrder = 1;
    }

    public void DestroyNPC()
    {
        UIMananger.instance.NpcPrefab = null;
        NPCspawnmanager.instance.isSpawned = false; // NPC가 제거되었음을 표시
        NPCspawnmanager.instance.spawnCooldown = 5f; // 쿨타임 초기화
        Destroy(gameObject);
        UIMananger.instance.UnActiveDialogText(); // 대화창 비활성화
    }


    private void Update()
    {
        if (curTime < lifeTime)
        {
            curTime += Time.deltaTime; // 현재 시간 업데이트
            
        }


        if (GameManager.instance.isCorrectAnswer)
        {
           //애니메이션 넣을 자리
        }

    }




}
