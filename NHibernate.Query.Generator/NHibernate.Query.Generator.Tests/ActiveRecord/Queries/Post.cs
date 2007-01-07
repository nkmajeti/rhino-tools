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
        
        static Root_Query_Post _root_query_Post = new Root_Query_Post();
        
        public static Root_Query_Post Post {
            get {
                return _root_query_Post;
            }
        }
        
        public partial class Query_Post<T1> : Query.QueryBuilder<T1>
         {
            
            public Query_Post(string name, string associationPath) : 
                    base(name, associationPath) {
            }
            
            public Query_Post(string name, string associationPath, bool backTrackAssociationOnEquality) : 
                    base(name, associationPath, backTrackAssociationOnEquality) {
            }
            
            public virtual Query.PropertyQueryBuilder<T1> Title {
                get {
                    string temp = associationPath;
                    return new Query.PropertyQueryBuilder<T1>("Title", temp);
                }
            }
            
            public virtual Query.PropertyQueryBuilder<T1> Contnet {
                get {
                    string temp = associationPath;
                    return new Query.PropertyQueryBuilder<T1>("Contnet", temp);
                }
            }
            
            public virtual Query.QueryBuilder<T1> Id {
                get {
                    string temp = associationPath;
                    return new Query.QueryBuilder<T1>("Id", temp);
                }
            }
            
            public virtual Query_Blog<T1> Blog {
                get {
                    string temp = associationPath;
                    temp = ((temp + ".") 
                                + "Blog");
                    return new Query_Blog<T1>("Blog", temp, true);
                }
            }
        }
        
        public partial class Root_Query_Post : Query_Post<NHibernate.Query.Generator.Tests.ActiveRecord.Post> {
            
            public Root_Query_Post() : 
                    base("this", null) {
            }
        }
    }
    
    public partial class OrderBy {
        
        public partial class Post {
            
            public static Query.OrderByClause Title {
                get {
                    return new Query.OrderByClause("Title");
                }
            }
            
            public static Query.OrderByClause Contnet {
                get {
                    return new Query.OrderByClause("Contnet");
                }
            }
        }
    }
    
    public partial class ProjectBy {
        
        public partial class Post {
            
            public static Query.PropertyProjectionBuilder Title {
                get {
                    return new Query.PropertyProjectionBuilder("Title");
                }
            }
            
            public static Query.PropertyProjectionBuilder Contnet {
                get {
                    return new Query.PropertyProjectionBuilder("Contnet");
                }
            }
        }
    }
    
    public partial class GroupBy {
        
        public partial class Post {
            
            public static NHibernate.Expression.IProjection Title {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Title");
                }
            }
            
            public static NHibernate.Expression.IProjection Contnet {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Contnet");
                }
            }
        }
    }
}
