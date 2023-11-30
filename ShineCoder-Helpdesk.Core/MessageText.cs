using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Core
{
	public class MessageText
	{
		private readonly Dictionary<int, string> text = new Dictionary<int, string>();
		private static MessageText _messageText;
		private static readonly object lockObj = new object();

		public string this[int value]
		{
			get
			{
				return string.Empty;

			}
		}


		public static MessageText GetMessage()
		{
			if (_messageText == null)
			{
				lock (lockObj)
				{
					_messageText = new MessageText();
				}
			}
			return _messageText;
		}
	}
}
