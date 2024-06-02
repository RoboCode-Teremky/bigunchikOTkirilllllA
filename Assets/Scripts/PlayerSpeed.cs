using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeed : MonoBehaviour
{
  [SerializeField] private float speed = 1.0f;
  void Update()
  {
    transform.Translate(Vector3.right*speed*Time.deltaTime);
  }
}
