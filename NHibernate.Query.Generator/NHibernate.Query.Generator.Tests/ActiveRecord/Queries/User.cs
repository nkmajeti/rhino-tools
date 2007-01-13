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
        
        static Root_Query_User _root_query_User = new Root_Query_User();
        
        public static Root_Query_User User {
            get {
                return _root_query_User;
            }
        }
        
        public partial class Query_User<T1> : Query.QueryBuilder<T1>
         {
            
            public Query_User(string name, string associationPath) : 
                    base(name, associationPath) {
            }
            
            public Query_User(string name, string associationPath, bool backTrackAssoicationOnEquality) : 
                    base(name, associationPath, backTrackAssoicationOnEquality) {
            }
            
            public virtual Query.PropertyQueryBuilder<T1> Name {
                get {
                    string temp = associationPath;
                    return new Query.PropertyQueryBuilder<T1>("Name", temp);
                }
            }
            
            public virtual Query.PropertyQueryBuilder<T1> Email {
                get {
                    string temp = associationPath;
                    return new Query.PropertyQueryBuilder<T1>("Email", temp);
                }
            }
            
            public virtual Query.QueryBuilder<T1> Id {
                get {
                    string temp = associationPath;
                    return new Query.QueryBuilder<T1>("Id", temp);
                }
            }
        }
        
        public partial class Root_Query_User : Query_User<NHibernate.Query.Generator.Tests.ActiveRecord.User> {
            
            public Root_Query_User() : 
                    base("this", null) {
            }
        }
    }
    
    public partial class OrderBy {
        
        public partial class User {
            
            public static Query.OrderByClause Name {
                get {
                    return new Query.OrderByClause("Name");
                }
            }
            
            public static Query.OrderByClause Email {
                get {
                    return new Query.OrderByClause("Email");
                }
            }
        }
    }
    
    public partial class ProjectBy {
        
        public partial class User {
            
            public static Query.PropertyProjectionBuilder Name {
                get {
                    return new Query.PropertyProjectionBuilder("Name");
                }
            }
            
            public static Query.PropertyProjectionBuilder Email {
                get {
                    return new Query.PropertyProjectionBuilder("Email");
                }
            }
        }
    }
    
    public partial class GroupBy {
        
        public partial class User {
            
            public static NHibernate.Expression.IProjection Name {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Name");
                }
            }
            
            public static NHibernate.Expression.IProjection Email {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Email");
                }
            }
        }
    }
}