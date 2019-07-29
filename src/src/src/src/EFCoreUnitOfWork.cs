//-----------------------------------------------------------------------
// <copyright file="EFCoreUnitOfWork.cs" company="Bayhaksam">
//      Copyright (c) Bayhaksam. All rights reserved.
// </copyright>
// <author>Samet Kurumahmut</author>
//-----------------------------------------------------------------------

namespace Bayhaksam.EFCore
{
	using Bayhaksam.Data;
	using Microsoft.EntityFrameworkCore;
	using System;
	using System.Threading.Tasks;

	public class EFCoreUnitOfWork : IUnitOfWork
	{
		#region Fields
		/// <summary>
		/// Have its own disposed flag to detect redundant calls.
		/// </summary>
		bool disposed;
		#endregion

		#region Constructors
		public EFCoreUnitOfWork(DbContext context)
		{
			this.Context = context;
		}
		#endregion

		#region Destructors
		/// <summary>
		/// Call if exists any unmanaged resources
		/// </summary>
		~EFCoreUnitOfWork()
		{
			this.Dispose(false);
		}
		#endregion

		#region Protected Properties
		protected DbContext Context { get; set; }
		#endregion

		#region Public Methods
		#region IUnitOfWork Methods
		#region IDisposable Methods
		/// <inheritdoc/>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion

		/// <inheritdoc/>
		public Task CompleteAsync() => this.Context.SaveChangesAsync();

		/// <inheritdoc/>
		public void Complete() => this.Context.SaveChanges();
		#endregion
		#endregion

		#region Protected Methods
		/// <inheritdoc/>
		protected virtual void Dispose(bool disposing)
		{
			// Don' t dispose more than once
			if (this.disposed)
			{
				return;
			}

			// Release any managed resources here.
			if (disposing)
			{
				this.Context.Dispose();
			}

			// Release any unmanaged resources here.

			// Set disposed flag
			this.disposed = true;
		}
		#endregion
	}
}
