// ***********************************************************************
// Assembly         : WWI.Core3.Core
// Author           : Mustafizur Rohman
// Created          : 05-08-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-16-2020
// ***********************************************************************
// <copyright file="ObjectExtensions.cs" company="WWI.Core3.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Reflection;

namespace WWI.Core3.Core.ExtensionMethods
{
    /// <summary>
    /// Class ObjectExtensions.
    /// </summary>
    public static class ObjectExtensions
    {

        /// <summary>
        /// Deep clone an Object
        /// TODO: Debug and verify
        /// </summary>
        /// <param name="sourceObject">Object to clone</param>
        /// <returns>System.Object.</returns>
        /// <exception cref="ArgumentException">Unknown type</exception>
        public static object DeepCloneObject(this object sourceObject)
        {

            if (sourceObject == null)
            {
                return null;
            }

            Type type = sourceObject.GetType();

            if (type.IsValueType || type == typeof(string))
            {
                return sourceObject;
            }
            else if (type.IsArray)
            {
                // ReSharper disable once PossibleNullReferenceException
                Type elementType = Type.GetType(type.FullName.Replace("[]", string.Empty));

                var array = sourceObject as Array;

                // ReSharper disable once AssignNullToNotNullAttribute
                // ReSharper disable once PossibleNullReferenceException
                Array copied = Array.CreateInstance(elementType, array.Length);

                for (int i = 0; i < array.Length; i++)
                {
                    copied.SetValue(DeepCloneObject(array.GetValue(i)), i);
                }

                return Convert.ChangeType(copied, sourceObject.GetType());
            }
            else if (type.IsClass)
            {
                object toret = Activator.CreateInstance(sourceObject.GetType());

                FieldInfo[] fields = type.GetFields(BindingFlags.Public
                                                  | BindingFlags.NonPublic
                                                  | BindingFlags.Instance);

                foreach (FieldInfo field in fields)
                {
                    object fieldValue = field.GetValue(sourceObject);
                    if (fieldValue == null)
                        continue;
                    field.SetValue(toret, DeepCloneObject(fieldValue));
                }

                // return toret;
                return Convert.ChangeType(toret, sourceObject.GetType());
            }
            else
            {
                throw new ArgumentException("Unknown type");
            }

        }

        /*
        /// <summary>
        /// Deep clones an object using Force DeepCloner
        /// </summary>
        /// <param name="sourceObject">Source object to clone</param>
        /// <returns>Cloned copy of sourceObject</returns>
        public static object DeepClone(this object sourceObject)
        {
            return sourceObject.DeepClone();
        } */

        /// <summary>
        /// Deeps the compare.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool DeepCompare(this object obj1, object obj2)
        {

            if (obj1 == null || obj2 == null)
            {
                return false;
            }

            // ReSharper disable once CheckForReferenceEqualityInstead.3
            if (obj1.GetType() != obj2.GetType())
            {
                return false;
            }

            Type type = obj1.GetType();

            // ReSharper disable once CheckForReferenceEqualityInstead.1
            if (type.IsPrimitive || typeof(string).Equals(type))
            {
                return obj1.Equals(obj2);
            }

            if (type.IsArray)
            {
                Array first = obj1 as Array;
                Array second = obj2 as Array;

                var en = first?.GetEnumerator();
                int i = 0;
                while (en != null && en.MoveNext())
                {

                    if (second != null && !DeepCompare(en.Current, second.GetValue(i)))
                        return false;
                    i++;
                }

            }
            else
            {

                foreach (PropertyInfo pi in type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
                {
                    if (!DeepCompare(pi.GetValue(obj1), pi.GetValue(obj2)))
                    {
                        return false;
                    }
                }

                foreach (FieldInfo fi in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
                {
                    if (!DeepCompare(fi.GetValue(obj1), fi.GetValue(obj2)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Gets the copy of a object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToCopy">The s.</param>
        /// <returns>T.</returns>
        public static T GetCopy<T>(this T objectToCopy)
        {
            T newObject = Activator.CreateInstance<T>();

            foreach (PropertyInfo i in newObject.GetType().GetProperties())
            {
                if (i.CanWrite)
                {
                    object value = objectToCopy.GetType().GetProperty(i.Name)?.GetValue(objectToCopy, null);
                    i.SetValue(newObject, value, null);
                }
            }

            return newObject;
        }

    }
}
