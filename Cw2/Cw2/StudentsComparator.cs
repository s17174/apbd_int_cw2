using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Cw2
{
    class StudentsComparator : IEqualityComparer<Student>
    {
        public bool Equals([AllowNull] Student x, [AllowNull] Student y)
        {
            return x.Name.Equals(y.Name) && x.Surname.Equals(y.Surname) && x.Id.Equals(y.Id);
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            return obj.Name.GetHashCode() + obj.Surname.GetHashCode() + obj.Id.GetHashCode();
        }
    }
}
