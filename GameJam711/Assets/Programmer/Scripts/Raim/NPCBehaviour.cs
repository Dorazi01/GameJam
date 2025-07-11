using Mono.Cecil.Cil;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{

    private void Awake()
    {
        Invoke("DestroyNPC", 40f);
        UIMananger.instance.ActiveDialogText(); // ��ȭâ Ȱ��ȭ


        UIMananger.instance.ShowRandomDialog(GameManager.instance.npcLevel);
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
