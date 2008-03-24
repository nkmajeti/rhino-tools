﻿#region license
// Copyright (c) 2005 - 2007 Ayende Rahien (ayende@ayende.com)
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//     this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice,
//     this list of conditions and the following disclaimer in the documentation
//     and/or other materials provided with the distribution.
//     * Neither the name of Ayende Rahien nor the names of its
//     contributors may be used to endorse or promote products derived from this
//     software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
// THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion


using System;
using NHibernate;
using NHibernate.Criterion;

namespace Rhino.Commons
{
	public class NHRepository<T> : RepositoryImplBase<T>, IRepository<T>
	{
		protected virtual ISession Session
		{
            get { return UnitOfWork.CurrentSession; }
		}

		public T Get(object id)
		{
			return (T)Session.Get(ConcreteType, id);
		}

		public T Load(object id)
		{
			return (T)Session.Load(ConcreteType, id);
		}

		public void Delete(T entity)
		{
			Session.Delete(entity);
		}

		public void DeleteAll()
		{
			Session.Delete(String.Format("from {0}", ConcreteType.Name));
		}

		public void DeleteAll(DetachedCriteria where)
		{
            foreach (object entity in where.GetExecutableCriteria(Session).List())
            {
                Session.Delete(entity);
            }
		}

		public T Save(T entity)
		{
			Session.Save(entity);
			return entity;
		}

	    public T SaveOrUpdate(T entity)
	    {
	        Session.SaveOrUpdate(entity);
	    	return entity;
	    }

        public T SaveOrUpdateCopy(T entity)
        {
            return (T) Session.SaveOrUpdateCopy(entity);
        }

	    public void Update(T entity)
	    {
	        Session.Update(entity);
	    }

	    protected override ISessionFactory SessionFactory
	    {
	        get { return UnitOfWork.CurrentSession.GetSessionImplementation().Factory; }
	    }


	    protected override DisposableAction<ISession> ActionToBePerformedOnSessionUsedForDbFetches
        {
            get { return new DisposableAction<ISession>(delegate { ; }, Session); }
        }
	}
}
