using System;

namespace WorldBuilder.Helpers
{
	/// <summary>
	/// Extension methods to ease the pain of working with object properties when object could be null<br/>
	/// </summary>
	/// <remarks>
	/// Inspired by: http://en.wikipedia.org/wiki/Monad_(functional_programming)<br/>
	/// Source: http://devtalk.net/csharp/chained-null-checks-and-the-maybe-monad/
	/// </remarks>
	public static class Maybe
	{
		public static TResult Return<TInput, TResult>(this TInput obj, Func<TInput, TResult> evaluator)
			where TResult : class
			where TInput : class
		{
			return obj == null ? null : evaluator(obj);
		}

		public static TResult Return<TInput, TResult>(this TInput obj, Func<TInput, TResult> evaluator, TResult failureValue)
			where TInput : class
		{
			return obj == null ? failureValue : evaluator(obj);
		}

		public static TInput If<TInput>(this TInput obj, Func<TInput, bool> evaluator)
			where TInput : class
		{
			return obj == null ? null : evaluator(obj) ? obj : null;
		}

		public static TInput Unless<TInput>(this TInput obj, Func<TInput, bool> evaluator)
			where TInput : class
		{
			return obj == null ? null : evaluator(obj) ? null : obj;
		}

		public static TInput Do<TInput>(this TInput obj, Action<TInput> action)
			where TInput : class
		{
			if (obj == null) return null;
			action(obj);
			return obj;
		}
	}
}