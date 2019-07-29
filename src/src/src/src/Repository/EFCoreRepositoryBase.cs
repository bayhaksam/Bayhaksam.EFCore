//-----------------------------------------------------------------------
// <copyright file="EFCoreRepositoryBase.cs" company="Bayhaksam">
//      Copyright (c) Bayhaksam. All rights reserved.
// </copyright>
// <author>Samet Kurumahmut</author>
//-----------------------------------------------------------------------

namespace Bayhaksam.EFCore.Repository
{
	using Microsoft.EntityFrameworkCore;

	public abstract class EFCoreRepositoryBase
	{
		#region Constructors
		protected EFCoreRepositoryBase(DbContext context)
		{
			this.Context = context;
		}
		#endregion

		#region Protected Properties
		protected DbContext Context { get; set; }
		#endregion
	}
}
