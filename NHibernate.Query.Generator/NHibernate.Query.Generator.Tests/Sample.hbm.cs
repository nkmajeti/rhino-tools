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
        
        static Root_Query_Customer _root_query_Customer = new Root_Query_Customer();
        
        static Root_Query_Address _root_query_Address = new Root_Query_Address();
        
        static Root_Query_CompositeCustomer _root_query_CompositeCustomer = new Root_Query_CompositeCustomer();
        
        static Root_Query_BadCustomer _root_query_BadCustomer = new Root_Query_BadCustomer();
        
        static Root_Query_BadCustomer2 _root_query_BadCustomer2 = new Root_Query_BadCustomer2();
        
        static Root_Query_ValuedCustomer _root_query_ValuedCustomer = new Root_Query_ValuedCustomer();
        
        static Root_Query_ValuedCustomer2 _root_query_ValuedCustomer2 = new Root_Query_ValuedCustomer2();
        
        public static Root_Query_Customer Customer {
            get {
                return _root_query_Customer;
            }
        }
        
        public static Root_Query_Address Address {
            get {
                return _root_query_Address;
            }
        }
        
        public static Root_Query_CompositeCustomer CompositeCustomer {
            get {
                return _root_query_CompositeCustomer;
            }
        }
        
        public static Root_Query_BadCustomer BadCustomer {
            get {
                return _root_query_BadCustomer;
            }
        }
        
        public static Root_Query_BadCustomer2 BadCustomer2 {
            get {
                return _root_query_BadCustomer2;
            }
        }
        
        public static Root_Query_ValuedCustomer ValuedCustomer {
            get {
                return _root_query_ValuedCustomer;
            }
        }
        
        public static Root_Query_ValuedCustomer2 ValuedCustomer2 {
            get {
                return _root_query_ValuedCustomer2;
            }
        }
        
        public partial class Query_Customer<T1> : Query.QueryBuilder<T1>
         {
            
            public Query_Customer(string name, string associationPath) : 
                    base(name, associationPath) {
            }
            
            public Query_Customer(string name, string associationPath, bool backTrackAssociationOnEquality) : 
                    base(name, associationPath, backTrackAssociationOnEquality) {
            }
            
            public virtual Query.PropertyQueryBuilder<T1> Name {
                get {
                    string temp = associationPath;
                    return new Query.PropertyQueryBuilder<T1>("Name", temp);
                }
            }
            
            public virtual Query.QueryBuilder<T1> Id {
                get {
                    string temp = associationPath;
                    return new Query.QueryBuilder<T1>("Id", temp);
                }
            }
            
            public virtual Query_Address<T1> Address {
                get {
                    string temp = associationPath;
                    temp = ((temp + ".") 
                                + "Address");
                    return new Query_Address<T1>("Address", temp, true);
                }
            }
            
            public virtual Query_Home<T1> Home {
                get {
                    return new Query_Home<T1>("Home", null);
                }
            }
            
            public partial class Query_Home<T2> : Query.QueryBuilder<T2>
             {
                
                public Query_Home(string name, string associationPath) : 
                        base(name, associationPath) {
                }
                
                public Query_Home(string name, string associationPath, bool backTrackAssociationOnEquality) : 
                        base(name, associationPath, backTrackAssociationOnEquality) {
                }
                
                public virtual Query.PropertyQueryBuilder<T1> Phone {
                    get {
                        string temp = associationPath;
                        return new Query.PropertyQueryBuilder<T1>("Home.Phone", temp);
                    }
                }
                
                public virtual Query_Address<T1> Address {
                    get {
                        string temp = associationPath;
                        temp = ((temp + ".") 
                                    + "Address");
                        return new Query_Address<T1>("Home.Address", temp, true);
                    }
                }
            }
        }
        
        public partial class Root_Query_Customer : Query_Customer<My.Simple.Model.Customer> {
            
            public Root_Query_Customer() : 
                    base("this", null) {
            }
        }
        
        public partial class Query_Address<T3> : Query.QueryBuilder<T3>
         {
            
            public Query_Address(string name, string associationPath) : 
                    base(name, associationPath) {
            }
            
            public Query_Address(string name, string associationPath, bool backTrackAssociationOnEquality) : 
                    base(name, associationPath, backTrackAssociationOnEquality) {
            }
            
            public virtual Query.QueryBuilder<T3> Pk {
                get {
                    string temp = associationPath;
                    return new Query.QueryBuilder<T3>("Pk", temp);
                }
            }
        }
        
        public partial class Root_Query_Address : Query_Address<My.Simple.Model.Address> {
            
            public Root_Query_Address() : 
                    base("this", null) {
            }
        }
        
        public partial class Query_CompositeCustomer<T4> : Query.QueryBuilder<T4>
         {
            
            public Query_CompositeCustomer(string name, string associationPath) : 
                    base(name, associationPath) {
            }
            
            public Query_CompositeCustomer(string name, string associationPath, bool backTrackAssociationOnEquality) : 
                    base(name, associationPath, backTrackAssociationOnEquality) {
            }
            
            public virtual Query.PropertyQueryBuilder<T4> Name {
                get {
                    string temp = associationPath;
                    return new Query.PropertyQueryBuilder<T4>("Name", temp);
                }
            }
            
            public virtual Query.PropertyQueryBuilder<T4> CustomerId {
                get {
                    string temp = associationPath;
                    return new Query.PropertyQueryBuilder<T4>("CustomerId", temp);
                }
            }
            
            public virtual Query_BadCustomer<T4> Foo {
                get {
                    string temp = associationPath;
                    temp = ((temp + ".") 
                                + "Foo");
                    return new Query_BadCustomer<T4>("Foo", temp, true);
                }
            }
        }
        
        public partial class Root_Query_CompositeCustomer : Query_CompositeCustomer<My.Simple.Model.CompositeCustomer> {
            
            public Root_Query_CompositeCustomer() : 
                    base("this", null) {
            }
        }
        
        public partial class Query_BadCustomer<T5> : Query_Customer<T5>
         {
            
            public Query_BadCustomer(string name, string associationPath) : 
                    base(name, associationPath) {
            }
            
            public Query_BadCustomer(string name, string associationPath, bool backTrackAssociationOnEquality) : 
                    base(name, associationPath, backTrackAssociationOnEquality) {
            }
            
            public virtual Query.PropertyQueryBuilder<T5> Foo {
                get {
                    string temp = associationPath;
                    return new Query.PropertyQueryBuilder<T5>("Foo", temp);
                }
            }
        }
        
        public partial class Root_Query_BadCustomer : Query_BadCustomer<My.Simple.Model.BadCustomer> {
            
            public Root_Query_BadCustomer() : 
                    base("this", null) {
            }
        }
        
        public partial class Query_BadCustomer2<T6> : Query.QueryBuilder<T6>
         {
            
            public Query_BadCustomer2(string name, string associationPath) : 
                    base(name, associationPath) {
            }
            
            public Query_BadCustomer2(string name, string associationPath, bool backTrackAssociationOnEquality) : 
                    base(name, associationPath, backTrackAssociationOnEquality) {
            }
            
            public virtual Query.PropertyQueryBuilder<T6> Foo {
                get {
                    string temp = associationPath;
                    return new Query.PropertyQueryBuilder<T6>("Foo", temp);
                }
            }
        }
        
        public partial class Root_Query_BadCustomer2 : Query_BadCustomer2<My.Simple.Model.BadCustomer2> {
            
            public Root_Query_BadCustomer2() : 
                    base("this", null) {
            }
        }
        
        public partial class Query_ValuedCustomer<T7> : Query_Customer<T7>
         {
            
            public Query_ValuedCustomer(string name, string associationPath) : 
                    base(name, associationPath) {
            }
            
            public Query_ValuedCustomer(string name, string associationPath, bool backTrackAssociationOnEquality) : 
                    base(name, associationPath, backTrackAssociationOnEquality) {
            }
            
            public virtual Query.PropertyQueryBuilder<T7> Bar {
                get {
                    string temp = associationPath;
                    return new Query.PropertyQueryBuilder<T7>("Bar", temp);
                }
            }
        }
        
        public partial class Root_Query_ValuedCustomer : Query_ValuedCustomer<My.Simple.Model.ValuedCustomer> {
            
            public Root_Query_ValuedCustomer() : 
                    base("this", null) {
            }
        }
        
        public partial class Query_ValuedCustomer2<T8> : Query.QueryBuilder<T8>
         {
            
            public Query_ValuedCustomer2(string name, string associationPath) : 
                    base(name, associationPath) {
            }
            
            public Query_ValuedCustomer2(string name, string associationPath, bool backTrackAssociationOnEquality) : 
                    base(name, associationPath, backTrackAssociationOnEquality) {
            }
            
            public virtual Query.PropertyQueryBuilder<T8> Bar {
                get {
                    string temp = associationPath;
                    return new Query.PropertyQueryBuilder<T8>("Bar", temp);
                }
            }
        }
        
        public partial class Root_Query_ValuedCustomer2 : Query_ValuedCustomer2<My.Simple.Model.ValuedCustomer2> {
            
            public Root_Query_ValuedCustomer2() : 
                    base("this", null) {
            }
        }
    }
    
    public partial class OrderBy {
        
        public partial class Customer {
            
            public static Query.OrderByClause Name {
                get {
                    return new Query.OrderByClause("Name");
                }
            }
            
            public partial class Home {
                
                public static Query.OrderByClause Phone {
                    get {
                        return new Query.OrderByClause("Home.Phone");
                    }
                }
            }
        }
        
        public partial class CompositeCustomer {
            
            public static Query.OrderByClause Name {
                get {
                    return new Query.OrderByClause("Name");
                }
            }
            
            public static Query.OrderByClause CustomerId {
                get {
                    return new Query.OrderByClause("dummy.CustomerId");
                }
            }
        }
        
        public partial class BadCustomer : Customer {
            
            public static Query.OrderByClause Foo {
                get {
                    return new Query.OrderByClause("Foo");
                }
            }
        }
        
        public partial class BadCustomer2 {
            
            public static Query.OrderByClause Foo {
                get {
                    return new Query.OrderByClause("Foo");
                }
            }
        }
        
        public partial class ValuedCustomer : Customer {
            
            public static Query.OrderByClause Bar {
                get {
                    return new Query.OrderByClause("Bar");
                }
            }
        }
        
        public partial class ValuedCustomer2 {
            
            public static Query.OrderByClause Bar {
                get {
                    return new Query.OrderByClause("Bar");
                }
            }
        }
    }
    
    public partial class Queries {
        
        public static string MyQuery {
            get {
                return "MyQuery";
            }
        }
    }
    
    public partial class Queries {
        
        public static string HerQuery {
            get {
                return "HerQuery";
            }
        }
    }
    
    public partial class ProjectBy {
        
        public partial class Customer {
            
            public static Query.PropertyProjectionBuilder Name {
                get {
                    return new Query.PropertyProjectionBuilder("Name");
                }
            }
            
            public partial class Home {
                
                public static Query.PropertyProjectionBuilder Phone {
                    get {
                        return new Query.PropertyProjectionBuilder("Home.Phone");
                    }
                }
            }
        }
        
        public partial class CompositeCustomer {
            
            public static Query.PropertyProjectionBuilder Name {
                get {
                    return new Query.PropertyProjectionBuilder("Name");
                }
            }
            
            public static Query.NumericPropertyProjectionBuilder CustomerId {
                get {
                    return new Query.NumericPropertyProjectionBuilder("dummy.CustomerId");
                }
            }
        }
        
        public partial class BadCustomer : Customer {
            
            public static Query.PropertyProjectionBuilder Foo {
                get {
                    return new Query.PropertyProjectionBuilder("Foo");
                }
            }
        }
        
        public partial class BadCustomer2 {
            
            public static Query.PropertyProjectionBuilder Foo {
                get {
                    return new Query.PropertyProjectionBuilder("Foo");
                }
            }
        }
        
        public partial class ValuedCustomer : Customer {
            
            public static Query.PropertyProjectionBuilder Bar {
                get {
                    return new Query.PropertyProjectionBuilder("Bar");
                }
            }
        }
        
        public partial class ValuedCustomer2 {
            
            public static Query.PropertyProjectionBuilder Bar {
                get {
                    return new Query.PropertyProjectionBuilder("Bar");
                }
            }
        }
    }
    
    public partial class GroupBy {
        
        public partial class Customer {
            
            public static NHibernate.Expression.IProjection Name {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Name");
                }
            }
            
            public partial class Home {
                
                public static NHibernate.Expression.IProjection Phone {
                    get {
                        return NHibernate.Expression.Projections.GroupProperty("Home.Phone");
                    }
                }
            }
        }
        
        public partial class CompositeCustomer {
            
            public static NHibernate.Expression.IProjection Name {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Name");
                }
            }
            
            public static NHibernate.Expression.IProjection CustomerId {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("dummy.CustomerId");
                }
            }
        }
        
        public partial class BadCustomer : Customer {
            
            public static NHibernate.Expression.IProjection Foo {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Foo");
                }
            }
        }
        
        public partial class BadCustomer2 {
            
            public static NHibernate.Expression.IProjection Foo {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Foo");
                }
            }
        }
        
        public partial class ValuedCustomer : Customer {
            
            public static NHibernate.Expression.IProjection Bar {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Bar");
                }
            }
        }
        
        public partial class ValuedCustomer2 {
            
            public static NHibernate.Expression.IProjection Bar {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Bar");
                }
            }
        }
    }
}
