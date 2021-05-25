
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLBASE
{
    /// <summary>
    /// ��Ƶ������
    /// </summary>
    public class AudioSys : SysBase
    {
        private AudioSource audioSources;
        private string Mute = "Mute";

        /// <summary>
        /// ������Ƶ
        /// </summary>
        /// <param name="name"></param>
        public void PlayAudio(string name)
        {
            if (Mutes)
            {
                return;
            }
            GameObject go = new GameObject();
            go.name = "Music:" + name;
            AudioSource audioSource = go.AddComponent<AudioSource>();
            AudioClip audioClip = Resources.Load("Audio/" + name) as AudioClip;
            audioSource.clip = audioClip;
            audioSource.Play();
            float length = audioClip.length;
            SysManager.ObjectBase.StartCoroutine(GameUtlis.Wait(length, () =>
            {
                Object.Destroy(go);
            }));
        }

        /// <summary>
        /// ����ָ����Ƶ
        /// </summary>
        /// <param name="audioClip"></param>
        public void PlayAudio(AudioClip audioClip)
        {
            if (Mutes)
            {
                return;
            }
            GameObject go = new GameObject();
            go.name = "Music:" + audioClip.name;
            AudioSource audioSource = go.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.Play();
            float length = audioClip.length;
            SysManager.ObjectBase.StartCoroutine(GameUtlis.Wait(length, () =>
            {
                Object.Destroy(go);
            }));
        }

        /// <summary>
        /// ����ָ��������Ƶ
        /// </summary>
        /// <param name="name"></param>
        public void PlayBGAudio(string name)
        {
            if (Mutes)
            {
                return;
            }
            GameObject go = new GameObject();
            AudioSource audioSource = go.AddComponent<AudioSource>();
            AudioClip audioClip = Resources.Load("Audio/" + name) as AudioClip;
            audioSource.clip = audioClip;
            audioSource.loop = true;
            audioSource.Play();
            go.name = "Audio:" + name;
            audioSources = audioSource;
        }

        /// <summary>
        /// �ر���������
        /// </summary>
        public void CloseAudio()
        {
            if (audioSources != null)
                audioSources.Pause();
        }

        /// <summary>
        /// ����������
        /// </summary>
        public void OpenAudio()
        {
            if (audioSources != null)
                audioSources.Play();
        }

        /// <summary>
        /// ���þ���״̬
        /// </summary>
        /// <param name="mute"></param>
        public void SetMute(bool mute)
        {
            Mutes = mute;
            if (Mutes)
            {
                CloseAudio();
            }
            else
            {
                OpenAudio();
            }
        }

        /// <summary>
        /// �洢����״̬
        /// </summary>
        public bool Mutes;
        //{
        //    get
        //    {
        //        //int index = PlayerPrefs.GetInt(Mute);
        //        //bool slot = false;
        //        //if (index == 1)
        //        //{
        //        //    slot = true;
        //        //}
        //        //else
        //        //{
        //        //    slot = false;
        //        //}
        //        return slot;
        //    }
        //    set
        //    {
        //        //bool slot = value;
        //        //int index = 0;
        //        //if (slot)
        //        //{
        //        //    index = 1;
        //        //}
        //        //else
        //        //{
        //        //    index = 0;
        //        //}
        //        PlayerPrefs.SetInt(Mute, index);
        //    }
        //}
    }
}