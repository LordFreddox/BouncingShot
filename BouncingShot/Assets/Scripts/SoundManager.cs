using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip win, fail, tik;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator PlayWin()
    {
        source.clip = win;
        yield return new WaitForSeconds(source.clip.length);
        source.Play();
    }
    public void PlayFail()
    {
        source.PlayOneShot(fail);
    }
    public void PlayTik()
    {
        source.PlayOneShot(tik);
    }
}
