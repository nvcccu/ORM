﻿using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Enums;
using DAO.Extensions;

namespace DAO.Filters.Where {
    public class FilterWhereBaseEnumerableDateTime : FilterWhereBase {
        private IEnumerable<DateTime> Value { get; set; }
        public FilterWhereBaseEnumerableDateTime(Enum field, PredicateCondition oper, IEnumerable<DateTime> value) {
            Field = field;
            Oper = oper;
            Value = value;
            StringFormat = "{0}.{1} {2} {3} ";
        }
        private string ValueToString() {
            return "(" + String.Join(", ", Value.Select(v => String.Format("'{0:yyyy-MM-dd HH:mm:ss}'", v))) + ") ";
        }
        public override string TranslateToSql() {
            return String.Format(StringFormat, Field.GetType().DeclaringType.Name, Field, Oper.GetMathOper(),
                ValueToString());
        }
    }
}