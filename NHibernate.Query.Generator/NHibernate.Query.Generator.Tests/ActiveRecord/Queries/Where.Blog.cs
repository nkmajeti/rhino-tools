//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.312
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Query {
    
    
    public partial class Where {
        
        /// <summary>
        /// Query helper for member Where.Blog
        /// </summary>
        public static Root_Query_Blog Blog {
            get {
                return new Root_Query_Blog();
            }
        }
        
        /// <summary>
        /// Query helper for member Where.Query_Blog
        /// </summary>
        public partial class Query_Blog<T1> : QueryBuilder<T1>
         {
            
            /// <summary>
            /// Query helper for member Query_Blog..ctor
            /// </summary>
            public Query_Blog(string name, string associationPath) : 
                    base(name, associationPath) {
            }
            
            /// <summary>
            /// Query helper for member Query_Blog..ctor
            /// </summary>
            public Query_Blog(string name, string associationPath, bool backTrackAssociationOnEquality) : 
                    base(name, associationPath, backTrackAssociationOnEquality) {
            }
            
            /// <summary>
            /// Query helper for member Query_Blog.
            /// </summary>
            public virtual PropertyQueryBuilder<T1> Name {
                get {
                    string temp = associationPath;
                    return new PropertyQueryBuilder<T1>("Name", temp);
                }
            }
            
            /// <summary>
            /// Query helper for member Query_Blog.
            /// </summary>
            public virtual QueryBuilder<T1> Id {
                get {
                    string temp = associationPath;
                    return new QueryBuilder<T1>("Id", temp);
                }
            }
            
            /// <summary>
            /// Query helper for member Query_Blog.
            /// </summary>
            public virtual Query_User<T1> Author {
                get {
                    string temp = associationPath;
                    temp = ((temp + ".") 
                                + "Author");
                    return new Query_User<T1>("Author", temp, true);
                }
            }
            
            public virtual CollectionQueryBuilder<T1> Posts {
                get {
                    string temp = associationPath;
                    return new CollectionQueryBuilder<T1>("Posts", temp);
                }
            }
        }
        
        /// <summary>
        /// Query helper for member Where.Root_Query_Blog
        /// </summary>
        public partial class Root_Query_Blog : Query_Blog<NHibernate.Query.Generator.Tests.ActiveRecord.Blog> {
            
            /// <summary>
            /// Query helper for member Root_Query_Blog..ctor
            /// </summary>
            public Root_Query_Blog() : 
                    base("this", null) {
            }
        }
    }
    
    public partial class OrderBy {
        
        /// <summary>
        /// Query helper for member OrderBy.Blog
        /// </summary>
        public partial class Blog {
            
            /// <summary>
            /// Query helper for member Blog.Name
            /// </summary>
            public static OrderByClause Name {
                get {
                    return new OrderByClause("Name");
                }
            }
            
            /// <summary>
            /// Query helper for member Blog.Id
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
        /// Query helper for member ProjectBy.Blog
        /// </summary>
        public partial class Blog {
            
            /// <summary>
            /// Query helper for member Blog.Name
            /// </summary>
            public static PropertyProjectionBuilder Name {
                get {
                    return new PropertyProjectionBuilder("Name");
                }
            }
            
            /// <summary>
            /// Query helper for member Blog.Id
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
        /// Query helper for member GroupBy.Blog
        /// </summary>
        public partial class Blog {
            
            /// <summary>
            /// Query helper for member Blog.Name
            /// </summary>
            public static NHibernate.Expression.IProjection Name {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Name");
                }
            }
        }
    }
}
