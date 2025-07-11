using Mono.Cecil.Cil;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class NPCBehaviour : MonoBehaviour
{
    public Sprite sptriter;
    private void Awake()
    {
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

    void DestroyNPC()
    {
        NPCspawnmanager.instance.isSpawned = false; // NPC�� ���ŵǾ����� ǥ��
        NPCspawnmanager.instance.spawnCooldown = 5f; // ��Ÿ�� �ʱ�ȭ
        Destroy(gameObject);
        UIMananger.instance.UnActiveDialogText(); // ��ȭâ ��Ȱ��ȭ
    }


    private void Update()
    {
        if (GameManager.instance.isCorrectAnswer)
        {

        }
    }




}
