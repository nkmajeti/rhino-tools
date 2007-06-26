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
        
        static Root_Query_Category _root_query_Category = new Root_Query_Category();
        
        public static Root_Query_Category Category {
            get {
                return _root_query_Category;
            }
        }
        
        public partial class Query_Category<T1> : Query.QueryBuilder<T1>
         {
            
            public Query_Category(string name, string assoicationPath) : 
                    base(name, assoicationPath) {
            }
            
            public Query_Category(string name, string assoicationPath, bool backTrackAssoicationOnEquality) : 
                    base(name, assoicationPath, backTrackAssoicationOnEquality) {
            }
            
            public virtual Query.PropertyQueryBuilder<T1> Name {
                get {
                    string temp = assoicationPath;
                    return new Query.PropertyQueryBuilder<T1>("Name", temp);
                }
            }
            
            public virtual Query.QueryBuilder<T1> CategoryId {
                get {
                    string temp = assoicationPath;
                    return new Query.QueryBuilder<T1>("CategoryId", temp);
                }
            }
        }
        
        public partial class Root_Query_Category : Query_Category<Model.Category> {
            
            public Root_Query_Category() : 
                    base("this", null) {
            }
        }
    }
    
    public partial class OrderBy {
        
        public partial class Category {
            
            public static Query.OrderByClause Name {
                get {
                    return new Query.OrderByClause("Name");
                }
            }
        }
    }
    
    public partial class ProjectBy {
        
        public partial class Category {
            
            public static Query.PropertyProjectionBuilder Name {
                get {
                    return new Query.PropertyProjectionBuilder("Name");
                }
            }
        }
    }
    
    public partial class GroupBy {
        
        public partial class Category {
            
            public static NHibernate.Expression.IProjection Name {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Name");
                }
            }
        }
    }
}