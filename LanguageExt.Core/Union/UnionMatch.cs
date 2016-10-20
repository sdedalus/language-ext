using System;

namespace LanguageExt
{
	public interface IElse<TReturn>
	{
		TReturn Else(Func<TReturn> func);
	}

	public interface IWith1<T1, TReturn>
	{
		IElse<TReturn> With(Func<T1, TReturn> func);

		IWith1<T1, TReturn> With(Func<T1, bool> condition, Func<T1, TReturn> func);
	}

	public interface IWith2<T1, T2, TReturn>
	{
		IWith1<T2, TReturn> With(Func<T1, TReturn> func);

		IWith2<T1, T2, TReturn> With(Func<T1, bool> condition, Func<T1, TReturn> func);
	}

	public interface IWith3<T1, T2, T3, TReturn>
	{
		IWith2<T2, T3, TReturn> With(Func<T1, TReturn> func);

		IWith3<T1, T2, T3, TReturn> With(Func<T1, bool> condition, Func<T1, TReturn> func);
	}

	public interface IWith4<T1, T2, T3, T4, TReturn>
	{
		IWith3<T2, T3, T4, TReturn> With(Func<T1, TReturn> func);

		IWith4<T1, T2, T3, T4, TReturn> With(Func<T1, bool> condition, Func<T1, TReturn> func);
	}

	public interface IWith5<T1, T2, T3, T4, T5, TReturn>
	{
		IWith4<T2, T3, T4, T5, TReturn> With(Func<T1, TReturn> func);

		IWith5<T1, T2, T3, T4, T5, TReturn> With(Func<T1, bool> condition, Func<T1, TReturn> func);
	}

	public interface IWith6<T1, T2, T3, T4, T5, T6, TReturn>
	{
		IWith5<T2, T3, T4, T5, T6, TReturn> With(Func<T1, TReturn> func);

		IWith6<T1, T2, T3, T4, T5, T6, TReturn> With(Func<T1, bool> condition, Func<T1, TReturn> func);
	}

	public interface IWith7<T1, T2, T3, T4, T5, T6, T7, TReturn>
	{
		IWith6<T2, T3, T4, T5, T6, T7, TReturn> With(Func<T1, TReturn> func);

		IWith7<T1, T2, T3, T4, T5, T6, T7, TReturn> With(Func<T1, bool> condition, Func<T1, TReturn> func);
	}

	public interface IWith8<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>
	{
		IWith7<T2, T3, T4, T5, T6, T7, T8, TReturn> With(Func<T1, TReturn> func);

		IWith8<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> With(Func<T1, bool> condition, Func<T1, TReturn> func);
	}

	public class UnionMatchBase<TReturn> : IElse<TReturn>
	{
		internal TReturn returnValue;
		internal readonly Tuple<Type, object> value;
		private bool matched = false;

		public UnionMatchBase(Tuple<Type, object> value)
		{
			this.value = value;
		}

		internal Unit SetReturnIfMatch<T>(Func<T, TReturn> func)
		{
			if (!matched && value.Item1 == typeof(T))
			{
				returnValue = func((T)value.Item2);
				matched = true;
			}

			return Unit.Default;
		}

		internal Unit SetReturnIfMatch<T>(Func<T, bool> condition, Func<T, TReturn> func)
		{
			if (!matched && value.Item1 == typeof(T) && condition((T)value.Item2))
			{
				returnValue = func((T)value.Item2);
				matched = true;
			}

			return Unit.Default;
		}

		TReturn IElse<TReturn>.Else(Func<TReturn> func)
		{
			return matched ? returnValue : func();
		}
	}

	public class UnionMatch<T1, TReturn> :
		UnionMatchBase<TReturn>,
		IWith1<T1, TReturn>
	{
		public UnionMatch(Tuple<Type, object> value) : base(value)
		{
		}

		IElse<TReturn> IWith1<T1, TReturn>.With(Func<T1, TReturn> func) => SetReturnIfMatch(func).Return(this);

		IWith1<T1, TReturn> IWith1<T1, TReturn>.With(Func<T1, bool> condition, Func<T1, TReturn> func)
		=> SetReturnIfMatch(condition, func).Return(this);
	}

