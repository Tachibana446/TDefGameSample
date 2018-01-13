using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 斬撃アニメーションをON・OFFする
/// </summary>
public class SlashEffect : MonoBehaviour
{

    public bool isPlaying { get; private set; }
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        isPlaying = false;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer.enabled = false;
        animator.Stop();
    }

    public void Play()
    {
        isPlaying = true;
        spriteRenderer.enabled = true;
        animator.Play("a", 0, 0f);
    }

    public void Stop()
    {
        isPlaying = false;
        spriteRenderer.enabled = false;
        animator.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
