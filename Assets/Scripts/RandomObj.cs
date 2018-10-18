using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboyWalk
{
    public class RandomObj : MonoBehaviour
    {

        private void Update()
        {
            if (transform.position.y < -5)
            {
                Destroy(gameObject);
            }
        }
    }
}