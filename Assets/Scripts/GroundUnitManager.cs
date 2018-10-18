using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboyWalk
{
    public class GroundUnitManager : MonoBehaviour
    {

        public enum GroundPosition
        {
            front,
            back,
            left,
            right
        }
        
        [SerializeField]
        private GameObject m_CubePrefab;

        private GameObject m_FrontGround;
        private GameObject m_BackGround;
        private GameObject m_LeftGround;
        private GameObject m_RightGround;

        private GameObject m_GroundsParent;

        private tntRigidBody m_TntRigidBody;

        private float m_Length;
        private float m_Width;

        private void Start()
        {
            m_GroundsParent = GameObject.FindGameObjectWithTag("GroundsParent");
            m_Length = transform.lossyScale.z;
            m_Width = transform.lossyScale.x;
            m_TntRigidBody = GetComponent<tntRigidBody>();
            
            generateCubes();
        }

        public void MakeNewGround(string boundaryTag)
        {
            switch (boundaryTag)
            {
                case "BoundaryFront":
                    if(m_FrontGround == null)
                    {
                        m_FrontGround = GroundsManager.Instance.MakeNewGround();
                        m_FrontGround.transform.position = transform.position + new Vector3(0f, 0f, m_Length);
                        m_FrontGround.GetComponent<GroundUnitManager>().SetGround(gameObject, GroundPosition.back);
                        Destroy(m_BackGround);
                        m_BackGround = null;
                    }
                    break;

                case "BoundaryBack":
                    break;

                case "BoundaryLeft":
                    break;

                case "BoundaryRight":
                    break;

                default: break;
            }
        }

        public void SetGround(GameObject ground, GroundPosition pos)
        {
            switch (pos)
            {
                case GroundPosition.front:
                    m_FrontGround = ground;
                    break;

                case GroundPosition.back:
                    m_BackGround = ground;
                    break;

                case GroundPosition.left:
                    m_LeftGround = ground;
                    break;

                case GroundPosition.right:
                    m_RightGround = ground;
                    break;

                default: break;
            }
        }

        private void generateCubes()
        {
            if(m_CubePrefab != null)
            {
                int cubeCount = Random.Range(10, 14);
                for (int i = 0; i < cubeCount; i++)
                {
                    GameObject go = Instantiate(m_CubePrefab);

                    go.transform.localScale = new Vector3(Random.Range(0.3f, 1f),
                                                            Random.Range(0.3f, 1f),
                                                            Random.Range(0.3f, 1f));

                    go.transform.position = transform.position + new Vector3(Random.Range(-m_Width / 2, m_Width / 2), 2f,
                        Random.Range(-m_Length / 2, m_Length / 2));

                    go.transform.rotation = Random.rotation;
                    
                }
            }
            
        }
        
    }
}
