//---------------------------------------------------------------------------------------------
// <copyright file= ValidatorFactory.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace ByTravellerAPI.Common
{
    [ExcludeFromCodeCoverage]
    public class ValidatorFactory : ValidatorFactoryBase
    {
        public override IValidator CreateInstance(Type validatorType)
        {
            return IocContainer.Resolve(validatorType) as IValidator;
        }
    }
}
