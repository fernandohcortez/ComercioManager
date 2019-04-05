using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;

namespace CM.UI.Desktop.Components
{
    public class ColumnHeaderBehavior : Behavior<DataGrid>
    {
        protected override void OnAttached()
        {
            AssociatedObject.AutoGeneratingColumn += OnAutoGeneratingColumn;


        }

        protected override void OnDetaching()
        {
            AssociatedObject.AutoGeneratingColumn -= OnAutoGeneratingColumn;
        }

        protected void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var displayName = GetPropertyDisplayName(e.PropertyDescriptor);

            e.Column.Header = !string.IsNullOrEmpty(displayName) ? displayName : e.PropertyName;

            e.Column.HeaderStyle = new Style(typeof(DataGridColumnHeader));
            e.Column.HeaderStyle.Setters.Add(new Setter(Control.HorizontalContentAlignmentProperty, HorizontalAlignment.Center));

            if (e.Column is DataGridTextColumn)
            {
                Setter setter;

                if (e.PropertyType == typeof(int) || e.PropertyType == typeof(int?))
                {
                    setter = new Setter(TextBox.TextAlignmentProperty, TextAlignment.Center);
                }
                else if (e.PropertyType == typeof(decimal) || e.PropertyType == typeof(decimal?))
                {
                    setter = new Setter(TextBox.TextAlignmentProperty, TextAlignment.Right);
                }
                else
                {
                    setter = new Setter(TextBox.TextAlignmentProperty, TextAlignment.Left);
                }

                e.Column.CellStyle = new Style(typeof(DataGridCell))
                {
                    Setters = { setter }
                };
            }
        }

        protected static string GetPropertyDisplayName(object descriptor)
        {
            if (descriptor is PropertyDescriptor pd)
            {
                if ((pd.Attributes[typeof(DisplayNameAttribute)] is DisplayNameAttribute attr) && (attr != DisplayNameAttribute.Default))
                {
                    return attr.DisplayName;
                }
            }
            else
            {
                var pi = descriptor as PropertyInfo;

                if (pi == null)
                    return null;

                var attrs = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true);

                foreach (var att in attrs)
                {
                    if ((att is DisplayNameAttribute attribute) && (attribute != DisplayNameAttribute.Default))
                    {
                        return attribute.DisplayName;
                    }
                }
            }

            return null;
        }
    }
}
