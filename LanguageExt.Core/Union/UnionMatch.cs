using System;

namespace LanguageExt
{
	public interface IElse<TReturn>
	{
		TReturn Else(Func<TReturn> func);
	}

	public interface IWhere1<T1, TReturn>
	{
		IElse<TReturn> Where(Func<T1, TReturn> func);
	}

	public interface IWhere2<T1, T2, TReturn>
	{
		IWhere1<T2, TReturn> Where(Func<T1, TReturn> func);
	}

	public interface IWhere3<T1, T2, T3, TReturn>
	{
		IWhere2<T2, T3, TReturn> Where(Func<T1, TReturn> func);
	}

	public interface IWhere4<T1, T2, T3, T4, TReturn>
	{
		IWhere3<T2, T3, T4, TReturn> Where(Func<T1, TReturn> func);
	}

	public interface IWhere5<T1, T2, T3, T4, T5, TReturn>
	{
		IWhere4<T2, T3, T4, T5, TReturn> Where(Func<T1, TReturn> func);
	}

	public interface IWhere6<T1, T2, T3, T4, T5, T6, TReturn>
	{
		IWhere5<T2, T3, T4, T5, T6, TReturn> Where(Func<T1, TReturn> func);
	}

	public interface IWhere7<T1, T2, T3, T4, T5, T6, T7, TReturn>
	{
		IWhere6<T2, T3, T4, T5, T6, T7, TReturn> Where(Func<T1, TReturn> func);
	}

	public interface IWhere8<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>
	{
		IWhere7<T2, T3, T4, T5, T6, T7, T8, TReturn> Where(Func<T1, TReturn> func);
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
			if (value.Item1 == typeof(T))
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
		IWhere1<T1, TReturn>
	{
		public UnionMatch(Tuple<Type, object> value) : base(value)
		{
		}

		IElse<TReturn> IWhere1<T1, TReturn>.Where(Func<T1, TReturn> func) => SetReturnIfMatch(func).Return(this);
	}

	public class UnionMatch<T2, T1, TReturn> :
		UnionMatchBase<TReturn>,
		IWhere2<T2, T1, TReturn>,
		IWhere1<T1, TReturn>
	{
		public UnionMatch(Tuple<Type, object> value) : base(value)
		{
		}

		IElse<TReturn> IWhere1<T1, TReturn>.Where(Func<T1, TReturn> func) => SetReturnIfMatch(func).Return(this);

		IWhere1<T1, TReturn> IWhere2<T2, T1, TReturn>.Where(Func<T2, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);
	}

