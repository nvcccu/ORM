using System.Collections.Generic;
using DAO.Enums;

namespace DAO.Filters.Where {
    public abstract class FilterWhereCollectionBase {
        protected List<FilterWhereBase> FilterWhereCollection { get; set; }
        protected List<FilterWhereCollectionBase> FilterWhereCollectionCollection { get; set; }
        protected PredicateCondition Oper { get; set; }
        public abstract string TranslateToSql();
    }
}