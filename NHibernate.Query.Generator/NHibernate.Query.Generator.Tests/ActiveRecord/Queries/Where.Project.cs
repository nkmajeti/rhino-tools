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
        
        /// Query for member _root_query_Project
        static Root_Query_Project _root_query_Project = new Root_Query_Project();
        
        /// Query for member Project
        public static Root_Query_Project Project {
            get {
                return _root_query_Project;
            }
        }
        
        /// Query for member Query_Project
        public partial class Query_Project<T1> : Query.QueryBuilder<T1>
         {
            
            /// Query for member .ctor
            public Query_Project(string name, string associationPath) : 
                    base(name, associationPath) {
            }
            
            /// Query for member .ctor
            public Query_Project(string name, string associationPath, bool backTrackAssociationOnEquality) : 
                    base(name, associationPath, backTrackAssociationOnEquality) {
            }
            
            /// Query for member 
            public virtual Query.QueryBuilder<T1> Id {
                get {
                    string temp = associationPath;
                    return new Query.QueryBuilder<T1>("Id", temp);
                }
            }
            
            /// Query for member 
            public virtual Query_InstalledComponnet<T1> Componnet {
                get {
                    string temp = associationPath;
                    temp = ((temp + ".") 
                                + "Componnet");
                    return new Query_InstalledComponnet<T1>("Componnet", temp, true);
                }
            }
        }
        
        /// Query for member Root_Query_Project
        public partial class Root_Query_Project : Query_Project<NHibernate.Query.Generator.Tests.ActiveRecord.Project> {
            
            /// Query for member .ctor
            public Root_Query_Project() : 
                    base("this", null) {
            }
        }
    }
    
    public partial class OrderBy {
        
        /// Query for member Project
        public partial class Project {
            
            /// Query for member Id
            public static Query.OrderByClause Id {
                get {
                    return new Query.OrderByClause("Id");
                }
            }
        }
    }
    
    public partial class ProjectBy {
    }
    
    public partial class GroupBy {
    }
}