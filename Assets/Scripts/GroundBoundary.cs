using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RoboyWalk
{
    public class GroundBoundary : MonoBehaviour
    {

        private string m_DesiredTag = "Avatar";
        [SerializeField]
        private GroundUnitManager m_Manager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == m_DesiredTag)
            {
                m_Manager.MakeNewGround(gameObject.tag);
            }
        }

    }
}

