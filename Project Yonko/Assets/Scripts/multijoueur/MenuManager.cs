using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
	public static MenuManager Instance;

	[SerializeField] Menu[] menus;

	void Awake()
	{
		Instance = this;
	}

	public void OpenMenu(string menuName)
	{
		int menuOp = -1;
		
		for (int i = 0;  i < menus.Length; i++)
		{
			if (menus[i].open)
				menuOp = i;
		}
		
		for (int i = 0; i < menus.Length; i++)
		{
			if(menus[i].menuName == menuName)
			{
				menus[i].Open();
				if (menuOp != -1)
					menus[menuOp].Close();
			}
			else if(menus[i].open)
			{
				CloseMenu(menus[i]);
			}
		}
	}

	public void OpenMenu(Menu menu)
	{
		for(int i = 0; i < menus.Length; i++)
		{
			if(menus[i].open)
			{
				CloseMenu(menus[i]);
			}
		}
		menu.Open();
	}

	public void CloseMenu(Menu menu)
	{
		menu.Close();
	}
}