using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicVNET.Lib.Core.Validator
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ProfileValidator
    {
        private Dictionary<string, IValidator> _profiles;

        /// <summary>
        /// 
        /// </summary>
        public ProfileValidator()
        {
            _profiles = new Dictionary<string, IValidator>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="profileName"></param>
        /// <param name="setup"></param>
        /// <param name="failFirst"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddByProfile<T>(string profileName,
                                    MarkerSetup<T> setup,
                                    bool failFirst = false)
        {
            if (string.IsNullOrEmpty(profileName))
            {
                throw new ArgumentNullException("profileName");
            }

            IValidator<T> validator = ValidatorFactory.Create<T>(setup, failFirst);

            _profiles.Add(profileName, validator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profileName"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public bool IsValid(string profileName, object instance)
        {
            IValidator byProfile = GetByProfile(profileName);
            CheckInstance(byProfile, instance);
            return byProfile.IsValid(instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profileName"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public IEnumerable<ValidationRuleResult> Validate(string profileName, object instance)
        {
            IValidator byProfile = GetByProfile(profileName);
            CheckInstance(byProfile, instance);
            return byProfile.Validate(instance);
        }

        private IValidator GetByProfile(string profileName)
        {
            if (!_profiles.TryGetValue(profileName, out var value))
            {
                throw new Exception(profileName + " Not containe!");
            }

            return value;
        }

        private void CheckInstance(IValidator validator, object instance)
        {
            Type type = instance.GetType();

            if (validator.ValidateType != type)
            {
                throw new Exception("Invalid " + type.Name + "!");
            }
        }

        private IEnumerable<IValidator> GetValidatorForInstace(object instance)
        {
            return from x in _profiles
                   where x.Value.ValidateType == instance.GetType()
                   select x.Value;
        }
    }
}
