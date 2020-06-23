using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Base_Function.BASE_COMMON
{
    public class MBindingList<T> : BindingList<T>
    {
        private bool isSortedCore = true;
        private ListSortDirection sortDirectionCore = ListSortDirection.Ascending;
        private PropertyDescriptor sortPropertyCore = null;
        private string defaultSortItem;

        public MBindingList() : base() { }

        public MBindingList(IList<T> list) : base(list) { }

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }

        protected override bool IsSortedCore
        {
            get { return isSortedCore; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return sortDirectionCore; }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return sortPropertyCore; }
        }

        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (Equals(prop.GetValue(this[i]), key)) return i;
            }
            return -1;
        }

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            isSortedCore = true;
            sortPropertyCore = prop;
            sortDirectionCore = direction;
            Sort();
        }

        protected override void RemoveSortCore()
        {
            if (isSortedCore)
            {
                isSortedCore = false;
                sortPropertyCore = null;
                sortDirectionCore = ListSortDirection.Ascending;
                Sort();
            }
        }

        public string DefaultSortItem
        {
            get { return defaultSortItem; }
            set
            {
                if (defaultSortItem != value)
                {
                    defaultSortItem = value;
                    Sort();
                }
            }
        }

        private void Sort()
        {
            List<T> list = (this.Items as List<T>);
            list.Sort(CompareCore);
            ResetBindings();
        }

        private int CompareCore(T o1, T o2)
        {
            int ret = 0;
            if (SortPropertyCore != null)
            {
                if (SortPropertyCore.DisplayName == "Sick_Bed_Name"||SortPropertyCore.DisplayName=="床号")
                {
                    ret = CompareBedValue(SortPropertyCore.GetValue(o1), SortPropertyCore.GetValue(o2), SortPropertyCore.PropertyType);
                }
                else
                {
                    ret = CompareValue(SortPropertyCore.GetValue(o1), SortPropertyCore.GetValue(o2), SortPropertyCore.PropertyType);
                }
            }
            if (ret == 0 && DefaultSortItem != null)
            {
                PropertyInfo property = typeof(T).GetProperty(DefaultSortItem, BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.IgnoreCase, null, null, new Type[0], null);
                if (property != null)
                {
                    ret = CompareValue(property.GetValue(o1, null), property.GetValue(o2, null), property.PropertyType);
                }
            }
            if (SortDirectionCore == ListSortDirection.Descending) ret = -ret;
            return ret;
        }

        private static int CompareValue(object o1, object o2, Type type)
        {
            int itemp1 = 0;
            int itemp2 = 0;
            //这里改成自己定义的比较
            if (o1 == null) return o2 == null ? 0 : -1;
            else if (o2 == null) return 1;
            else if (type.IsPrimitive || type.IsEnum) return Convert.ToDouble(o1).CompareTo(Convert.ToDouble(o2));
            else if (type == typeof(DateTime)) return Convert.ToDateTime(o1).CompareTo(o2);
            else if (int.TryParse(o1.ToString(), out itemp1) && int.TryParse(o2.ToString(), out itemp2)) return itemp1.CompareTo(itemp2);
            else return String.Compare(o1.ToString().Trim(), o2.ToString().Trim());
        }

        /// <summary>
        /// 对比床号
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static int CompareBedValue(object o1, object o2, Type type)
        {
            //这里改成自己定义的比较
            if (o1 == null) return o2 == null ? 0 : -1;
            else 
            {
                int itemp1 = 0;
                int itemp2 = 0;
                bool b1 = false;
                bool b2 = false;
                b1 = int.TryParse(o1.ToString(), out itemp1);
                b2 = int.TryParse(o2.ToString(), out itemp2);
                bool b3 = false;
                bool b4 = false;
                if (o1.ToString().Contains("+") || o1.ToString().Contains("-"))
                    b3 = true;
                if (o2.ToString().Contains("+") || o2.ToString().Contains("-"))
                    b4 = true;
                if(b1==false&&b2==false)
                {
                    return String.Compare(o1.ToString().Trim(), o2.ToString().Trim());
                }
                else if(b1==false)
                {
                    return 1;
                }
                else if(b2==false)
                {
                    return -1;
                }
                else 
                {
                    if (b3 && b4)
                        return itemp1.CompareTo(itemp2);
                    else if (b3)
                        return 1;
                    else if (b4)
                        return -1;
                    else
                        return itemp1.CompareTo(itemp2);
                }
            }
        }
    }
}
