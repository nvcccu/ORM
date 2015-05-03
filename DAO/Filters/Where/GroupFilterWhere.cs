using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Enums;

namespace DAO.Filters.Where {
    public class GroupFilterWhere {
        List<FilterWhereBase> Filters { get; set; }

        public GroupFilterWhere(Enum field, PredicateCondition oper, string value) {
            Filters = new List<FilterWhereBase> {new FilterWhereBaseSimple(field, oper, value)};
        }
        public GroupFilterWhere(List<FilterWhereBase> filters) {
            Filters = filters;
        }

        public string TranslateToSql() {
            string result = null;
            if (Filters != null && Filters.Count > 0) {
                result = "(";
                result += Filters.First().TranslateToSql();
                for (var i = 1; i < Filters.Count; i++) {
                    result += "AND " + Filters[i].TranslateToSql();
                }
                result += ")";
            }
            return result;
        }
    }
}
