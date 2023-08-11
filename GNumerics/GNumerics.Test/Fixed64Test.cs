using System;
using Gal.Core;
using static System.Int32;

namespace Fixed64Test {
	public class Fixed64Test {
		[Fact]
		public void TestInt() {
			Fixed64 f = 100;
			Assert.Equal(100, (int) f);

			f += 100;
			Assert.Equal(200, (int) f);

			f -= 100;
			Assert.Equal(100, (int) f);

			f *= 100;
			Assert.Equal(10000, (int) f);

			f /= 100;
			Assert.Equal(100, (int) f);
		}

		[Fact]
		public void TestFloat() {
			Fixed64 f = 100f;
			Assert.Equal(100f, (float) f);

			f += 100f;
			Assert.Equal(200f, (float) f);

			f -= 100f;
			Assert.Equal(100f, (float) f);

			f *= 100f;
			Assert.Equal(10000f, (float) f);

			f /= 100f;
			Assert.Equal(100f, (float) f);
		}

		[Fact]
		public void TestLong() {
			Fixed64 f = 100L;
			Assert.Equal(100L, (long) f);

			f += 100L;
			Assert.Equal(200L, (long) f);

			f -= 100L;
			Assert.Equal(100L, (long) f);

			f *= 100L;
			Assert.Equal(10000L, (long) f);

			f /= 100L;
			Assert.Equal(100L, (long) f);
		}

		[Fact]
		public void TestDouble() {
			Fixed64 f = 100d;
			Assert.Equal(100d, (double) f);

			f += 100d;
			Assert.Equal(200d, (double) f);

			f -= 100d;
			Assert.Equal(100f, (double) f);

			f *= 100d;
			Assert.Equal(10000d, (double) f);

			f /= 100d;
			Assert.Equal(100d, (double) f);
		}

		[Fact]
		public void TestAll() {
			Fixed64 f = 100;
			f += 0.5f;
			Assert.Equal(100.5f, (float) f);
			
			
		}
		
		[Fact]
		public void LongToFix64AndBack() {
			for (var i = 0; i < 10000; ++i) {
				var expected = Random.Shared.Next(MinValue, MaxValue);
				var f        = (Fixed64)expected;
				var actual   = (long)f;
				Assert.Equal(expected, actual);
			}
		}
		
		[Fact]
		public void DoubleToFix64AndBack()
		{
			var sources = new[] {
				(double)int.MinValue,
				-(double)Math.PI,
				-(double)Math.E,
				-1.0,
				-0.0,
				0.0,
				1.0,
				(double)Math.PI,
				(double)Math.E,
				(double)int.MaxValue
			};

			foreach (var value in sources) {
				Assert.True(Math.Abs(value - (Fixed64)value) < Fixed64.precision);
			}
		}
	}
}