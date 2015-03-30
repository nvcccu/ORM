using System;
using DAO.Enums;
using DAO.Extensions;

namespace DAO.Filters.Where {
    public class FilterWhereDate : FilterWhere {
        private DateTime Value { get; set; }
        public FilterWhereDate(Enum field, PredicateCondition oper, DateTime value) {
            Field = field;
            Oper = oper;
            Value = value;
            StringFormat = "{0}.{1} {2} '{3}' ";
        }
        private string ValueToString() {
            return String.Format("{0:yyyy-MM-dd HH:mm:ss}", Value);
        }
        public override string TranslateToSql() {
            return String.Format(StringFormat, Field.GetType().DeclaringType.Name, Field, Oper.GetMathOper(),
                ValueToString());
        }
    }
}