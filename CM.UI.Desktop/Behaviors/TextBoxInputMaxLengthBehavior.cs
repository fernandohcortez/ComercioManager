using Microsoft.Xaml.Behaviors;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Windows.Controls;

namespace CM.UI.Desktop.Behaviors
{
    public class TextBoxInputMaxLengthBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += (sender, args) => SetMaxLength();

            base.OnAttached();
        }

        private void SetMaxLength()
        {
            var context = AssociatedObject.DataContext;
            var binding = AssociatedObject.GetBindingExpression(TextBox.TextProperty);

            if (context == null || binding == null)
                return;

            var attributeStringLength = GetAttributeStringLength(binding.ResolvedSource.GetType().GetProperty(binding.ResolvedSourcePropertyName));

            if (attributeStringLength != null)
            {
                AssociatedObject.MaxLength = attributeStringLength.MaximumLength;
            }


            //var prop = context.GetType().GetProperty(binding.ParentBinding.Path.Path);
            //if (prop == null)
            //    return;

            //if (prop.GetCustomAttributes(typeof(StringLengthAttribute), true).FirstOrDefault() is StringLengthAttribute att)
            //{
            //    AssociatedObject.MaxLength = att.MaximumLength;
            //}
        }

        protected static StringLengthAttribute GetAttributeStringLength(object descriptor)
        {
            if (descriptor is PropertyDescriptor propertyDescriptor)
            {
                if (propertyDescriptor.Attributes[typeof(StringLengthAttribute)] is StringLengthAttribute stringLengthAttribute)
                    return stringLengthAttribute;
            }
            else
            {
                var propertyInfo = descriptor as PropertyInfo;

                if (propertyInfo == null)
                    return null;

                var attributes = propertyInfo.GetCustomAttributes(typeof(StringLengthAttribute), true);

                foreach (var attribute in attributes)
                {
                    if (attribute is StringLengthAttribute stringLengthAttribute)
                        return stringLengthAttribute;
                }
            }

            return null;
        }
    }
}
