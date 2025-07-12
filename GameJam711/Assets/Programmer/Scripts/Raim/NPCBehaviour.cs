using Mono.Cecil.Cil;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class NPCBehaviour : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // ��������Ʈ ������ ������Ʈ

    public static NPCBehaviour instance; // �̱��� �ν��Ͻ�

    public Sprite currentSprite;

    public List<Sprite> normalsprites; // NPC�� ���� �� �ִ� ��������Ʈ ���

    public List<Sprite> wrongSprites; // ������ �� ����� ��������Ʈ ���

    public List<Sprite> correctSprites; // ������ �� ����� ��������Ʈ ���



    public float lifeTime = 40f; // NPC�� ���� �ð� (�� ����)
    public float curTime = 0f; // ���� �ð�

    private void Awake()
    {
        instance = this;
        Invoke("DestroyNPC", lifeTime);
        UIMananger.instance.ActiveDialogText(); // ��ȭâ Ȱ��ȭ


        UIMananger.instance.ShowRandomDialog(GameManager.instance.npcLevel);

        


    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer ������Ʈ�� �����ϴ�.");
            return;
        }
    }
    private void Update()
    {
        if (curTime < lifeTime)
        {
            curTime += Time.deltaTime; // ���� �ð� ������Ʈ


            ReSprite();

        }


        

    }

    public void DestroyNPC()
    {
        UIMananger.instance.NpcPrefab = null;
        NPCspawnmanager.instance.isSpawned = false; // NPC�� ���ŵǾ����� ǥ��
        NPCspawnmanager.instance.spawnCooldown = 5f; // ��Ÿ�� �ʱ�ȭ
        Destroy(gameObject);
        UIMananger.instance.UnActiveDialogText(); // ��ȭâ ��Ȱ��ȭ
    }

    int curSprNum = 0;
    private void ReSprite()
    {
        if (spriteRenderer && curSprNum != UIMananger.instance.NpcsprNum)
        {
            curSprNum = UIMananger.instance.NpcsprNum; // ���� ��������Ʈ ��ȣ ��������
            //Debug.Log("��������Ʈ �������� �����մϴ�.");
            spriteRenderer.sprite = normalsprites[UIMananger.instance.NpcsprNum];
        }
    }
}
