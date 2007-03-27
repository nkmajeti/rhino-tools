using System;
using System.Collections.Generic;
using System.Data;
using NHibernate;
using NHibernate.Connection;
using NHibernate.Expression;
using Rhino.Commons;

namespace Rhino.Commons
{
	public class NHRepository<T> : IRepository<T>
	{
		protected virtual ISession Session
		{
			get { return NHibernateUnitOfWorkFactory.CurrentNHibernateSession; }
		}

		public T Get(object id)
		{
			return (T)Session.Get(typeof(T), id);
		}

		public T Load(object id)
		{
			return (T)Session.Load(typeof(T), id);
		}

		public void Delete(T entity)
		{
			Session.Delete(entity);
		}

		public void Save(T entity)
		{
			Session.Save(entity);
		}


	    public void Update(T entity)
	    {
	        Session.Update(entity);
	    }

	    public ICollection<T> FindAll(Order order, params ICriterion[] criteria)
		{
			ICriteria crit = RepositoryHelper<T>.CreateCriteriaFromArray(Session, criteria);
			crit.AddOrder(order);
			return crit.List<T>();
		}

		public ICollection<T> FindAll(Order[] orders, params ICriterion[] criteria)
		{
			ICriteria crit = RepositoryHelper<T>.CreateCriteriaFromArray(Session, criteria);
			foreach (Order order in orders)
			{
				crit.AddOrder(order);
			}
			return crit.List<T>();
		}

		public ICollection<T> FindAll(params ICriterion[] criteria)
		{
			ICriteria crit = RepositoryHelper<T>.CreateCriteriaFromArray(Session, criteria);
			return crit.List<T>();
		}

		public ICollection<T> FindAll(int firstResult, int numberOfResults, params ICriterion[] criteria)
		{
			ICriteria crit = RepositoryHelper<T>.CreateCriteriaFromArray(Session, criteria);
			crit.SetFirstResult(firstResult)
				.SetMaxResults(numberOfResults);
			return crit.List<T>();
		}

		public ICollection<T> FindAll(
			int firstResult, int numberOfResults, Order selectionOrder, params ICriterion[] criteria)
		{
			ICriteria crit = RepositoryHelper<T>.CreateCriteriaFromArray(Session, criteria);
			crit.SetFirstResult(firstResult)
				.SetMaxResults(numberOfResults);
			crit.AddOrder(selectionOrder);
			return crit.List<T>();
		}

		public ICollection<T> FindAll(
			int firstResult, int numberOfResults, Order[] selectionOrder, params ICriterion[] criteria)
		{
			ICriteria crit = RepositoryHelper<T>.CreateCriteriaFromArray(Session, criteria);
			crit.SetFirstResult(firstResult)
				.SetMaxResults(numberOfResults);
			foreach (Order order in selectionOrder)
			{
				crit.AddOrder(order);
			}
			return crit.List<T>();
		}

		public ICollection<T> FindAll(string namedQuery, params Parameter[] parameters)
		{
			IQuery query = RepositoryHelper<T>.CreateQuery(Session, namedQuery, parameters);
			return query.List<T>();
		}

		public ICollection<T> FindAll(
			int firstResult, int numberOfResults, string namedQuery, params Parameter[] parameters)
		{
			IQuery query = RepositoryHelper<T>.CreateQuery(Session, namedQuery, parameters);
			query.SetFirstResult(firstResult)
				.SetMaxResults(numberOfResults);
			return query.List<T>();
		}

		public T FindOne(params ICriterion[] criteria)
		{
			ICriteria crit = RepositoryHelper<T>.CreateCriteriaFromArray(Session, criteria);
			return (T)crit.UniqueResult();
		}

		public T FindOne(string namedQuery, params Parameter[] parameters)
		{
			IQuery query = RepositoryHelper<T>.CreateQuery(Session, namedQuery, parameters);
			return (T)query.UniqueResult();
		}

		public ICollection<T> FindAll(DetachedCriteria criteria, params Order[] orders)
		{
			ICriteria executableCriteria = RepositoryHelper<T>.GetExecutableCriteria(Session, criteria, orders);
			return executableCriteria.List<T>();
		}

