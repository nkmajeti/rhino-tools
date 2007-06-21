//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Query {
    
    
    public partial class Where {
        
        /// <summary>
        /// Query helper for member Where.User
        /// </summary>
        public static Root_Query_User User {
            get {
                return new Root_Query_User();
            }
        }
        
        /// <summary>
        /// Query helper for member Where.Query_User
        /// </summary>
        public partial class Query_User<T1> : QueryBuilder<T1>
         {
            
            /// <summary>
            /// Query helper for member Query_User..ctor
            /// </summary>
            public Query_User(QueryBuilder<T1> parent, string name, string associationPath) : 
                    base(parent, name, associationPath) {
            }
            
            /// <summary>
            /// Query helper for member Query_User..ctor
            /// </summary>
            public Query_User(QueryBuilder<T1> parent, string name, string associationPath, bool backTrackAssociationOnEquality) : 
                    base(parent, name, associationPath, backTrackAssociationOnEquality) {
            }
            
            /// <summary>
            /// Query helper for member Query_User.
            /// </summary>
            public virtual PropertyQueryBuilder<T1> Name {
                get {
                    string temp = associationPath;
                    return new PropertyQueryBuilder<T1>(this, "Name", temp);
                }
            }
            
            /// <summary>
            /// Query helper for member Query_User.
            /// </summary>
            public virtual PropertyQueryBuilder<T1> Email {
                get {
                    string temp = associationPath;
                    return new PropertyQueryBuilder<T1>(this, "Email", temp);
                }
            }
            
            /// <summary>
            /// Query helper for member Query_User.
            /// </summary>
            public virtual QueryBuilder<T1> Id {
                get {
                    string temp = associationPath;
                    return new QueryBuilder<T1>(this, "Id", temp);
                }
            }
            
            public virtual Query_Collection_Blogs Blogs {
                get {
                    string temp = associationPath;
                    temp = (temp + ".Blogs");
                    return new Query_Collection_Blogs(this, "Blogs", temp);
                }
            }
            
            public virtual Query_Collection_Roles Roles {
                get {
                    string temp = associationPath;
                    temp = (temp + ".Roles");
                    return new Query_Collection_Roles(this, "Roles", temp);
                }
            }
            
            public class Query_Collection_Blogs : CollectionQueryBuilder<T1> {
                
                public Query_Collection_Blogs(QueryBuilder<T1> parent, string name, string associationPath) : 
                        base(parent, name, associationPath) {
                }
                
                public virtual Query_Blog<T1> With() {
                    Query_Blog<T1> query = new Query_Blog<T1>(this, this.myName, this.associationPath);
                    query.joinType = NHibernate.SqlCommand.JoinType.InnerJoin;
                    query.fetchMode = NHibernate.FetchMode.Default;
                    return query;
                }
                
                public virtual Query_Blog<T1> With(NHibernate.SqlCommand.JoinType joinType) {
                    Query_Blog<T1> query = new Query_Blog<T1>(this, this.myName, this.associationPath);
                    query.joinType = joinType;
                    query.fetchMode = NHibernate.FetchMode.Default;
                    return query;
                }
                
                public virtual Query_Blog<T1> With(NHibernate.FetchMode fetchMode) {
                    Query_Blog<T1> query = new Query_Blog<T1>(this, this.myName, this.associationPath);
                    query.joinType = NHibernate.SqlCommand.JoinType.InnerJoin;
                    query.fetchMode = fetchMode;
                    return query;
                }
                
                public virtual Query_Blog<T1> With(NHibernate.SqlCommand.JoinType joinType, NHibernate.FetchMode fetchMode) {
                    Query_Blog<T1> query = new Query_Blog<T1>(this, this.myName, this.associationPath);
                    query.joinType = joinType;
                    query.fetchMode = fetchMode;
                    return query;
                }
            }
            
            public class Query_Collection_Roles : CollectionQueryBuilder<T1> {
                
                public Query_Collection_Roles(QueryBuilder<T1> parent, string name, string associationPath) : 
                        base(parent, name, associationPath) {
                }
                
                public virtual Query_Role<T1> With() {
                    Query_Role<T1> query = new Query_Role<T1>(this, this.myName, this.associationPath);
                    query.joinType = NHibernate.SqlCommand.JoinType.InnerJoin;
                    query.fetchMode = NHibernate.FetchMode.Default;
                    return query;
                }
                
                public virtual Query_Role<T1> With(NHibernate.SqlCommand.JoinType joinType) {
                    Query_Role<T1> query = new Query_Role<T1>(this, this.myName, this.associationPath);
                    query.joinType = joinType;
                    query.fetchMode = NHibernate.FetchMode.Default;
                    return query;
                }
                
                public virtual Query_Role<T1> With(NHibernate.FetchMode fetchMode) {
                    Query_Role<T1> query = new Query_Role<T1>(this, this.myName, this.associationPath);
                    query.joinType = NHibernate.SqlCommand.JoinType.InnerJoin;
                    query.fetchMode = fetchMode;
                    return query;
                }
                
                public virtual Query_Role<T1> With(NHibernate.SqlCommand.JoinType joinType, NHibernate.FetchMode fetchMode) {
                    Query_Role<T1> query = new Query_Role<T1>(this, this.myName, this.associationPath);
                    query.joinType = joinType;
                    query.fetchMode = fetchMode;
                    return query;
                }
            }
        }
        
        /// <summary>
        /// Query helper for member Where.Root_Query_User
        /// </summary>
        public partial class Root_Query_User : Query_User<NHibernate.Query.Generator.Tests.ActiveRecord.User> {
            
            /// <summary>
            /// Query helper for member Root_Query_User..ctor
            /// </summary>
            public Root_Query_User() : 
                    base(null, "this", null) {
            }
        }
    }
    
    public partial class OrderBy {
        
        /// <summary>
        /// Query helper for member OrderBy.User
        /// </summary>
        public partial class User {
            
            /// <summary>
            /// Query helper for member User.Name
            /// </summary>
            public static OrderByClause Name {
                get {
                    return new OrderByClause("Name");
                }
            }
            
            /// <summary>
            /// Query helper for member User.Email
            /// </summary>
            public static OrderByClause Email {
                get {
                    return new OrderByClause("Email");
                }
            }
            
            /// <summary>
            /// Query helper for member User.Id
            /// </summary>
            public static OrderByClause Id {
                get {
                    return new OrderByClause("Id");
                }
            }
        }
    }
    
    public partial class ProjectBy {
        
        /// <summary>
        /// Query helper for member ProjectBy.User
        /// </summary>
        public partial class User {
            
            /// <summary>
            /// Query helper for member User.Name
            /// </summary>
            public static PropertyProjectionBuilder Name {
                get {
                    return new PropertyProjectionBuilder("Name");
                }
            }
            
            /// <summary>
            /// Query helper for member User.Email
            /// </summary>
            public static PropertyProjectionBuilder Email {
                get {
                    return new PropertyProjectionBuilder("Email");
                }
            }
            
            /// <summary>
            /// Query helper for member User.Id
            /// </summary>
            public static NumericPropertyProjectionBuilder Id {
                get {
                    return new NumericPropertyProjectionBuilder("Id");
                }
            }
        }
    }
    
    public partial class GroupBy {
        
        /// <summary>
        /// Query helper for member GroupBy.User
        /// </summary>
        public partial class User {
            
            /// <summary>
            /// Query helper for member User.Name
            /// </summary>
            public static NHibernate.Expression.IProjection Name {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Name");
                }
            }
            
            /// <summary>
            /// Query helper for member User.Email
            /// </summary>
            public static NHibernate.Expression.IProjection Email {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Email");
                }
            }
        }
    }
}