using System;
using static LanguageExt.Prelude;

namespace LanguageExt
{
	public interface IUnion
	{
	}

	public class Union<T1> : IUnion
	{
		private readonly Tuple<Type, Object> Value;

		public Union(T1 value)
		{
			this.Value = Tuple(typeof(T1), (object)value);
		}

		public static implicit operator Union<T1>(T1 item)
		{
			return new Union<T1>(item);
		}

		public IWith1<T1, TReturn> Match<TReturn>() => new UnionMatch<T1, TReturn>(Value);
	}

	public class Union<T1, T2> : IUnion
	{
		private readonly Tuple<Type, Object> Value;

		public Union(T1 value)
		{
			this.Value = Tuple(typeof(T1), (object)value);
		}

		public Union(T2 value)
		{
			this.Value = Tuple(typeof(T2), (object)value);
		}

		public static implicit operator Union<T1, T2>(T1 item)
		{
			return new Union<T1, T2>(item);
		}

		public static implicit operator Union<T1, T2>(T2 item)
		{
			return new Union<T1, T2>(item);
		}

		public IWith2<T1, T2, TReturn> Match<TReturn>() => new UnionMatch<T1, T2, TReturn>(Value);
	}

	public class Union<T1, T2, T3> : IUnion
	{
		private readonly Tuple<Type, Object> Value;

		public Union(T1 value)
		{
			this.Value = Tuple(typeof(T1), (object)value);
		}

		public Union(T2 value)
		{
			this.Value = Tuple(typeof(T2), (object)value);
		}

		public Union(T3 value)
		{
			this.Value = Tuple(typeof(T3), (object)value);
		}

		public static implicit operator Union<T1, T2, T3>(T1 item)
		{
			return new Union<T1, T2, T3>(item);
		}

		public static implicit operator Union<T1, T2, T3>(T2 item)
		{
			return new Union<T1, T2, T3>(item);
		}

		public static implicit operator Union<T1, T2, T3>(T3 item)
		{
			return new Union<T1, T2, T3>(item);
		}

		public IWith3<T1, T2, T3, TReturn> Match<TReturn>() => new UnionMatch<T1, T2, T3, TReturn>(Value);
	}

	public class Union<T1, T2, T3, T4> : IUnion
	{
		private readonly Tuple<Type, Object> Value;

		public Union(T1 value)
		{
			this.Value = Tuple(typeof(T1), (object)value);
		}

		public Union(T2 value)
		{
			this.Value = Tuple(typeof(T2), (object)value);
		}

		public Union(T3 value)
		{
			this.Value = Tuple(typeof(T3), (object)value);
		}

		public Union(T4 value)
		{
			this.Value = Tuple(typeof(T4), (object)value);
		}

