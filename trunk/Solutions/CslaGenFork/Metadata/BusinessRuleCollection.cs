﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CslaGenerator.Metadata
{
    public class BusinessRuleCollection : List<BusinessRule>
    {
        public BusinessRule Find(string name)
        {
            if (name == string.Empty)
                return null;

            return this.FirstOrDefault(p => p.Name.Equals(name));
        }

        public bool Contains(string name)
        {
            return (Find(name) != null);
        }

        public void OnParentChanged(IHaveBusinessRules sender, EventArgs e)
        {
            foreach (var rule in this)
            {
                rule.Parent = sender.Name;
                foreach (var constructor in rule.Constructors)
                {
                    foreach (var parameter in constructor.ConstructorParameters)
                    {
                        if (parameter.Type == "IPropertyInfo" && parameter.Name == "primaryProperty")
                        {
                            parameter.Value = sender.Name;
                            break;
                        }
                    }
                }
            }
        }
    }
}