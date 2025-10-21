using Todo.Base.Enums;

namespace Todo.Base.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class DataSourceTypeAttribute : Attribute
{
    public DatasourceTypeEnum DatabaseDatasourceType;

    public DataSourceTypeAttribute(DatasourceTypeEnum datasourceType)
    {
        DatabaseDatasourceType = datasourceType;
    }
}