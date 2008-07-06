using System;
using System.Collections.Generic;

namespace BerkeleyDb
{
	public class BerkeleyDbTransaction : DisposableMixin
	{
		private readonly BerkeleyDbTransaction parent;
		private readonly BerkeleyDbEnvironment environment;
		private readonly Txn inner;
		private readonly List<Action> actions = new List<Action>();

		internal Txn InnerTransaction
		{
			get { return inner;}
		}

		public BerkeleyDbTransaction(BerkeleyDbEnvironment environment,Txn inner)
		{
			this.environment = environment;
			this.inner = inner;
		}

		private BerkeleyDbTransaction(BerkeleyDbEnvironment environment, BerkeleyDbTransaction parent, Txn inner)
		{
			this.environment = environment;
			this.parent = parent;
			this.inner = inner;
		}

		public void Commit()
		{
			inner.Commit(Txn.CommitMode.None);
		}

		private void ExecuteDisposeSyncronizations()
		{
			foreach (var action in actions)
			{
				action();
			}
			actions.Clear();
		}

		public void Rollback()
		{
			inner.Abort();
		}

		protected override void Dispose(bool disposing)
		{
			inner.Dispose();
			ExecuteDisposeSyncronizations();
			environment.TransactionDisposed(this, parent);
		}

		public BerkeleyDbTransaction NestTransaction(Func<Txn, Txn> createTransaction)
		{
			var transaction = createTransaction(inner);
			return new BerkeleyDbTransaction(environment, this, transaction);
		}

		public void RegisterDisposeSyncronization(Action action)
		{
			actions.Add(action);
		}

		
	}
}