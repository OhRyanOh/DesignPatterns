﻿using System.Collections.Generic;
using System.Linq;
using DesignPatterns.Models.Interfaces;

namespace DesignPatterns.ConverterImplementation
{
    /// <summary>
    /// Converts an IEnumerable ICustomer interface into an
    /// IEnumerable IPerson interface by creating
    /// new NormalPerson objects.
    /// </summary>
    public class NormalPersonEnumerableConverter :
        Converter<IEnumerable<ICustomer>, IEnumerable<IPerson>>
    {
        /// <summary>
        /// Converts an IEnumerable ICustomer interface into an
        /// IEnumerable IPerson interface by creating
        /// new NormalPerson objects via NormalPersonConverter.
        /// </summary>
        /// <param name="value">The input IEnumerable ICustomer objects to convert.</param>
        /// <returns>IEnumerable IPerson interfaces created as NormalPerson, or null if passed a null object.</returns>
        public override IEnumerable<IPerson> Convert(IEnumerable<ICustomer> value)
        {
            if (value == null)
                return null;

            var normalPersonAdpater = new NormalPersonConverter();

            return value.Select(
                p => normalPersonAdpater.Convert(p));
        }
    }
}
