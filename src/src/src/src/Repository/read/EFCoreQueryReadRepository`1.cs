//-----------------------------------------------------------------------
// <copyright file="EFCoreQueryReadRepository`1.cs" company="Bayhaksam">
//      Copyright (c) Bayhaksam. All rights reserved.
// </copyright>
// <author>Samet Kurumahmut</author>
//-----------------------------------------------------------------------

namespace Bayhaksam.EFCore.Repository
{
	using Microsoft.EntityFrameworkCore;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;

	public class EFCoreQueryReadRepository<TEntity> : EFCoreRepositoryBase, IEFCoreQueryReadRepository<TEntity>
		where TEntity : class
	{
		#region Constructors
		public EFCoreQueryReadRepository(DbContext context) : base(context)
		{
			this.Context = context;
		}
		#endregion

		#region IEFCoreQueryReadRepository Methods
		public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) =>
			this.Context.Query<TEntity>().Where(predicate);

		public virtual IEnumerable<TEntity> GetAll() => this.Context.Query<TEntity>().ToList();

		public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate) =>
			this.Context.Query<TEntity>().FirstOrDefault(predicate);
		#endregion
	}
}
