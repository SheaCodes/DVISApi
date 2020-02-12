using System;

namespace DVISApi.TSTypes
{
	public class TSNumberWeb : TSPointWeb
	{
		public double Value { get; set; }

		public TSNumberWeb(double value, DateTime dt) : base(dt)
		{
			Value = value;
		}

		public override object ValueObject
		{
			get { return Value; }
		}
	}
}