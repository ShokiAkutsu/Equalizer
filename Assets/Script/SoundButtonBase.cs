using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class SoundButtonBase : MonoBehaviour
{
	AudioSource _audioSource;
	[SerializeField] AudioClip _audioClip; //�h���N���X�ɓ����p
	protected float _clipLength;
	public float ClipLength => _clipLength;
	//�L�����N�^�[�̋���
	[SerializeField] KeyCode _key = KeyCode.K;
	Rigidbody2D _rb;
	Transform _tf;
	Vector2 _startPosition;

	protected virtual void Start()
	{
		if (_audioClip != null)
		{
			_clipLength = _audioClip.length;
		}
		_rb = GameObject.Find("Character").GetComponent<Rigidbody2D>();
		_tf = GameObject.Find("Character").GetComponent<Transform>();
		_audioSource = GetComponent<AudioSource>();
		_startPosition = _tf.position;
	}

	protected virtual void Update()
	{
		if (Input.GetKeyDown(_key))
		{
			PlaySound();
		}
	}

	public void PlaySound()
    {
		_audioSource.PlayOneShot(_audioClip);
		PlayMoving();
	}

	private void OnMouseDown()
	{
		AllPlayBack allPlayBack = GameObject.Find("Manager").GetComponent<AllPlayBack>();
		allPlayBack.GetPlayList(this);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			_audioSource.PlayOneShot(_audioClip);
		}
	}

	/// <summary>
	/// �������Ă���Ƃ��ɊȒP�ȓ����������
	/// ���̊֐���g�ݍ��킹�āAPlayMoving�ɋL�q
	/// </summary>
	protected abstract void PlayMoving();

	protected void Jump()
	{
		_rb.velocity = new Vector2(_rb.velocity.x, 5f);
	}

	protected void RightMove()
	{
		_rb.velocity = new Vector2(5f, _rb.velocity.y);
	}

	protected void LeftMove()
	{
		_rb.velocity = new Vector2(-3f, _rb.velocity.y);
	}
}
