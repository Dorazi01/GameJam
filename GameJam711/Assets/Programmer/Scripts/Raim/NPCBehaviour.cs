using Mono.Cecil.Cil;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class NPCBehaviour : MonoBehaviour
{
    public static NPCBehaviour instance; // �̱��� �ν��Ͻ�
    public Sprite sptriter;

    float lifeTime = 40f; // NPC�� ���� �ð� (�� ����)
    public float curTime = 0f; // ���� �ð�

    private void Awake()
    {
        
        instance = this;
        Invoke("DestroyNPC", 40f);
        UIMananger.instance.ActiveDialogText(); // ��ȭâ Ȱ��ȭ


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
        NPCspawnmanager.instance.isSpawned = false; // NPC�� ���ŵǾ����� ǥ��
        NPCspawnmanager.instance.spawnCooldown = 5f; // ��Ÿ�� �ʱ�ȭ
        Destroy(gameObject);
        UIMananger.instance.UnActiveDialogText(); // ��ȭâ ��Ȱ��ȭ
    }


    private void Update()
    {
        if (curTime < lifeTime)
        {
            curTime += Time.deltaTime; // ���� �ð� ������Ʈ
            
        }


        if (GameManager.instance.isCorrectAnswer)
        {
           //�ִϸ��̼� ���� �ڸ�
        }

    }




}
