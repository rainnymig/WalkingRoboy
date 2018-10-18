using PhysicsAPI;
using System;
using UnityEngine;

namespace RoboyWalk
{
    public class AvatarWalk : MonoBehaviour
    {

        public float m_desiredHeading;
        public float m_velocity = 1f;
        public float m_sideVelocity = 0f;

        public float m_acceleration = 1.0f;
        public float m_maxSteering = 1.0f;
        public float m_maxStrafingAccel = 0.3f;
        public float m_maxStrafingVelocity = 2.5f;
        public float m_maxVelocity = 1.75f;
        public float m_minVelocity = -1.0f;
        public float m_strafeDistanceSqr = 100.0f;
        public float m_horizontal = 0;
        public float m_vertical = 0;

        private IntPtr m_engineController;
        protected tntHumanoidController m_controller;

        protected tntBase m_rootTntBase;
        protected Transform m_rootTrans;

        private Vector3 m_LastPosition;
        private int m_SampleCount = 0;

        private float m_ResetThresholdLow = 0.1f;
        private float m_ResetThresholdHigh = 2f;

        void Awake()
        {
            m_controller = GetComponentInChildren<tntHumanoidController>();
            m_rootTrans = m_controller.transform.parent;
            m_rootTntBase = m_rootTrans.GetComponent<tntBase>();
        }


        // Use this for initialization
        void Start()
        {
            m_engineController = m_controller.GetEngineController();
            if (m_engineController != IntPtr.Zero)
            {
                m_desiredHeading = TNT.acGetDesiredHeading(m_engineController);
            }

            m_controller.UpdateHeading(m_desiredHeading);
            m_controller.UpdateVelocity(m_velocity, m_sideVelocity, 0);
        }

        // Update is called once per frame
        void Update()
        {
            m_controller.UpdateVelocity(m_velocity, m_sideVelocity, 0);
        }

        private void FixedUpdate()
        {
            ++m_SampleCount;
            if(m_SampleCount == 60)
            {
                Vector3 currentPosition = m_rootTrans.position;
                if (m_LastPosition != null)
                {
                    Vector3 pd = currentPosition - m_LastPosition;
                    if (pd.magnitude < m_ResetThresholdLow)
                    {
                        GroundsManager.Instance.ResetScene();
                    }
                    else if (pd.magnitude > m_ResetThresholdHigh)
                    {
                        GroundsManager.Instance.ResetScene();
                    }
                }
                m_LastPosition = m_rootTrans.position;
                m_SampleCount = 0;
            }
        }
    }
}
