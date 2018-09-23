#region --Using--
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
#endregion

namespace Helpers
{
    public class ObjectHelper
    {

        public static T MergeObjects<T>(T oldObject, T newObject) where T : class, new()
        {
            var oldObjectMembers = oldObject.GetType().GetMembers().Where(_ => _.MemberType == System.Reflection.MemberTypes.Property);
            var newObjectMembers = newObject.GetType().GetMembers().Where(_ => _.MemberType == System.Reflection.MemberTypes.Property);

            T mergedObject = new T();
            Type type = mergedObject.GetType();

            for (int i = 0; i < oldObjectMembers.Count(); i++)
            {
                var oldValue = oldObject.GetType().GetProperty(oldObjectMembers.ElementAtOrDefault(i).Name).GetValue(oldObject);
                var newValue = newObject.GetType().GetProperty(newObjectMembers.ElementAtOrDefault(i).Name).GetValue(newObject);

                object finalValue = null;

                if (oldValue is default(int) || newValue is default(int))
                {
                    if ((oldValue is default(int)) && !(newValue is default(int)))
                    {
                        finalValue = newValue;
                    }
                    else if (!(oldValue is default(int)) && (newValue is default(int)))
                    {
                        finalValue = oldValue;
                    }
                    else if (!(oldValue is default(int)) && !(newValue is default(int)))
                    {
                        finalValue = newValue;
                    }
                }
                else
                {
                    if (newValue != null || oldValue != null)
                    {
                        finalValue = oldValue != newValue ? newValue : oldValue;
                    }
                }

                if (finalValue == null)
                {
                    finalValue = oldValue ?? newValue;
                }


                PropertyInfo propertyInfo = type.GetProperty(newObjectMembers.ElementAtOrDefault(i).Name);

                propertyInfo.SetValue(mergedObject, finalValue);

            }

            return mergedObject;
        }

        private static void SetPropertyValue<T>(Expression<Func<T>> lambda, object value)
        {
            var memberExpression = (MemberExpression)lambda.Body;
            var propertyInfo = (PropertyInfo)memberExpression.Member;
            var propertyOwnerExpression = (MemberExpression)memberExpression.Expression;
            var propertyOwner = Expression.Lambda(propertyOwnerExpression).Compile().DynamicInvoke();

            propertyInfo.SetValue(propertyOwner, value, null);
        }
    }
}
