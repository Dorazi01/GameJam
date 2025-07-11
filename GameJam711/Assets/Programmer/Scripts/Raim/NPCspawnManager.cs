using UnityEngine;

public class NPCspawnmanager : MonoBehaviour
{
    public static NPCspawnmanager instance; // �̱��� �ν��Ͻ�
    // ���� ��ġ
    public Transform spawnpos;

    public GameObject npcPrefab; // ������ NPC ������
    public float spawnCooldown = 8f; // ���� ��Ÿ��(��)

    public bool isSpawned = false;

    private void Awake()
    {
        instance = this; // �̱��� �ν��Ͻ� ����
    }


    void Update()
    {
        spawnCooldown -= Time.deltaTime; // ��Ÿ�� ����
        if (spawnCooldown <= 0  && !isSpawned)
        {
            SpawnNPC(spawnpos.position);
            isSpawned = true; // NPC�� �����Ǿ����� ǥ��
        }
    }

    GameObject SpawnNPC(Vector3 spawnPos)
    {
        GameObject npc = Instantiate(npcPrefab, spawnPos, Quaternion.identity);
        return npc;
    }
}