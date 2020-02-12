using System;

namespace DVISApi.TSTypes
{
	public class TSFlagWeb : TSPointWeb
	{
		public bool Value { get; set; }

		public TSFlagWeb(bool value, DateTime dt) : base(dt)
		{
			Value = value;
		}

		public override object ValueObject
		{
			get { return Value; }
		}
	}
}