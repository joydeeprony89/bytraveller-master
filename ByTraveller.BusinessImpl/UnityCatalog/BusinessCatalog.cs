//---------------------------------------------------------------------------------------------
// <copyright file= BusinessCatalog.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using ByTraveller.Core;
using ByTraveller.Provider;
using ByTraveller.ProviderImpl;

namespace ByTraveller.BusinessImpl.UnityCatalog
{
    public sealed class BusinessCatalog : Catalog
    {
        protected override void Initialize()
        {
            base.Initialize();

            this.RegisterServiceType<ILoginDataHandler, LoginDataHandler>();
        }
    }
}
