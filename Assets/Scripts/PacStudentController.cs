using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PacStudentController : MonoBehaviour
{
    public float speed = 15f;    // PacStudent �ƶ��ٶ�
    private Vector2 lastInput = Vector2.zero;  // ���һ��������뷽��
    private Vector2 currentInput = Vector2.zero;  // ��ǰ�ƶ�����
    private Vector3 targetPosition;   // ��һ��Ŀ��λ��
    private bool isMoving = false;    // �Ƿ������ƶ�
    private Animator animator;    // ����������
    public AudioClip pelletClip;   // �Զ�����ЧƬ��
    public AudioClip moveClip;     // �ƶ���ЧƬ��
    private AudioSource audioSource; // ��ƵԴ
    public Tilemap wallTilemap;       // ���ڼ��ǽ�� Tilemap

    public float tileSize = 0.32f;

    void Start()
    {
        animator = GetComponent<Animator>();
        targetPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        GetInput();
        if (!isMoving)
        {
            Move();
        }
    }

    void GetInput()
    {
        Vector2 input = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) input = Vector2.up;
        else if (Input.GetKey(KeyCode.S)) input = Vector2.down;
        else if (Input.GetKey(KeyCode.A)) input = Vector2.left;
        else if (Input.GetKey(KeyCode.D)) input = Vector2.right;

        Vector2 gridPosition = GetGridPosition(transform.position);
        if (IsWalkable(gridPosition + input))
        {
            lastInput = input;
        }
        Debug.Log("Last Input: " + lastInput);
    }

    void Move()
    {
        Vector2 gridPosition = GetGridPosition(transform.position);
        if (!isMoving && lastInput != Vector2.zero && IsWalkable(gridPosition + lastInput))
        {
            currentInput = lastInput;
            UpdateAnimator(currentInput); // ���¶�������
            StartCoroutine(MoveTo(gridPosition + currentInput));
        }
    }

    IEnumerator MoveTo(Vector2 targetGridPosition)
    {
        isMoving = true;
        animator.SetBool("IsMoving", true);
        Vector3 startPosition = transform.position;
        targetPosition = GridToWorldPosition(targetGridPosition);

        float elapsedTime = 0f;
        float moveDuration = Vector3.Distance(startPosition, targetPosition) / speed;

        if (audioSource != null && moveClip != null && !audioSource.isPlaying)
        {
            audioSource.clip = moveClip;
            audioSource.Play();
        }

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / moveDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isMoving = false;
        Debug.Log("Reached target position: " + targetGridPosition);

        if (audioSource != null && audioSource.clip == moveClip && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        // ����Ե����ӣ�������Ӧ��Ч
        if (IsPelletPosition(targetGridPosition))
        {
            PlayEatSound();
        }

        Debug.Log("Reached target position: " + targetGridPosition);
    }

    Vector2 GetGridPosition(Vector3 worldPosition)
    {
        Vector3 offsetPosition = worldPosition - wallTilemap.transform.position;
        int x = Mathf.RoundToInt(offsetPosition.x / tileSize);
        int y = Mathf.RoundToInt(offsetPosition.y / tileSize);
        Debug.Log("Grid Position calculated: (" + x + ", " + y + ")");
        return new Vector2(x, y);
    }

    Vector3 GridToWorldPosition(Vector2 gridPosition)
    {
        Vector3 worldPosition = new Vector3(gridPosition.x * tileSize, gridPosition.y * tileSize, 0f);
        worldPosition += wallTilemap.transform.position;
        Debug.Log("World Position calculated from Grid: " + worldPosition);
        return worldPosition;
    }

    bool IsWalkable(Vector2 targetGridPosition)
    {
        Vector3Int tilePosition = new Vector3Int((int)targetGridPosition.x, (int)targetGridPosition.y, 0);
        TileBase wallTile = wallTilemap.GetTile(tilePosition);

        // ���Ŀ��λ�ô���ǽ��Ƭ���򲻿�����
        if (wallTile != null)
        {
            Debug.Log("Tile at (" + tilePosition.x + ", " + tilePosition.y + ") is a wall: not walkable.");
            return false;
        }

        return true; // �����ǿ����ߵ�
    }

    bool IsPelletPosition(Vector2 gridPosition)
    {
        Vector3Int tilePosition = new Vector3Int((int)gridPosition.x, (int)gridPosition.y, 0);
        TileBase tile = wallTilemap.GetTile(tilePosition);

        if (tile != null && tile.name == "Pellet") // ���� "Pellet" ��ʾ������Ƭ
        {
            wallTilemap.SetTile(tilePosition, null);  // �Ե����Ӻ����Ƴ�
            return true;
        }
        return false;
    }

    void PlayEatSound()
    {
        if (audioSource != null && pelletClip != null)
        {
            audioSource.PlayOneShot(pelletClip);
        }
    }

    void UpdateAnimator(Vector2 direction)
    {
        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);
        animator.SetBool("IsMoving", direction != Vector2.zero);
    }
}