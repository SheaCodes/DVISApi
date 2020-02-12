using System;

namespace DVISApi.TSTypes
{
	public class TSLabelWeb : TSPointWeb
	{
		public string Value { get; set; }

		public TSLabelWeb(string value, DateTime dt) : base(dt)
		{
			Value = value;
		}

		public override object ValueObject
		{
			get { return Value; }
		}
	}
}