	public class UnionMatch<T3, T2, T1, TReturn> :
		UnionMatchBase<TReturn>,
		IWhere3<T3, T2, T1, TReturn>,
		IWhere2<T2, T1, TReturn>,
		IWhere1<T1, TReturn>
	{
		public UnionMatch(Tuple<Type, object> value) : base(value)
		{
		}

		IElse<TReturn> IWhere1<T1, TReturn>.Where(Func<T1, TReturn> func) => SetReturnIfMatch(func).Return(this);

		IWhere1<T1, TReturn> IWhere2<T2, T1, TReturn>.Where(Func<T2, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere2<T2, T1, TReturn> IWhere3<T3, T2, T1, TReturn>.Where(Func<T3, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);
	}

	public class UnionMatch<T4, T3, T2, T1, TReturn> :
		UnionMatchBase<TReturn>,
		IWhere4<T4, T3, T2, T1, TReturn>,
		IWhere3<T3, T2, T1, TReturn>,
		IWhere2<T2, T1, TReturn>,
		IWhere1<T1, TReturn>
	{
		public UnionMatch(Tuple<Type, object> value) : base(value)
		{
		}

		IElse<TReturn> IWhere1<T1, TReturn>.Where(Func<T1, TReturn> func) => SetReturnIfMatch(func).Return(this);

		IWhere1<T1, TReturn> IWhere2<T2, T1, TReturn>.Where(Func<T2, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere2<T2, T1, TReturn> IWhere3<T3, T2, T1, TReturn>.Where(Func<T3, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere3<T3, T2, T1, TReturn> IWhere4<T4, T3, T2, T1, TReturn>.Where(Func<T4, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);
	}

	public class UnionMatch<T5, T4, T3, T2, T1, TReturn> :
		UnionMatchBase<TReturn>,
		IWhere5<T5, T4, T3, T2, T1, TReturn>,
		IWhere4<T4, T3, T2, T1, TReturn>,
		IWhere3<T3, T2, T1, TReturn>,
		IWhere2<T2, T1, TReturn>,
		IWhere1<T1, TReturn>
	{
		public UnionMatch(Tuple<Type, object> value) : base(value)
		{
		}

		IElse<TReturn> IWhere1<T1, TReturn>.Where(Func<T1, TReturn> func) => SetReturnIfMatch(func).Return(this);

		IWhere1<T1, TReturn> IWhere2<T2, T1, TReturn>.Where(Func<T2, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere2<T2, T1, TReturn> IWhere3<T3, T2, T1, TReturn>.Where(Func<T3, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere3<T3, T2, T1, TReturn> IWhere4<T4, T3, T2, T1, TReturn>.Where(Func<T4, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere4<T4, T3, T2, T1, TReturn> IWhere5<T5, T4, T3, T2, T1, TReturn>.Where(Func<T5, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);
	}

	public class UnionMatch<T6, T5, T4, T3, T2, T1, TReturn> :
		UnionMatchBase<TReturn>,
		IWhere6<T6, T5, T4, T3, T2, T1, TReturn>,
		IWhere5<T5, T4, T3, T2, T1, TReturn>,
		IWhere4<T4, T3, T2, T1, TReturn>,
		IWhere3<T3, T2, T1, TReturn>,
		IWhere2<T2, T1, TReturn>,
		IWhere1<T1, TReturn>
	{
		public UnionMatch(Tuple<Type, object> value) : base(value)
		{
		}

		IElse<TReturn> IWhere1<T1, TReturn>.Where(Func<T1, TReturn> func) => SetReturnIfMatch(func).Return(this);

		IWhere1<T1, TReturn> IWhere2<T2, T1, TReturn>.Where(Func<T2, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere2<T2, T1, TReturn> IWhere3<T3, T2, T1, TReturn>.Where(Func<T3, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere3<T3, T2, T1, TReturn> IWhere4<T4, T3, T2, T1, TReturn>.Where(Func<T4, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere4<T4, T3, T2, T1, TReturn> IWhere5<T5, T4, T3, T2, T1, TReturn>.Where(Func<T5, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere5<T5, T4, T3, T2, T1, TReturn> IWhere6<T6, T5, T4, T3, T2, T1, TReturn>.Where(Func<T6, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);
	}

	public class UnionMatch<T7, T6, T5, T4, T3, T2, T1, TReturn> :
		UnionMatchBase<TReturn>,
		IWhere7<T7, T6, T5, T4, T3, T2, T1, TReturn>,
		IWhere6<T6, T5, T4, T3, T2, T1, TReturn>,
		IWhere5<T5, T4, T3, T2, T1, TReturn>,
		IWhere4<T4, T3, T2, T1, TReturn>,
		IWhere3<T3, T2, T1, TReturn>,
		IWhere2<T2, T1, TReturn>,
		IWhere1<T1, TReturn>
	{
		public UnionMatch(Tuple<Type, object> value) : base(value)
		{
		}

		IElse<TReturn> IWhere1<T1, TReturn>.Where(Func<T1, TReturn> func) => SetReturnIfMatch(func).Return(this);

		IWhere1<T1, TReturn> IWhere2<T2, T1, TReturn>.Where(Func<T2, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere2<T2, T1, TReturn> IWhere3<T3, T2, T1, TReturn>.Where(Func<T3, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere3<T3, T2, T1, TReturn> IWhere4<T4, T3, T2, T1, TReturn>.Where(Func<T4, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere4<T4, T3, T2, T1, TReturn> IWhere5<T5, T4, T3, T2, T1, TReturn>.Where(Func<T5, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere5<T5, T4, T3, T2, T1, TReturn> IWhere6<T6, T5, T4, T3, T2, T1, TReturn>.Where(Func<T6, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere6<T6, T5, T4, T3, T2, T1, TReturn> IWhere7<T7, T6, T5, T4, T3, T2, T1, TReturn>.Where(Func<T7, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);
	}

	public class UnionMatch<T8, T7, T6, T5, T4, T3, T2, T1, TReturn> :
		UnionMatchBase<TReturn>,
		IWhere8<T8, T7, T6, T5, T4, T3, T2, T1, TReturn>,
		IWhere7<T7, T6, T5, T4, T3, T2, T1, TReturn>,
		IWhere6<T6, T5, T4, T3, T2, T1, TReturn>,
		IWhere5<T5, T4, T3, T2, T1, TReturn>,
		IWhere4<T4, T3, T2, T1, TReturn>,
		IWhere3<T3, T2, T1, TReturn>,
		IWhere2<T2, T1, TReturn>,
		IWhere1<T1, TReturn>
	{
		public UnionMatch(Tuple<Type, object> value) : base(value)
		{
		}

		IElse<TReturn> IWhere1<T1, TReturn>.Where(Func<T1, TReturn> func) => SetReturnIfMatch(func).Return(this);

		IWhere1<T1, TReturn> IWhere2<T2, T1, TReturn>.Where(Func<T2, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere2<T2, T1, TReturn> IWhere3<T3, T2, T1, TReturn>.Where(Func<T3, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere3<T3, T2, T1, TReturn> IWhere4<T4, T3, T2, T1, TReturn>.Where(Func<T4, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere4<T4, T3, T2, T1, TReturn> IWhere5<T5, T4, T3, T2, T1, TReturn>.Where(Func<T5, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere5<T5, T4, T3, T2, T1, TReturn> IWhere6<T6, T5, T4, T3, T2, T1, TReturn>.Where(Func<T6, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere6<T6, T5, T4, T3, T2, T1, TReturn> IWhere7<T7, T6, T5, T4, T3, T2, T1, TReturn>.Where(Func<T7, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);

		IWhere7<T7, T6, T5, T4, T3, T2, T1, TReturn> IWhere8<T8, T7, T6, T5, T4, T3, T2, T1, TReturn>.Where(Func<T8, TReturn> func) =>
			SetReturnIfMatch(func).Return(this);
	}
}