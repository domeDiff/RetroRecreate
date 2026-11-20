using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SSSGameManager : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private Transform snakeSegmentPrefab;
    [SerializeField] private Transform snackPrefab;

    [Header("Properties")]
    [SerializeField] private int width = 21;
    [SerializeField] private int height = 21;
    [SerializeField] private float moveInterval = 0.12f;

    // Grid bounds, centered on (0, 0)
    int MinX => -(width / 2);
    int MaxX => MinX + width - 1;
    int MinY => -(height / 2);
    int MaxY => MinY + height - 1;

    private List<Transform> segments = new List<Transform>();
    private Vector2Int direction = Vector2Int.right; //direction that was last moved
    private Vector2Int queuedDirection = Vector2Int.right; //direction player wants to move next
    private float timer;

    private void Start()
    {
        ResetGame();
    }

    private void Update()
    {
        ReadInput();

        timer += Time.deltaTime;
        if(timer >= moveInterval)
        {
            timer -= moveInterval;
            Step();
        }
    }

    private void ReadInput()
    {
        Keyboard kb = Keyboard.current;

        if (kb == null) return;

        if ((kb.wKey.wasPressedThisFrame || kb.upArrowKey.wasPressedThisFrame) && direction != Vector2Int.down) //compare against direction so that you cant move into yourself
            queuedDirection = Vector2Int.up;
        else if ((kb.sKey.wasPressedThisFrame || kb.downArrowKey.wasPressedThisFrame) && direction != Vector2Int.up)
            queuedDirection = Vector2Int.down;
        else if ((kb.aKey.wasPressedThisFrame || kb.leftArrowKey.wasPressedThisFrame) && direction != Vector2Int.right)
            queuedDirection = Vector2Int.left;
        else if ((kb.dKey.wasPressedThisFrame || kb.rightArrowKey.wasPressedThisFrame) && direction != Vector2Int.left)
            queuedDirection = Vector2Int.right;
    }

    private void Step()
    {
        direction = queuedDirection;
        Vector2Int newHead = GridPos(segments[0]) + direction;

        if(newHead.x < MinX || newHead.x > MaxX || newHead.y < MinY || newHead.y > MaxY)
        {
            ResetGame();
            return;
        }

        bool eating = newHead == GridPos(snackPrefab);

        for (int i = 0; i < segments.Count; i++)
        {
            if (!eating && i == segments.Count - 1) continue;
            if (GridPos(segments[i]) == newHead)
            {
                ResetGame();
                return;
            }
        }

        Vector3 oldTail = segments[segments.Count - 1].position;

        for (int i = segments.Count - 1; i > 0; i--)
            segments[i].position = segments[i - 1].position;

        segments[0].position = new Vector3(newHead.x, newHead.y, 0);

        if (eating)
        {
            Transform seg = Instantiate(snakeSegmentPrefab, oldTail, Quaternion.identity);
            segments.Add(seg);
            MoveFood();
        }
    }

    private void ResetGame()
    {
        foreach (Transform s in segments) Destroy(s.gameObject);

        segments.Clear();

        direction = Vector2Int.right;
        queuedDirection = Vector2Int.right;
        timer = 0f;

        Transform head = Instantiate(snakeSegmentPrefab, Vector3.zero,  Quaternion.identity);
        segments.Add(head);

        MoveFood();
    }

    private void MoveFood()
    {
        Vector2Int pos;
        do
        {
            pos = new Vector2Int(Random.Range(-17, 17), Random.Range(-9, 9));
        } while (IsOnSnake(pos));

        snackPrefab.position = new Vector3(pos.x, pos.y, 0);
    }

    private bool IsOnSnake(Vector2Int pos)
    {
        foreach (Transform s in segments)
            if (GridPos(s) == pos) return true;
        return false;
    }

    Vector2Int GridPos(Transform t)
    {
        return new Vector2Int(Mathf.RoundToInt(t.position.x), Mathf.RoundToInt(t.position.y));
    }
}
