//-----------------------------------------------------------------------
// <copyright file="EFCoreReadRepository`1.cs" company="Bayhaksam">
//      Copyright (c) Bayhaksam. All rights reserved.
// </copyright>
// <author>Samet Kurumahmut</author>
//-----------------------------------------------------------------------

namespace Bayhaksam.EFCore.Repository
{
	using Bayhaksam.Data.Repository;
	using Microsoft.EntityFrameworkCore;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;

	public class EFCoreReadRepository<TEntity> : EFCoreRepositoryBase, IReadRepository<TEntity> where TEntity : class
	{
		#region Constructors
		public EFCoreReadRepository(DbContext context) : base(context)
		{
			this.Context = context;
		}
		#endregion

		#region IReadRepository Methods
		public virtual bool IsExists(int id) => this.Context.Set<TEntity>().Find(id) != null;

		public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) =>
			this.Context.Set<TEntity>().Where(predicate);

		public virtual IEnumerable<TEntity> GetAll() => this.Context.Set<TEntity>().ToList();

		public virtual TEntity Get(int id) => this.Context.Set<TEntity>().Find(id);

		public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate) =>
			this.Context.Set<TEntity>().SingleOrDefault(predicate);
		#endregion
	}
}
