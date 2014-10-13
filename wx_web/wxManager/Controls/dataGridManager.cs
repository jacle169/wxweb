using System;
using System.Windows.Controls;
using System.Windows.Data;

namespace wxManager
{
    public class dgm
    {
        //how to use this control
        //dg_students.Columns.Add(dgm.GetDGM().createTextColumn("学号", "st_学号"));
        //dg_students.Columns.Add(dgm.GetDGM().createBoolConvertTextColumn("是否已婚", "st_已婚"));
        //dg_students.Columns.Add(dgm.GetDGM().createSexConvertTextColumn("性别", "st_性别"));
        //dg_students.Columns.Add(dgm.GetDGM().createTextColumn("出生日期", "st_出生日期", @"{0:yyyy/MM/dd}"));
        //dg_students.Columns.Add(dgm.GetDGM().createTextColumn("单价", "st_单价","#.##"));
        //dg_students.Columns.Add(dgm.GetDGM().createTextColumn("入学时间", "st_入学时间", "{0:yyyy/MM/dd HH:mm:ss}"));
        //var d = dgm.GetDGM().createTextColumn("批发价", "st_批发价","0:d");
        //d.Width = new DataGridLength(30, DataGridLengthUnitType.Star);
        //dg_students.Columns.Add(d);

        static dgm gm;
        internal static dgm GetDGM()
        {
            if (gm == null)
            {
                gm = new dgm();
            }
            return gm;
        }

        internal DataGridTextColumn createBoolConvertTextColumn(string header, string path)
        {
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = header;
            Binding bind = new Binding(path);
            bind.Converter = new boolConverter();
            bind.ConverterParameter = path;
            textColumn.Binding = bind;
            return textColumn;
        }

        internal DataGridTextColumn createSexConvertTextColumn(string header, string path)
        {
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = header;
            Binding bind = new Binding(path);
            bind.Converter = new sexConverter();
            bind.ConverterParameter = path;
            textColumn.Binding = bind;
            return textColumn;
        }

        internal DataGridTextColumn createTextColumn(string header, string path)
        {
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = header;
            Binding bind = new Binding(path);
            textColumn.Binding = bind;
            return textColumn;
        }

        internal DataGridTextColumn createTextColumn(string header, string path, string format)
        {
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = header;
            Binding bind = new Binding(path);
            bind.StringFormat = format;
            textColumn.Binding = bind;
            return textColumn;
        }

        public class boolConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                bool result;
                bool.TryParse(value.ToString(), out result);
                return result ? "是" : "否";
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return null;
            }
        }

        public class sexConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                bool result;
                bool.TryParse(value.ToString(), out result);
                return result ? "男" : "女";
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return null;
            }
        }

    }
}
