// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Reflection;
using Microsoft.Data.Entity.Metadata;

namespace Microsoft.Framework.CodeGeneration.EntityFramework
{
    public class PropertyMetadata
    {
        //Todo: Perhaps move the constructor to something line MetadataReader?
        public PropertyMetadata([NotNull]IProperty property)
        {
            var entityType = property.DeclaringEntityType;
            PropertyName = property.Name;
            TypeName = property.ClrType.FullName;
            IsEnum = property.ClrType.GetTypeInfo().IsEnum;
            IsPrimaryKey = entityType.GetPrimaryKey().Properties.Contains(property);
            IsForeignKey = entityType.GetForeignKeys()
                .Any(fk => fk.Properties.Contains(property));

            // Todo:we need proper logic for these below.
            IsEnumFlags = false;
            IsAssociation = false;
            IsReadOnly = false;
            IsAutoGenerated = false;
            ShortTypeName = TypeName;
            Scaffold = true;
        }

        public bool IsAssociation { get; set; }

        public bool IsAutoGenerated { get; set; }

        public bool IsEnum { get; set; }

        public bool IsEnumFlags { get; set; }

        public bool IsForeignKey { get; set; }

        public bool IsPrimaryKey { get; set; }

        public bool IsReadOnly { get; set; }

        public string PropertyName { get; set; }

        public bool Scaffold { get; set; }

        public string ShortTypeName { get; set; }

        public string TypeName { get; set; }
    }
}