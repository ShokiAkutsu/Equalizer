using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayBack : MonoBehaviour
{
    List<SoundButtonBase> _playBackList = new List<SoundButtonBase>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(AllPlaying());
        }
        //ƒŠƒZƒbƒg
        if(Input.GetKeyUp(KeyCode.Alpha0))
        {
            _playBackList.Clear();
        }
	}

    IEnumerator AllPlaying()
    {
		foreach (var button in _playBackList)
		{
			button.PlaySound();
            yield return new WaitForSeconds(button.ClipLength);
		}
	}

    public void GetPlayList(SoundButtonBase sound)
    {
        _playBackList.Add(sound);
        Debug.Log($"PlayList{_playBackList.Count}”Ô–Ú‚É{sound}‚ð“ü‚ê‚Ü‚µ‚½");
    }
}
