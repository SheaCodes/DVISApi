using System;
using System.Collections.Generic;
using DVISApi.TSTypes;
using NUnit.Framework;

namespace DVISApi
{
	[TestFixture]
	public class TSPointWebIteratorTest : AssertionHelper
	{
		[Test]
		public void Test_NoPoints_ReturnsNull()
		{
			var dt = new DateTime(2008, 01, 01);

			TSPointWebIterator w = new TSPointWebIterator(new List<TSPointWeb>());
			Expect(w.Get(dt), Is.Null);
		}

		[Test]
		public void Test1()
		{
			var dt = new DateTime(2008, 01, 01);

			TSPointWebIterator w = new TSPointWebIterator(new List<TSPointWeb>{new TSNumberWeb(1d, dt)});

			Expect(w.Get(dt.AddSeconds(-1)), Is.Null);
			Expect(w.Get(dt.AddSeconds(0)),  Is.Not.Null);
			Expect(w.Get(dt.AddSeconds(1)),  Is.Not.Null);
		}

		[Test]
		public void Test2()
		{
			var dt = new DateTime(2008, 01, 01);

			var dt1 = dt.AddSeconds(0);
			var dt2 = dt.AddSeconds(1);

			TSPointWebIterator w = new TSPointWebIterator(new List<TSPointWeb>
			{
				new TSNumberWeb(1d, dt1),
				new TSNumberWeb(2d, dt2)
			});

			Expect(w.Get(dt.AddSeconds(-1)), Is.Null);

			Expect(w.Get(dt.AddSeconds(0)),             Is.Not.Null);
			Expect(w.Get(dt.AddSeconds(0)).TimeStamp,   Is.EqualTo(dt1));
			Expect(w.Get(dt.AddSeconds(0)).ValueObject, Is.EqualTo(1d));

			Expect(w.Get(dt.AddSeconds(1)),             Is.Not.Null);
			Expect(w.Get(dt.AddSeconds(1)).TimeStamp,   Is.EqualTo(dt2));
			Expect(w.Get(dt.AddSeconds(1)).ValueObject, Is.EqualTo(2d));

			Expect(w.Get(dt.AddSeconds(2)),             Is.Not.Null);
			Expect(w.Get(dt.AddSeconds(2)).TimeStamp,   Is.EqualTo(dt2));
			Expect(w.Get(dt.AddSeconds(2)).ValueObject, Is.EqualTo(2d));
		}
	}
}