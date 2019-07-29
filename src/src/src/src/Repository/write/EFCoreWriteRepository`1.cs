//-----------------------------------------------------------------------
// <copyright file="EFCoreWriteRepository`1.cs" company="Bayhaksam">
//      Copyright (c) Bayhaksam. All rights reserved.
// </copyright>
// <author>Samet Kurumahmut</author>
//-----------------------------------------------------------------------

namespace Bayhaksam.EFCore.Repository
{
	using Bayhaksam.Data.Repository;
	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;

	public class EFCoreWriteRepository<TEntity> : EFCoreRepositoryBase,
		IWriteRepository<TEntity> where TEntity : class
	{
		#region Constructors
		public EFCoreWriteRepository(DbContext context) : base(context)
		{
			this.Context = context;
		}
		#endregion

		#region IWriteRepository Methods
		public virtual void Add(TEntity entity) => this.Context.Set<TEntity>().Add(entity);

		public virtual void AddRange(IEnumerable<TEntity> entities) => this.Context.Set<TEntity>().AddRange(entities);

		public virtual void Remove(TEntity entity) => this.Context.Set<TEntity>().Remove(entity);

		public virtual void RemoveRange(IEnumerable<TEntity> entities) =>
			this.Context.Set<TEntity>().RemoveRange(entities);
		#endregion
	}
}
