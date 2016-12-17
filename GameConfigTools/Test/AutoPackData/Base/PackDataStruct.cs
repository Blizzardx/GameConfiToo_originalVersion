using System.Collections.Generic;

public class PackDataElement
{
    public PackDataElementType m_Type;
    public short m_Id;
    public string m_strName;
    public object m_Value;
}
public class PackDataStruct
{
    public List<PackDataElement> m_ElemList;
}