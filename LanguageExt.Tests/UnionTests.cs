﻿using LanguageExt;
using System;
using Xunit;
using static LanguageExt.Prelude;

namespace LanguageExtTests
{
	public class UnionTests
	{
		[Fact]
		public void UnionTest3()
		{
			Union<string, int> x = "Test";

			string value = x.Match<string>()
				.With(a => a)
				.With(b => b.ToString())
				.Else(() => "Nothing");

			Assert.Equal("Test", value);
		}

		[Fact]
		public void UnionTest4()
		{
			var x = new Union<string, int>(100);

			string value = x.Match<string>()
				.With(a => a)
				.With(b => b.ToString())
				.Else(() => "Nothing");

			Assert.Equal("100", value);
		}

		[Fact]
		public void UnionTest5()
		{
			var x = new Union<string, int>(100);

			string value = x.Match<string>()
				.With(v => v)
				.With(c => c == 100, v => "Keeping It 100.")
				.With(v => "Tea?")
				.Else(() => "Nothing");

			Assert.Equal("Keeping It 100.", value);
		}

		[Fact]
		public void UnionTest5Depth()
		{
			var x = new Union<string, Union<string, Union<string>>>(new Union<string, Union<string>>(new Union<string>("Test")));

			string value = x.Match<string>()
				.With(v => v)
				.With(v => v
					.Match<string>()
						.With(b => "Not This")
						.With(c => c.Match<string>()
						   .With(d => d) // this is the match
						   .Else(() => "Not This"))
						.Else(() => "Not This"))
				.Else(() => "Not This");

			Assert.Equal("Test", value);
		}

		[Fact]
		public void UnionTest6()
		{
			string value = AOrB(true)
				.Match<string>()
				.With(v => v)
				.With(c => c == 100, v => "Keeping It 100.")
				.With(v => "Tea?")
				.Else(() => "Nothing");

			Assert.Equal("Keeping It 100.", value);
		}

		[Fact]
		public void UnionTest7()
		{
			string value = AOrB(false)
				.Match<string>()
				.With(a => a)
				.With(b => b == 100 ? "Keeping It 100." : "Tea?")
				.Else(() => "Nothing");

			Assert.Equal("test", value);
		}

		[Fact]
		public void UnionTest8()
		{
			var x = Prelude.ToErrorUnion<int, UnauthorizedAccessException>(() => AOrError(false));
			string value = x
				.Match<string>()
				.With(a => a.ToString())
				.With(b => "test")
				.Else(() => "Nothing");

			Assert.Equal("test", value);
		}

		private Union<string, int> AOrB(bool isA)
		{
			if (isA)
			{
				return 100;
			}
			else
			{
				return "test";
			}
		}

		private int AOrError(bool isA)
		{
			if (isA)
			{
				return 100;
			}
			else
			{
				throw new System.UnauthorizedAccessException();
			}
		}

		[Fact]
		public void UnionTest3_1()
		{
			Union<ItemType1, ItemType2, ItemType3> x = new ItemType3();

			Assert.Equal("value3", x.Match<string>()
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.Else(() => "Nothing"));
		}

		[Fact]
		public void UnionTest4_1()
		{
			Union<ItemType1, ItemType2, ItemType3, ItemType4> x = new ItemType4();

			Assert.Equal("value4", x.Match<string>()
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.Else(() => "Nothing"));
		}

		[Fact]
		public void UnionTest5_1()
		{
			Union<ItemType1, ItemType2, ItemType3, ItemType4, ItemType5> x = new ItemType5();

			Assert.Equal("value5", x.Match<string>()
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.Else(() => "Nothing"));
		}

		[Fact]
		public void UnionTest6_1()
		{
			Union<ItemType1, ItemType2, ItemType3, ItemType4, ItemType5, ItemType6> x = new ItemType6();

			Assert.Equal("value6", x.Match<string>()
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.Else(() => "Nothing"));
		}

		[Fact]
		public void UnionTest7_1()
		{
			Union<ItemType1, ItemType2, ItemType3, ItemType4, ItemType5, ItemType6, ItemType7> x = new ItemType7();

			Assert.Equal("value7", x.Match<string>()
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.Else(() => "Nothing"));
		}

		[Fact]
		public void UnionTest8_1()
		{
			Union<ItemType1, ItemType2, ItemType3, ItemType4, ItemType5, ItemType6, ItemType7, ItemType8> x = new ItemType8();

			Assert.Equal("value8", x.Match<string>()
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.With(item => item.Value)
				.Else(() => "Nothing"));
		}

		public class TestTypeBase
		{
			public string Value { get; }

			public TestTypeBase(string value)
			{
				this.Value = value;
			}
		}

		public class ItemType1 : TestTypeBase
		{
			public ItemType1() : base("value1")
			{
			}
		}

		public class ItemType2 : TestTypeBase
		{
			public ItemType2() : base("value2")
			{
			}
		}

		public class ItemType3 : TestTypeBase
		{
			public ItemType3() : base("value3")
			{
			}
		}

		public class ItemType4 : TestTypeBase
		{
			public ItemType4() : base("value4")
			{
			}
		}

		public class ItemType5 : TestTypeBase
		{
			public ItemType5() : base("value5")
			{
			}
		}

		public class ItemType6 : TestTypeBase
		{
			public ItemType6() : base("value6")
			{
			}
		}

		public class ItemType7 : TestTypeBase
		{
			public ItemType7() : base("value7")
			{
			}
		}

		public class ItemType8 : TestTypeBase
		{
			public ItemType8() : base("value8")
			{
			}
		}
	}
}