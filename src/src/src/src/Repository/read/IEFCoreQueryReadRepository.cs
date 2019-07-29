//-----------------------------------------------------------------------
// <copyright file="IEFCoreQueryReadRepository`1.cs" company="Bayhaksam">
//      Copyright (c) Bayhaksam. All rights reserved.
// </copyright>
// <author>Samet Kurumahmut</author>
//-----------------------------------------------------------------------

namespace Bayhaksam.EFCore.Repository
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;

	public interface IEFCoreQueryReadRepository<TEntity> where TEntity : class
	{
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

		IEnumerable<TEntity> GetAll();

		TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
	}
}
