using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboyWalk
{
    public class CameraController : MonoBehaviour
    {
        public Vector3 RotateRate;

        private GameObject m_Roboy;

        private void Start()
        {
            if(RotateRate == null)
            {
                RotateRate = new Vector3(0f, -10f, 0f);
            }
        }

        void Update()
        {
            if (m_Roboy == null)
            {
                m_Roboy = GameObject.FindGameObjectWithTag("Roboy");
            }

            if (m_Roboy != null)
            {
                transform.position = new Vector3(m_Roboy.transform.position.x, 0, m_Roboy.transform.position.z);
                transform.Rotate(RotateRate * Time.fixedDeltaTime);
            }
        }

        public void ClearRoboy ()
        {
            m_Roboy = null;
        }
    }

}
