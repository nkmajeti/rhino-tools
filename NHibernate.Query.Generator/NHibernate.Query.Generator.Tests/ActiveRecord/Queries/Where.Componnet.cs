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
        /// Query helper for member Where.Componnet
        /// </summary>
        public static Root_Query_Componnet Componnet {
            get {
                return new Root_Query_Componnet();
            }
        }
        
        /// <summary>
        /// Query helper for member Where.Query_Componnet
        /// </summary>
        public partial class Query_Componnet<T1> : QueryBuilder<T1>
         {
            
            /// <summary>
            /// Query helper for member Query_Componnet..ctor
            /// </summary>
            public Query_Componnet(QueryBuilder<T1> parent, string name, string associationPath) : 
                    base(parent, name, associationPath) {
            }
            
            /// <summary>
            /// Query helper for member Query_Componnet..ctor
            /// </summary>
            public Query_Componnet(QueryBuilder<T1> parent, string name, string associationPath, bool backTrackAssociationOnEquality) : 
                    base(parent, name, associationPath, backTrackAssociationOnEquality) {
            }
            
            /// <summary>
            /// Query helper for member Query_Componnet.
            /// </summary>
            public virtual PropertyQueryBuilder<T1> Version {
                get {
                    string temp = associationPath;
                    return new PropertyQueryBuilder<T1>(this, "Version", temp);
                }
            }
            
            /// <summary>
            /// Query helper for member Query_Componnet.
            /// </summary>
            public virtual QueryBuilder<T1> Id {
                get {
                    string temp = associationPath;
                    return new QueryBuilder<T1>(this, "Id", temp);
                }
            }
        }
        
        /// <summary>
        /// Query helper for member Where.Root_Query_Componnet
        /// </summary>
        public partial class Root_Query_Componnet : Query_Componnet<NHibernate.Query.Generator.Tests.ActiveRecord.Componnet> {
            
            /// <summary>
            /// Query helper for member Root_Query_Componnet..ctor
            /// </summary>
            public Root_Query_Componnet() : 
                    base(null, "this", null) {
            }
        }
    }
    
    public partial class OrderBy {
        
        /// <summary>
        /// Query helper for member OrderBy.Componnet
        /// </summary>
        public partial class Componnet {
            
            /// <summary>
            /// Query helper for member Componnet.Version
            /// </summary>
            public static OrderByClause Version {
                get {
                    return new OrderByClause("Version");
                }
            }
            
            /// <summary>
            /// Query helper for member Componnet.Id
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
        /// Query helper for member ProjectBy.Componnet
        /// </summary>
        public partial class Componnet {
            
            /// <summary>
            /// Query helper for member Componnet.Version
            /// </summary>
            public static PropertyProjectionBuilder Version {
                get {
                    return new PropertyProjectionBuilder("Version");
                }
            }
            
            /// <summary>
            /// Query helper for member Componnet.Id
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
        /// Query helper for member GroupBy.Componnet
        /// </summary>
        public partial class Componnet {
            
            /// <summary>
            /// Query helper for member Componnet.Version
            /// </summary>
            public static NHibernate.Expression.IProjection Version {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Version");
                }
            }
        }
    }
}