		public ICollection<T> FindAll(DetachedCriteria criteria, int firstResult, int maxResults, params Order[] orders)
		{
			ICriteria executableCriteria = RepositoryHelper<T>.GetExecutableCriteria(Session, criteria, orders);
			executableCriteria.SetFirstResult(firstResult);
			executableCriteria.SetMaxResults(maxResults);
			return executableCriteria.List<T>();
		}

		public T FindOne(DetachedCriteria criteria)
		{
			ICriteria executableCriteria = RepositoryHelper<T>.GetExecutableCriteria(Session, criteria, null);
			return (T)executableCriteria.UniqueResult();
		}

		public T FindFirst(DetachedCriteria criteria, params Order[] orders)
		{
			ICriteria executableCriteria = RepositoryHelper<T>.GetExecutableCriteria(Session, criteria, orders);
			executableCriteria.SetFirstResult(0);
			executableCriteria.SetMaxResults(1);
			return (T)executableCriteria.UniqueResult();
		}

		/// <summary>
		/// Find the first entity of type
		/// </summary>
		/// <param name="orders">Optional orderring</param>
		/// <returns>The entity or null</returns>
		public T FindFirst(params Order[] orders)
		{
			return FindFirst(null, orders);
		}

		public object ExecuteStoredProcedure(string sp_name, params Parameter[] parameters)
		{
			IConnectionProvider connectionProvider = NHibernateUnitOfWorkFactory.NHibernateSessionFactory.ConnectionProvider;
			IDbConnection connection = connectionProvider.GetConnection();
			try
			{
				using (IDbCommand command = connection.CreateCommand())
				{
					command.CommandText = sp_name;
					command.CommandType = CommandType.StoredProcedure;

					RepositoryHelper<T>.CreateDbDataParameters(command, parameters);

					return command.ExecuteScalar();
				}
			}
			finally
			{
				connectionProvider.CloseConnection(connection);
			}
		}

		/// <summary>
		/// Execute the specified stored procedure with the given parameters and then converts
		/// the results using the supplied delegate.
		/// </summary>
		/// <typeparam name="T2">The collection type to return.</typeparam>
		/// <param name="converter">The delegate which converts the raw results.</param>
		/// <param name="sp_name">The name of the stored procedure.</param>
		/// <param name="parameters">Parameters for the stored procedure.</param>
		/// <returns></returns>
		public ICollection<T2> ExecuteStoredProcedure<T2>(Converter<IDataReader, T2> converter, string sp_name,
														  params Parameter[] parameters)
		{
			IConnectionProvider connectionProvider = NHibernateUnitOfWorkFactory.NHibernateSessionFactory.ConnectionProvider;
			IDbConnection connection = connectionProvider.GetConnection();

			try
			{
				using (IDbCommand command = connection.CreateCommand())
				{
					command.CommandText = sp_name;
					command.CommandType = CommandType.StoredProcedure;

					RepositoryHelper<T>.CreateDbDataParameters(command, parameters);
					IDataReader reader = command.ExecuteReader();
					ICollection<T2> results = new List<T2>();

					while (reader.Read())
						results.Add(converter(reader));

					reader.Close();

					return results;
				}
			}
			finally
			{
				connectionProvider.CloseConnection(connection);
			}
		}


		/// <summary>
		/// Check if any instance matches the criteria.
		/// </summary>
		/// <returns><c>true</c> if an instance is found; otherwise <c>false</c>.</returns>
		public bool Exists(DetachedCriteria criteria)
		{
			return 0 != Count(criteria);
		}

		/// <summary>
		/// Check if any instance of the type exists
		/// </summary>
		/// <returns><c>true</c> if an instance is found; otherwise <c>false</c>.</returns>
		public bool Exists()
		{
			return Exists(null);
		}

		/// <summary>
		/// Counts the number of instances matching the criteria.
		/// </summary>
		/// <param name="criteria"></param>
		/// <returns></returns>
		public long Count(DetachedCriteria criteria)
		{
			ICriteria crit = RepositoryHelper<T>.GetExecutableCriteria(Session, criteria, null);
        		crit.SetProjection(Projections.RowCount());
	        	object countMayBe_Int32_Or_Int64_DependingOnDatabase = crit.UniqueResult();
			return Convert.ToInt64(countMayBe_Int32_Or_Int64_DependingOnDatabase);
		}

		/// <summary>
		/// Counts the overall number of instances.
		/// </summary>
		/// <returns></returns>
		public long Count()
		{
			return Count(null);
		}
	}
}