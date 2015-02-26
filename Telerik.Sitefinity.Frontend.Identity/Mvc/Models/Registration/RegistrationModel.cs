﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Sitefinity.Frontend.Identity.Mvc.Models.Registration
{
    /// <summary>
    /// This class is used as a model for the <see cref="RegistrationController"/>.
    /// </summary>
    public class RegistrationModel : IRegistrationModel
    {
        /// <inheritDoc/>
        public Guid? LoginPageId { get; set; }

        /// <inheritDoc/>
        public string CssClass { get; set; }

        /// <summary>
        /// Gets or sets the name of the provider.
        /// </summary>
        /// <value>The name of the provider.</value>
        public string ProviderName { get; set; }

        /// <inheritDoc/>
        public RegistrationViewModel GetViewModel()
        {
            return new RegistrationViewModel()
            {
                LoginPageUrl = this.GetLoginPageUrl(),
                CssClass = this.CssClass
            };
        }

        /// <summary>
        /// Gets the login redirect URL.
        /// </summary>
        /// <returns></returns>
        public virtual string GetLoginPageUrl()
        {
            return null;
        }
    }
}