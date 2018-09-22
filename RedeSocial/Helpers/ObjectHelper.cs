#region --Using--
using System;
using System.Linq;
#endregion

namespace Helpers
{
    public class ObjectHelper
    {

        public static T MergeObjects<T>(T oldObject, T newObject) where T : class, new()
        {
            var oldObjectMembers = oldObject.GetType().GetMembers().Where(_ => _.MemberType == System.Reflection.MemberTypes.Property);
            var newObjectMembers = newObject.GetType().GetMembers().Where(_ => _.MemberType == System.Reflection.MemberTypes.Property);

            for (int i = 0; i < oldObjectMembers.Count(); i++)
            {
                var oldValue = oldObject.GetType().GetProperty(oldObjectMembers.ElementAtOrDefault(i).Name).GetValue(oldObject);
                var newValue = newObject.GetType().GetProperty(newObjectMembers.ElementAtOrDefault(i).Name).GetValue(newObject);
                var type = newObject.GetType();

                object finalValue = null;

                if (oldValue is int)
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
                    if (finalValue != null)
                    {
                        finalValue = oldValue != newValue ? newValue : oldValue;
                    }
                }

                if (finalValue == null)
                {
                    finalValue = oldValue ?? newValue;
                }

                newObject.GetType().GetProperty(newObjectMembers.ElementAtOrDefault(i).Name).SetValue(type, finalValue);
            }

            return newObject;

            throw new NotImplementedException();
        }
    }
}
