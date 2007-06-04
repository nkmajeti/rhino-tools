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
        /// Query helper for member Where.Comment
        /// </summary>
        public static Root_Query_Comment Comment {
            get {
                return new Root_Query_Comment();
            }
        }
        
        /// <summary>
        /// Query helper for member Where.Query_Comment
        /// </summary>
        public partial class Query_Comment<T1> : QueryBuilder<T1>
         {
            
            /// <summary>
            /// Query helper for member Query_Comment..ctor
            /// </summary>
            public Query_Comment(string name, string associationPath) : 
                    base(name, associationPath) {
            }
            
            /// <summary>
            /// Query helper for member Query_Comment..ctor
            /// </summary>
            public Query_Comment(string name, string associationPath, bool backTrackAssociationOnEquality) : 
                    base(name, associationPath, backTrackAssociationOnEquality) {
            }
            
            /// <summary>
            /// Query helper for member Query_Comment.
            /// </summary>
            public virtual PropertyQueryBuilder<T1> Author {
                get {
                    string temp = associationPath;
                    return new PropertyQueryBuilder<T1>("Author", temp);
                }
            }
            
            /// <summary>
            /// Query helper for member Query_Comment.
            /// </summary>
            public virtual PropertyQueryBuilder<T1> Content {
                get {
                    string temp = associationPath;
                    return new PropertyQueryBuilder<T1>("Content", temp);
                }
            }
            
            /// <summary>
            /// Query helper for member Query_Comment.
            /// </summary>
            public virtual QueryBuilder<T1> Id {
                get {
                    string temp = associationPath;
                    return new QueryBuilder<T1>("Id", temp);
                }
            }
            
            /// <summary>
            /// Query helper for member Query_Comment.
            /// </summary>
            public virtual Query_Post<T1> Post {
                get {
                    string temp = associationPath;
                    temp = ((temp + ".") 
                                + "Post");
                    return new Query_Post<T1>("Post", temp, true);
                }
            }
        }
        
        /// <summary>
        /// Query helper for member Where.Root_Query_Comment
        /// </summary>
        public partial class Root_Query_Comment : Query_Comment<NHibernate.Query.Generator.Tests.ActiveRecord.Comment> {
            
            /// <summary>
            /// Query helper for member Root_Query_Comment..ctor
            /// </summary>
            public Root_Query_Comment() : 
                    base("this", null) {
            }
        }
    }
    
    public partial class OrderBy {
        
        /// <summary>
        /// Query helper for member OrderBy.Comment
        /// </summary>
        public partial class Comment {
            
            /// <summary>
            /// Query helper for member Comment.Author
            /// </summary>
            public static OrderByClause Author {
                get {
                    return new OrderByClause("Author");
                }
            }
            
            /// <summary>
            /// Query helper for member Comment.Content
            /// </summary>
            public static OrderByClause Content {
                get {
                    return new OrderByClause("Content");
                }
            }
            
            /// <summary>
            /// Query helper for member Comment.Id
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
        /// Query helper for member ProjectBy.Comment
        /// </summary>
        public partial class Comment {
            
            /// <summary>
            /// Query helper for member Comment.Author
            /// </summary>
            public static PropertyProjectionBuilder Author {
                get {
                    return new PropertyProjectionBuilder("Author");
                }
            }
            
            /// <summary>
            /// Query helper for member Comment.Content
            /// </summary>
            public static PropertyProjectionBuilder Content {
                get {
                    return new PropertyProjectionBuilder("Content");
                }
            }
            
            /// <summary>
            /// Query helper for member Comment.Id
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
        /// Query helper for member GroupBy.Comment
        /// </summary>
        public partial class Comment {
            
            /// <summary>
            /// Query helper for member Comment.Author
            /// </summary>
            public static NHibernate.Expression.IProjection Author {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Author");
                }
            }
            
            /// <summary>
            /// Query helper for member Comment.Content
            /// </summary>
            public static NHibernate.Expression.IProjection Content {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Content");
                }
            }
        }
    }
}
