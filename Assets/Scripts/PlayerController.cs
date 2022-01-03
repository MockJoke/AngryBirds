using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private Rigidbody2D hookRB;

    [SerializeField] private bool isPressed = false;

    [SerializeField] private float releaseTime = 0.1f;
    [SerializeField] private float maxDragDistance = 3f; 

    void Start()
    { 
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(Vector3.Distance(mousePos, hookRB.position) > maxDragDistance)
            {
                playerRB.position = hookRB.position + (mousePos - hookRB.position).normalized * maxDragDistance; 
            }
            else
            {
                playerRB.position = mousePos;
            }            
        }
    }

    private void OnMouseDown()
    {
        //Debug.Log("Key Pressed"); 
        isPressed = true; 
        playerRB.isKinematic = true;
    }

    private void OnMouseUp()
    {
        //Debug.Log("Key Released");
        isPressed = false; 
        playerRB.isKinematic = false;

        StartCoroutine(releasePlayer()); 
    }

    IEnumerator releasePlayer()
    {
        yield return new WaitForSeconds(releaseTime); 

        GetComponent<SpringJoint2D>().enabled = false;

        this.enabled = false; 
    }
} 
