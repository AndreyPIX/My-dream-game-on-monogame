using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace StrategyRTS.Controle
{
	public class KeyboardLayout
	{
		private Dictionary<Keys, EnumKeyAction> dictionary;
		public KeyboardLayout()
		{
			dictionary = new Dictionary<Keys, EnumKeyAction>();
		}
		public void AddBind(Keys key, EnumKeyAction keyAction)
		{
			if (dictionary.ContainsKey(key))
			{
				dictionary[key] = keyAction;
			}
			else
			{
				dictionary.Add(key, keyAction);
			}
		}
		public EnumKeyAction GetActionForKey(Keys k)
		{
			EnumKeyAction keyAction;
			if (dictionary.ContainsKey(k))
			{
				keyAction = dictionary[k];
			}
			else
			{
				keyAction = EnumKeyAction.None;
			}
			return keyAction;
		}
	}
}
