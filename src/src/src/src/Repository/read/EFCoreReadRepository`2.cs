//-----------------------------------------------------------------------
// <copyright file="EFCoreReadRepository`2.cs" company="Bayhaksam">
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

	public class EFCoreReadRepository<TEntity, TPrimaryKey>
		: EFCoreRepositoryBase, IReadRepository<TEntity, TPrimaryKey> where TEntity : class
	{
		#region Constructors
		public EFCoreReadRepository(DbContext context) : base(context)
		{
			this.Context = context;
		}
		#endregion

		#region IReadRepository Methods
		public virtual bool IsExists(TPrimaryKey id) => this.Context.Set<TEntity>().Find(id) != null;

		public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) =>
			this.Context.Set<TEntity>().Where(predicate);

		public virtual IEnumerable<TEntity> GetAll() => this.Context.Set<TEntity>().ToList();

		public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate) =>
			this.Context.Set<TEntity>().FirstOrDefault(predicate);

		public virtual TEntity Get(TPrimaryKey id) => this.Context.Set<TEntity>().Find(id);
		#endregion
	}
}
