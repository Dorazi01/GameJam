using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    private void Awake()
    {
        Invoke("DestroyNPC", 40f);
    }
    void DestroyNPC()
    {
        NPCspawnmanager.instance.isSpawned = false; // NPC�� ���ŵǾ����� ǥ��
        NPCspawnmanager.instance.spawnCooldown = 5f; // ��Ÿ�� �ʱ�ȭ
        Destroy(gameObject);
    }
}
