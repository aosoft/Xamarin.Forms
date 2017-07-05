using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Platform.WinForms
{
	internal sealed class WinFormsExpressionSearch : IExpressionSearch
	{
		public List<T> FindObjects<T>(Expression expression) where T : class
		{
			throw new NotImplementedException();
		}
	}
}
