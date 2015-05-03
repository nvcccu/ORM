using System;
using System.Collections.Generic;
using DAO.Enums;

namespace DAO.Filters.Where {
    public abstract class FilterWhereBase {
        protected LogicOperator LogicOperator { get; set; }
        protected Enum Field { get; set; }
        protected PredicateCondition Oper { get; set; }
        protected string StringFormat;
        protected List<FilterWhereBase> NestedFilters { get; set; }
        public abstract string TranslateToSql();
    }
}