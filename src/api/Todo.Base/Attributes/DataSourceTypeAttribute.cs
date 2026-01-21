using System;
using Todo.Base.Enums;

namespace Todo.Base.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class DataSourceTypeAttribute : Attribute
{
    public readonly DataSourceTypeEnum DatabaseDataSourceType;

    public DataSourceTypeAttribute(DataSourceTypeEnum dataSourceType)
    {
        DatabaseDataSourceType = dataSourceType;
    }
}