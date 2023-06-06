using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structs : MonoBehaviour
{
    public struct Enemy
    {
        public string name;
        public GameObject gameObject;
        public float enemyDamage;
        public float colliderDistance;
    }
}