		public static implicit operator Union<T1, T2, T3, T4>(T1 item)
		{
			return new Union<T1, T2, T3, T4>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4>(T2 item)
		{
			return new Union<T1, T2, T3, T4>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4>(T3 item)
		{
			return new Union<T1, T2, T3, T4>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4>(T4 item)
		{
			return new Union<T1, T2, T3, T4>(item);
		}

		public IWith4<T1, T2, T3, T4, TReturn> Match<TReturn>() => new UnionMatch<T1, T2, T3, T4, TReturn>(Value);
	}

	public class Union<T1, T2, T3, T4, T5> : IUnion
	{
		private readonly Tuple<Type, Object> Value;

		public Union(T1 value)
		{
			this.Value = Tuple(typeof(T1), (object)value);
		}

		public Union(T2 value)
		{
			this.Value = Tuple(typeof(T2), (object)value);
		}

		public Union(T3 value)
		{
			this.Value = Tuple(typeof(T3), (object)value);
		}

		public Union(T4 value)
		{
			this.Value = Tuple(typeof(T4), (object)value);
		}

		public Union(T5 value)
		{
			this.Value = Tuple(typeof(T5), (object)value);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5>(T1 item)
		{
			return new Union<T1, T2, T3, T4, T5>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5>(T2 item)
		{
			return new Union<T1, T2, T3, T4, T5>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5>(T3 item)
		{
			return new Union<T1, T2, T3, T4, T5>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5>(T4 item)
		{
			return new Union<T1, T2, T3, T4, T5>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5>(T5 item)
		{
			return new Union<T1, T2, T3, T4, T5>(item);
		}

		public IWith5<T1, T2, T3, T4, T5, TReturn> Match<TReturn>() => new UnionMatch<T1, T2, T3, T4, T5, TReturn>(Value);
	}

	public class Union<T1, T2, T3, T4, T5, T6> : IUnion
	{
		private readonly Tuple<Type, Object> Value;

		public Union(T1 value)
		{
			this.Value = Tuple(typeof(T1), (object)value);
		}

		public Union(T2 value)
		{
			this.Value = Tuple(typeof(T1), (object)value);
		}

		public Union(T3 value)
		{
			this.Value = Tuple(typeof(T3), (object)value);
		}

		public Union(T4 value)
		{
			this.Value = Tuple(typeof(T4), (object)value);
		}

		public Union(T5 value)
		{
			this.Value = Tuple(typeof(T5), (object)value);
		}

		public Union(T6 value)
		{
			this.Value = Tuple(typeof(T6), (object)value);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T1 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T2 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T3 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T4 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T5 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6>(T6 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6>(item);
		}

		public IWith6<T1, T2, T3, T4, T5, T6, TReturn> Match<TReturn>() => new UnionMatch<T1, T2, T3, T4, T5, T6, TReturn>(Value);
	}

	public class Union<T1, T2, T3, T4, T5, T6, T7> : IUnion
	{
		private readonly Tuple<Type, Object> Value;

		public Union(T1 value)
		{
			this.Value = Tuple(typeof(T1), (object)value);
		}

		public Union(T2 value)
		{
			this.Value = Tuple(typeof(T2), (object)value);
		}

		public Union(T3 value)
		{
			this.Value = Tuple(typeof(T3), (object)value);
		}

		public Union(T4 value)
		{
			this.Value = Tuple(typeof(T4), (object)value);
		}

		public Union(T5 value)
		{
			this.Value = Tuple(typeof(T5), (object)value);
		}

		public Union(T6 value)
		{
			this.Value = Tuple(typeof(T6), (object)value);
		}

		public Union(T7 value)
		{
			this.Value = Tuple(typeof(T7), (object)value);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T1 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6, T7>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T2 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6, T7>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T3 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6, T7>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T4 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6, T7>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T5 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6, T7>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T6 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6, T7>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T7 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6, T7>(item);
		}

		public IWith7<T1, T2, T3, T4, T5, T6, T7, TReturn> Match<TReturn>() => new UnionMatch<T1, T2, T3, T4, T5, T6, T7, TReturn>(Value);
	}

	public class Union<T1, T2, T3, T4, T5, T6, T7, T8> : IUnion
	{
		private readonly Tuple<Type, Object> Value;

		public Union(T1 value)
		{
			this.Value = Tuple(typeof(T1), (object)value);
		}

		public Union(T2 value)
		{
			this.Value = Tuple(typeof(T2), (object)value);
		}

		public Union(T3 value)
		{
			this.Value = Tuple(typeof(T3), (object)value);
		}

		public Union(T4 value)
		{
			this.Value = Tuple(typeof(T4), (object)value);
		}

		public Union(T5 value)
		{
			this.Value = Tuple(typeof(T5), (object)value);
		}

		public Union(T6 value)
		{
			this.Value = Tuple(typeof(T6), (object)value);
		}

		public Union(T7 value)
		{
			this.Value = Tuple(typeof(T7), (object)value);
		}

		public Union(T8 value)
		{
			this.Value = Tuple(typeof(T8), (object)value);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T1 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6, T7, T8>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T2 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6, T7, T8>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T3 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6, T7, T8>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T4 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6, T7, T8>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T5 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6, T7, T8>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T6 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6, T7, T8>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T7 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6, T7, T8>(item);
		}

		public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8>(T8 item)
		{
			return new Union<T1, T2, T3, T4, T5, T6, T7, T8>(item);
		}

		public IWith8<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> Match<TReturn>() => new UnionMatch<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>(Value);
	}
}