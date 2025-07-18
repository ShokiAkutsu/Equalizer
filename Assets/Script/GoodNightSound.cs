using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodNightSound : SoundButtonBase
{
	protected override void PlayMoving()
	{
		Jump();
		RightMove();
	}
}
