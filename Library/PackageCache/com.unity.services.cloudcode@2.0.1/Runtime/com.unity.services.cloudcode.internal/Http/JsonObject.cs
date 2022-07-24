//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

namespace Unity.Services.CloudCode.Internal.Http
{
    /// <summary>
    /// JsonObject class for encapsulating generic object types. We use this to
    /// hide internal Json implementation details.
    /// </summary>
    [Preserve]
    internal class JsonObject
    {
        /// <summary>
        /// Constructor sets object as the internal object.
        /// </summary>
        [Preserve]
        internal JsonObject(object obj)
        {
            this.obj = obj;
        }

        /// <summary>The encapsulated object.</summary>
        [Preserve]
        internal object obj;

        /// <summary>
        /// Returns the internal object as a string.
        /// </summary>
        /// <returns>The internal object as a string.</returns>
        public string GetAsString()
        {
            try
            {
                if (obj.GetType() == typeof(String))
                {
                    return obj.ToString();
                }
                return JsonConvert.SerializeObject(obj);
            }
            catch (System.Exception)
            {
                throw new InvalidOperationException("Failed to convert JsonObject to string.");
            }
        }

        /// <summary>
        /// Returns the object as a defined type.
        /// </summary>
        /// <typeparam name="T">The type to cast internal object to.</typeparam>
        /// <param name="deserializationSettings">Deserialization settings for how to handle properties like missing members.</param>
        /// <returns>The internal object case to type T.</returns>
        public T GetAs<T>(DeserializationSettings deserializationSettings = null)
        {
            // Check if deserializationSettings is null so we can use the default value.
            deserializationSettings = deserializationSettings ?? new DeserializationSettings();
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = deserializationSettings.MissingMemberHandling == MissingMemberHandling.Error
                    ? Newtonsoft.Json.MissingMemberHandling.Error
                    : Newtonsoft.Json.MissingMemberHandling.Ignore
            };
            try
            {
                var returnObject = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj), jsonSettings);
                var errors = ValidateObject(returnObject);
                if (errors.Count > 0)
                {
                    throw new DeserializationException(String.Join("\n", errors));
                }

                return returnObject;
            }
            catch (DeserializationException)
            {
                throw;
            }
            catch (JsonSerializationException e)
            {
                throw new DeserializationException(e.Message);
            }
            catch (Exception)
            {
                throw new DeserializationException("Unable to deserialize object.");
            }
        }

        private List<string> ValidateObject<T>(T objectToCheck, List<string> errors = null)
        {
            if (errors == null)
            {
                errors = new List<string>();
            }

            if (objectToCheck != null)
            {
                var isList = typeof(IEnumerable).IsAssignableFrom(typeof(T));
                if (isList)
                {
                    foreach (var item in (IEnumerable) objectToCheck)
                    {
                        ValidateFieldInfos(item, errors);
                        ValidatePropertyInfos(item, errors);
                    }
                }
                else
                {
                    ValidateFieldInfos(objectToCheck, errors);
                    ValidatePropertyInfos(objectToCheck, errors);
                }
            }

            return errors;
        }

        private void ValidatePropertyInfos<T>(T objectToCheck, List<string> errors)
        {
            var propertyInfos = objectToCheck.GetType().GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                var value = propertyInfo.GetValue(objectToCheck);
                var memberName = propertyInfo.Name;
                var objectName = objectToCheck.GetType().Name;
                ValidateValue(value, objectName, "Property", memberName, errors);
            }
        }

        private void ValidateFieldInfos<T>(T objectToCheck, List<string> errors)
        {
            var fieldInfos = objectToCheck.GetType().GetFields();
            foreach (var fieldInfo in fieldInfos)
            {
                var value = fieldInfo.GetValue(objectToCheck);
                var memberName = fieldInfo.Name;
                var objectName = objectToCheck.GetType().Name;
                ValidateValue(value, objectName, "Field", memberName, errors);
            }
        }

        private void ValidateValue(object value, string objectName, string memberType, string memberName,
            List<string> errors)
        {
            if (!(value is ValueType) && !(value is string))
            {
                if (value is JObject)
                {
                    errors.Add(
                        $"{memberType}: \"{memberName}\" on Type: \"{objectName}\" must not be of type `object` or `dynamic`");
                }
                else
                {
                    ValidateObject(value, errors);
                }
            }
        }
    }
}
