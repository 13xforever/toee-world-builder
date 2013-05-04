using System;

namespace WorldBuilder.Helpers
{
	/// <summary>
	/// Набор методов расширения, облегчающий работу с объектами, которые могут оказаться пустыми<br/>
	/// </summary>
	/// <remarks>
	/// Ноги растут отсюда: http://en.wikipedia.org/wiki/Monad_(functional_programming)<br/>
	/// Код взят отсюда: http://devtalk.net/csharp/chained-null-checks-and-the-maybe-monad/
	/// </remarks>
	public static class Maybe
	{
		/// <summary>
		/// Возвращает результат выполнение действия над объектом, если этот объект не <value>null</value>
		/// </summary>
		/// <param name="obj">Объект</param>
		/// <param name="evaluator">Действие над объектом</param>
		/// <returns><value>null</value>, если <paramref name="obj"/> == <value>null</value>, иначе - результат выполнения <paramref name="evaluator"/> над <paramref name="obj"/></returns>
		public static TResult Return<TInput, TResult>(this TInput obj, Func<TInput, TResult> evaluator)
			where TResult : class
			where TInput : class
		{
			return obj == null ? null : evaluator(obj);
		}

		/// <summary>
		/// Выполнение действия над объектом, если этот объект не <value>null</value>
		/// </summary>
		/// <param name="obj">Объект</param>
		/// <param name="evaluator">Действие над объектом</param>
		/// <param name="failureValue">Значение, возвращаемое в случае, когда <paramref name="obj"/> == <value>null</value></param>
		/// <returns><paramref name="failureValue"/>, если <paramref name="obj"/> == <value>null</value>, иначе - результат выполнения <paramref name="evaluator"/> над <paramref name="obj"/></returns>
		public static TResult Return<TInput, TResult>(this TInput obj, Func<TInput, TResult> evaluator, TResult failureValue)
			where TInput : class
		{
			return obj == null ? failureValue : evaluator(obj);
		}

		/// <summary>
		/// Возвращает объект, если он не <value>null</value> и удовлетворяет условию
		/// </summary>
		/// <param name="obj">Объект</param>
		/// <param name="evaluator">Функция отсеивания, возвращающая <paramref name="obj"/>, если он удовлетворяет условию</param>
		/// <returns><paramref name="obj"/>, если он не <value>null</value> и удовлетворяет условию <paramref name="evaluator"/></returns>
		public static TInput If<TInput>(this TInput obj, Func<TInput, bool> evaluator)
			where TInput : class
		{
			return obj == null ? null : evaluator(obj) ? obj : null;
		}

		/// <summary>
		/// Возвращает объект, если он не <value>null</value> и не удовлетворяет условию
		/// </summary>
		/// <param name="obj">Объект</param>
		/// <param name="evaluator">Функция отсеивания, возвращающая <paramref name="obj"/>, если он не удовлетворяет условию</param>
		/// <returns><paramref name="obj"/>, если он не <value>null</value> и не удовлетворяет условию <paramref name="evaluator"/></returns>
		public static TInput Unless<TInput>(this TInput obj, Func<TInput, bool> evaluator)
			where TInput : class
		{
			return obj == null ? null : evaluator(obj) ? null : obj;
		}

		/// <summary>
		/// Выполняет действие над объектом, если он не <value>null</value>
		/// </summary>
		/// <param name="obj">Объект</param>
		/// <param name="action">Действие, выполняемое над объектом</param>
		/// <returns><value>null</value>, если <paramref name="obj"/> == <value>null</value>, иначе - объект, после выполнения над ним действия <paramref name="action"/></returns>
		public static TInput Do<TInput>(this TInput obj, Action<TInput> action)
			where TInput : class
		{
			if (obj == null) return null;
			action(obj);
			return obj;
		}
	}
}