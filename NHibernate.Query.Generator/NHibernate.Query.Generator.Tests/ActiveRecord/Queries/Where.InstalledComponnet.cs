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
        /// Query helper for member Where.InstalledComponnet
        /// </summary>
        public static Root_Query_InstalledComponnet InstalledComponnet {
            get {
                return new Root_Query_InstalledComponnet();
            }
        }
        
        /// <summary>
        /// Query helper for member Where.Query_InstalledComponnet
        /// </summary>
        public partial class Query_InstalledComponnet<T1> : QueryBuilder<T1>
         {
            
            /// <summary>
            /// Query helper for member Query_InstalledComponnet..ctor
            /// </summary>
            public Query_InstalledComponnet(string name, string associationPath) : 
                    base(name, associationPath) {
            }
            
            /// <summary>
            /// Query helper for member Query_InstalledComponnet..ctor
            /// </summary>
            public Query_InstalledComponnet(string name, string associationPath, bool backTrackAssociationOnEquality) : 
                    base(name, associationPath, backTrackAssociationOnEquality) {
            }
            
            /// <summary>
            /// Query helper for member Query_InstalledComponnet.
            /// </summary>
            public virtual QueryBuilder<T1> Id {
                get {
                    string temp = associationPath;
                    return new QueryBuilder<T1>("Id", temp);
                }
            }
            
            /// <summary>
            /// Query helper for member Query_InstalledComponnet.
            /// </summary>
            public virtual Query_Componnet<T1> Component {
                get {
                    string temp = associationPath;
                    temp = ((temp + ".") 
                                + "Component");
                    return new Query_Componnet<T1>("Component", temp, true);
                }
            }
        }
        
        /// <summary>
        /// Query helper for member Where.Root_Query_InstalledComponnet
        /// </summary>
        public partial class Root_Query_InstalledComponnet : Query_InstalledComponnet<NHibernate.Query.Generator.Tests.ActiveRecord.InstalledComponnet> {
            
            /// <summary>
            /// Query helper for member Root_Query_InstalledComponnet..ctor
            /// </summary>
            public Root_Query_InstalledComponnet() : 
                    base("this", null) {
            }
        }
    }
    
    public partial class OrderBy {
        
        /// <summary>
        /// Query helper for member OrderBy.InstalledComponnet
        /// </summary>
        public partial class InstalledComponnet {
            
            /// <summary>
            /// Query helper for member InstalledComponnet.Id
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
        /// Query helper for member ProjectBy.InstalledComponnet
        /// </summary>
        public partial class InstalledComponnet {
            
            /// <summary>
            /// Query helper for member InstalledComponnet.Id
            /// </summary>
            public static NumericPropertyProjectionBuilder Id {
                get {
                    return new NumericPropertyProjectionBuilder("Id");
                }
            }
        }
    }
    
    public partial class GroupBy {
    }
}