	public class UnionMatch<T2, T1, TReturn> :
		UnionMatchBase<TReturn>,
		IWith2<T2, T1, TReturn>,
		IWith1<T1, TReturn>
	{
		public UnionMatch(Tuple<Type, object> value) : base(value)
		{
		}

		IElse<TReturn> IWith1<T1, TReturn>.With(Func<T1, TReturn> func) => SetReturnIfMatch(func).Return(this);

		IWith1<T1, TReturn> IWith2<T2, T1, TReturn>.With(Func<T2, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith1<T1, TReturn> IWith1<T1, TReturn>.With(Func<T1, bool> condition, Func<T1, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith2<T2, T1, TReturn> IWith2<T2, T1, TReturn>.With(Func<T2, bool> condition, Func<T2, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);
	}

	public class UnionMatch<T3, T2, T1, TReturn> :
		UnionMatchBase<TReturn>,
		IWith3<T3, T2, T1, TReturn>,
		IWith2<T2, T1, TReturn>,
		IWith1<T1, TReturn>
	{
		public UnionMatch(Tuple<Type, object> value) : base(value)
		{
		}

		IElse<TReturn> IWith1<T1, TReturn>.With(Func<T1, TReturn> func) => SetReturnIfMatch(func).Return(this);

		IWith1<T1, TReturn> IWith2<T2, T1, TReturn>.With(Func<T2, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith2<T2, T1, TReturn> IWith3<T3, T2, T1, TReturn>.With(Func<T3, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith1<T1, TReturn> IWith1<T1, TReturn>.With(Func<T1, bool> condition, Func<T1, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith2<T2, T1, TReturn> IWith2<T2, T1, TReturn>.With(Func<T2, bool> condition, Func<T2, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith3<T3, T2, T1, TReturn> IWith3<T3, T2, T1, TReturn>.With(Func<T3, bool> condition, Func<T3, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);
	}

	public class UnionMatch<T4, T3, T2, T1, TReturn> :
		UnionMatchBase<TReturn>,
		IWith4<T4, T3, T2, T1, TReturn>,
		IWith3<T3, T2, T1, TReturn>,
		IWith2<T2, T1, TReturn>,
		IWith1<T1, TReturn>
	{
		public UnionMatch(Tuple<Type, object> value) : base(value)
		{
		}

		IElse<TReturn> IWith1<T1, TReturn>.With(Func<T1, TReturn> func) => SetReturnIfMatch(func).Return(this);

		IWith1<T1, TReturn> IWith2<T2, T1, TReturn>.With(Func<T2, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith2<T2, T1, TReturn> IWith3<T3, T2, T1, TReturn>.With(Func<T3, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith3<T3, T2, T1, TReturn> IWith4<T4, T3, T2, T1, TReturn>.With(Func<T4, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith1<T1, TReturn> IWith1<T1, TReturn>.With(Func<T1, bool> condition, Func<T1, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith2<T2, T1, TReturn> IWith2<T2, T1, TReturn>.With(Func<T2, bool> condition, Func<T2, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith3<T3, T2, T1, TReturn> IWith3<T3, T2, T1, TReturn>.With(Func<T3, bool> condition, Func<T3, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith4<T4, T3, T2, T1, TReturn> IWith4<T4, T3, T2, T1, TReturn>.With(Func<T4, bool> condition, Func<T4, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);
	}

	public class UnionMatch<T5, T4, T3, T2, T1, TReturn> :
		UnionMatchBase<TReturn>,
		IWith5<T5, T4, T3, T2, T1, TReturn>,
		IWith4<T4, T3, T2, T1, TReturn>,
		IWith3<T3, T2, T1, TReturn>,
		IWith2<T2, T1, TReturn>,
		IWith1<T1, TReturn>
	{
		public UnionMatch(Tuple<Type, object> value) : base(value)
		{
		}

		IElse<TReturn> IWith1<T1, TReturn>.With(Func<T1, TReturn> func) => SetReturnIfMatch(func).Return(this);

		IWith1<T1, TReturn> IWith2<T2, T1, TReturn>.With(Func<T2, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith2<T2, T1, TReturn> IWith3<T3, T2, T1, TReturn>.With(Func<T3, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith3<T3, T2, T1, TReturn> IWith4<T4, T3, T2, T1, TReturn>.With(Func<T4, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith4<T4, T3, T2, T1, TReturn> IWith5<T5, T4, T3, T2, T1, TReturn>.With(Func<T5, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith2<T2, T1, TReturn> IWith2<T2, T1, TReturn>.With(Func<T2, bool> condition, Func<T2, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith1<T1, TReturn> IWith1<T1, TReturn>.With(Func<T1, bool> condition, Func<T1, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith3<T3, T2, T1, TReturn> IWith3<T3, T2, T1, TReturn>.With(Func<T3, bool> condition, Func<T3, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith4<T4, T3, T2, T1, TReturn> IWith4<T4, T3, T2, T1, TReturn>.With(Func<T4, bool> condition, Func<T4, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith5<T5, T4, T3, T2, T1, TReturn> IWith5<T5, T4, T3, T2, T1, TReturn>.With(Func<T5, bool> condition, Func<T5, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);
	}

	public class UnionMatch<T6, T5, T4, T3, T2, T1, TReturn> :
		UnionMatchBase<TReturn>,
		IWith6<T6, T5, T4, T3, T2, T1, TReturn>,
		IWith5<T5, T4, T3, T2, T1, TReturn>,
		IWith4<T4, T3, T2, T1, TReturn>,
		IWith3<T3, T2, T1, TReturn>,
		IWith2<T2, T1, TReturn>,
		IWith1<T1, TReturn>
	{
		public UnionMatch(Tuple<Type, object> value) : base(value)
		{
		}

		IElse<TReturn> IWith1<T1, TReturn>.With(Func<T1, TReturn> func) => SetReturnIfMatch(func).Return(this);

		IWith1<T1, TReturn> IWith2<T2, T1, TReturn>.With(Func<T2, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith2<T2, T1, TReturn> IWith3<T3, T2, T1, TReturn>.With(Func<T3, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith3<T3, T2, T1, TReturn> IWith4<T4, T3, T2, T1, TReturn>.With(Func<T4, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith4<T4, T3, T2, T1, TReturn> IWith5<T5, T4, T3, T2, T1, TReturn>.With(Func<T5, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith5<T5, T4, T3, T2, T1, TReturn> IWith6<T6, T5, T4, T3, T2, T1, TReturn>.With(Func<T6, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith4<T4, T3, T2, T1, TReturn> IWith4<T4, T3, T2, T1, TReturn>.With(Func<T4, bool> condition, Func<T4, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith6<T6, T5, T4, T3, T2, T1, TReturn> IWith6<T6, T5, T4, T3, T2, T1, TReturn>.With(Func<T6, bool> condition, Func<T6, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith5<T5, T4, T3, T2, T1, TReturn> IWith5<T5, T4, T3, T2, T1, TReturn>.With(Func<T5, bool> condition, Func<T5, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith3<T3, T2, T1, TReturn> IWith3<T3, T2, T1, TReturn>.With(Func<T3, bool> condition, Func<T3, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith2<T2, T1, TReturn> IWith2<T2, T1, TReturn>.With(Func<T2, bool> condition, Func<T2, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith1<T1, TReturn> IWith1<T1, TReturn>.With(Func<T1, bool> condition, Func<T1, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);
	}

	public class UnionMatch<T7, T6, T5, T4, T3, T2, T1, TReturn> :
		UnionMatchBase<TReturn>,
		IWith7<T7, T6, T5, T4, T3, T2, T1, TReturn>,
		IWith6<T6, T5, T4, T3, T2, T1, TReturn>,
		IWith5<T5, T4, T3, T2, T1, TReturn>,
		IWith4<T4, T3, T2, T1, TReturn>,
		IWith3<T3, T2, T1, TReturn>,
		IWith2<T2, T1, TReturn>,
		IWith1<T1, TReturn>
	{
		public UnionMatch(Tuple<Type, object> value) : base(value)
		{
		}

		IElse<TReturn> IWith1<T1, TReturn>.With(Func<T1, TReturn> func) => SetReturnIfMatch(func).Return(this);

		IWith1<T1, TReturn> IWith2<T2, T1, TReturn>.With(Func<T2, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith2<T2, T1, TReturn> IWith3<T3, T2, T1, TReturn>.With(Func<T3, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith3<T3, T2, T1, TReturn> IWith4<T4, T3, T2, T1, TReturn>.With(Func<T4, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith4<T4, T3, T2, T1, TReturn> IWith5<T5, T4, T3, T2, T1, TReturn>.With(Func<T5, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith5<T5, T4, T3, T2, T1, TReturn> IWith6<T6, T5, T4, T3, T2, T1, TReturn>.With(Func<T6, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith6<T6, T5, T4, T3, T2, T1, TReturn> IWith7<T7, T6, T5, T4, T3, T2, T1, TReturn>.With(Func<T7, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith5<T5, T4, T3, T2, T1, TReturn> IWith5<T5, T4, T3, T2, T1, TReturn>.With(Func<T5, bool> condition, Func<T5, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith6<T6, T5, T4, T3, T2, T1, TReturn> IWith6<T6, T5, T4, T3, T2, T1, TReturn>.With(Func<T6, bool> condition, Func<T6, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith7<T7, T6, T5, T4, T3, T2, T1, TReturn> IWith7<T7, T6, T5, T4, T3, T2, T1, TReturn>.With(Func<T7, bool> condition, Func<T7, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith4<T4, T3, T2, T1, TReturn> IWith4<T4, T3, T2, T1, TReturn>.With(Func<T4, bool> condition, Func<T4, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith3<T3, T2, T1, TReturn> IWith3<T3, T2, T1, TReturn>.With(Func<T3, bool> condition, Func<T3, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith2<T2, T1, TReturn> IWith2<T2, T1, TReturn>.With(Func<T2, bool> condition, Func<T2, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith1<T1, TReturn> IWith1<T1, TReturn>.With(Func<T1, bool> condition, Func<T1, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);
	}

	public class UnionMatch<T8, T7, T6, T5, T4, T3, T2, T1, TReturn> :
		UnionMatchBase<TReturn>,
		IWith8<T8, T7, T6, T5, T4, T3, T2, T1, TReturn>,
		IWith7<T7, T6, T5, T4, T3, T2, T1, TReturn>,
		IWith6<T6, T5, T4, T3, T2, T1, TReturn>,
		IWith5<T5, T4, T3, T2, T1, TReturn>,
		IWith4<T4, T3, T2, T1, TReturn>,
		IWith3<T3, T2, T1, TReturn>,
		IWith2<T2, T1, TReturn>,
		IWith1<T1, TReturn>
	{
		public UnionMatch(Tuple<Type, object> value) : base(value)
		{
		}

		IElse<TReturn> IWith1<T1, TReturn>.With(Func<T1, TReturn> func) => SetReturnIfMatch(func).Return(this);

		IWith1<T1, TReturn> IWith2<T2, T1, TReturn>.With(Func<T2, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith2<T2, T1, TReturn> IWith3<T3, T2, T1, TReturn>.With(Func<T3, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith3<T3, T2, T1, TReturn> IWith4<T4, T3, T2, T1, TReturn>.With(Func<T4, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith4<T4, T3, T2, T1, TReturn> IWith5<T5, T4, T3, T2, T1, TReturn>.With(Func<T5, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith5<T5, T4, T3, T2, T1, TReturn> IWith6<T6, T5, T4, T3, T2, T1, TReturn>.With(Func<T6, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith6<T6, T5, T4, T3, T2, T1, TReturn> IWith7<T7, T6, T5, T4, T3, T2, T1, TReturn>.With(Func<T7, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith7<T7, T6, T5, T4, T3, T2, T1, TReturn> IWith8<T8, T7, T6, T5, T4, T3, T2, T1, TReturn>.With(Func<T8, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWith5<T5, T4, T3, T2, T1, TReturn> IWith5<T5, T4, T3, T2, T1, TReturn>.With(Func<T5, bool> condition, Func<T5, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith6<T6, T5, T4, T3, T2, T1, TReturn> IWith6<T6, T5, T4, T3, T2, T1, TReturn>.With(Func<T6, bool> condition, Func<T6, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith8<T8, T7, T6, T5, T4, T3, T2, T1, TReturn> IWith8<T8, T7, T6, T5, T4, T3, T2, T1, TReturn>.With(Func<T8, bool> condition, Func<T8, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith7<T7, T6, T5, T4, T3, T2, T1, TReturn> IWith7<T7, T6, T5, T4, T3, T2, T1, TReturn>.With(Func<T7, bool> condition, Func<T7, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith3<T3, T2, T1, TReturn> IWith3<T3, T2, T1, TReturn>.With(Func<T3, bool> condition, Func<T3, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith4<T4, T3, T2, T1, TReturn> IWith4<T4, T3, T2, T1, TReturn>.With(Func<T4, bool> condition, Func<T4, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith2<T2, T1, TReturn> IWith2<T2, T1, TReturn>.With(Func<T2, bool> condition, Func<T2, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);

		IWith1<T1, TReturn> IWith1<T1, TReturn>.With(Func<T1, bool> condition, Func<T1, TReturn> func) =>
			SetReturnIfMatch(condition, func).Return(this);
	}
}