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
        
        /// Query for member _root_query_User
        static Root_Query_User _root_query_User = new Root_Query_User();
        
        /// Query for member User
        public static Root_Query_User User {
            get {
                return _root_query_User;
            }
        }
        
        /// Query for member Query_User
        public partial class Query_User<T1> : Query.QueryBuilder<T1>
         {
            
            /// Query for member .ctor
            public Query_User(string name, string associationPath) : 
                    base(name, associationPath) {
            }
            
            /// Query for member .ctor
            public Query_User(string name, string associationPath, bool backTrackAssociationOnEquality) : 
                    base(name, associationPath, backTrackAssociationOnEquality) {
            }
            
            /// Query for member 
            public virtual Query.PropertyQueryBuilder<T1> Name {
                get {
                    string temp = associationPath;
                    return new Query.PropertyQueryBuilder<T1>("Name", temp);
                }
            }
            
            /// Query for member 
            public virtual Query.PropertyQueryBuilder<T1> Email {
                get {
                    string temp = associationPath;
                    return new Query.PropertyQueryBuilder<T1>("Email", temp);
                }
            }
            
            /// Query for member 
            public virtual Query.QueryBuilder<T1> Id {
                get {
                    string temp = associationPath;
                    return new Query.QueryBuilder<T1>("Id", temp);
                }
            }
        }
        
        /// Query for member Root_Query_User
        public partial class Root_Query_User : Query_User<NHibernate.Query.Generator.Tests.ActiveRecord.User> {
            
            /// Query for member .ctor
            public Root_Query_User() : 
                    base("this", null) {
            }
        }
    }
    
    public partial class OrderBy {
        
        /// Query for member User
        public partial class User {
            
            /// Query for member Name
            public static Query.OrderByClause Name {
                get {
                    return new Query.OrderByClause("Name");
                }
            }
            
            /// Query for member Email
            public static Query.OrderByClause Email {
                get {
                    return new Query.OrderByClause("Email");
                }
            }
            
            /// Query for member Id
            public static Query.OrderByClause Id {
                get {
                    return new Query.OrderByClause("Id");
                }
            }
        }
    }
    
    public partial class ProjectBy {
        
        /// Query for member User
        public partial class User {
            
            /// Query for member Name
            public static Query.PropertyProjectionBuilder Name {
                get {
                    return new Query.PropertyProjectionBuilder("Name");
                }
            }
            
            /// Query for member Email
            public static Query.PropertyProjectionBuilder Email {
                get {
                    return new Query.PropertyProjectionBuilder("Email");
                }
            }
        }
    }
    
    public partial class GroupBy {
        
        /// Query for member User
        public partial class User {
            
            /// Query for member Name
            public static NHibernate.Expression.IProjection Name {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Name");
                }
            }
            
            /// Query for member Email
            public static NHibernate.Expression.IProjection Email {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Email");
                }
            }
        }
    }
}