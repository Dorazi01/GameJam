using UnityEngine;

public class NPCspawnmanager : MonoBehaviour
{
    public static NPCspawnmanager instance; // 싱글톤 인스턴스
    // 스폰 위치
    public Transform spawnpos;

    public GameObject npcPrefab; // 생성할 NPC 프리팹
    public float spawnCooldown = 8f; // 생성 쿨타임(초)

    public bool isSpawned = false;

    private void Awake()
    {
        instance = this; // 싱글톤 인스턴스 설정
    }


    void Update()
    {
        spawnCooldown -= Time.deltaTime; // 쿨타임 감소
        if (spawnCooldown <= 0  && !isSpawned)
        {
            SpawnNPC(spawnpos.position);
            isSpawned = true; // NPC가 생성되었음을 표시
        }
    }

    GameObject SpawnNPC(Vector3 spawnPos)
    {
        GameObject npc = Instantiate(npcPrefab, spawnPos, Quaternion.identity);
        return npc;
    }
}