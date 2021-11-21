using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MobileTouchEffectPack
{
    public class Touch : MonoBehaviour
    {
        public static Touch instance;
        #region Singleton
        private void Awake()
        {
            if (instance == null)
            {
                NewMethod();
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }

            void NewMethod()
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        #endregion Singleton

        public Transform particle_transform;
        public ParticleSystem particle_particle;
        public bool dragPlayMode;
        Vector3 pos_particle;


        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {

                MoveParticlePosition();
                particle_particle.Play();

            }

            if (dragPlayMode)
            {
                if (Input.GetMouseButton(0))
                {

                    MoveParticlePosition();
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                particle_particle.Stop();
            }
        }


        void MoveParticlePosition()
        {
            pos_particle = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos_particle.z = -5f;

            particle_transform.localPosition = pos_particle;
        }


    }
}