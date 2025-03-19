using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    Vector2 movement = new Vector2(0,0);
    float speed = 10f;
    [SerializeField] DeathHandler deathHandler;
    [SerializeField] ScoreHandler scoreHandler;
    [SerializeField] Animator animator;
    [SerializeField] AudioClip coinCollectAudioClip;
    [SerializeField] Camera camera;
    [SerializeField] ParticleSystem MuzzleFlash;
    bool isdead = false;

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();    
    }

    private void FixedUpdate()
    {
        transform.Translate(movement * Time.deltaTime * speed);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), 0.5f , transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isdead) return;
        if(other.gameObject.tag == "Obstacle")
        {
            MuzzleFlash.Play();
            Destroy(other.gameObject);
            deathHandler.Lives--;
        }
        if(other.gameObject.tag == "coin")
        {
            AudioSource.PlayClipAtPoint(coinCollectAudioClip,camera.transform.position,1f);
            scoreHandler.score++;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Fence")
        {
            GetComponent<AudioSource>().Play();
            animator.SetTrigger("Hit");
            deathHandler.Lives--;
        }
        if (deathHandler.Lives <= 0)
        {
            isdead = true;
            ShowDeathCanvas();
            Time.timeScale = 0.5f;
        }
    }

    private void ShowDeathCanvas()
    {
        canvas.SetActive(true);  
    }
}
