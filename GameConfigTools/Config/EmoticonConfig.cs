/**
 * Autogenerated by Thrift Compiler (0.9.1)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace Config
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class EmoticonConfig : TBase
  {
    private int _id;
    private int _packageId;
    private List<string> _resourceList;

    public int Id
    {
      get
      {
        return _id;
      }
      set
      {
        __isset.id = true;
        this._id = value;
      }
    }

    public int PackageId
    {
      get
      {
        return _packageId;
      }
      set
      {
        __isset.packageId = true;
        this._packageId = value;
      }
    }

    public List<string> ResourceList
    {
      get
      {
        return _resourceList;
      }
      set
      {
        __isset.resourceList = true;
        this._resourceList = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool packageId;
      public bool resourceList;
    }

    public EmoticonConfig() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 10:
            if (field.Type == TType.I32) {
              Id = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.I32) {
              PackageId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.List) {
              {
                ResourceList = new List<string>();
                TList _list187 = iprot.ReadListBegin();
                for( int _i188 = 0; _i188 < _list187.Count; ++_i188)
                {
                  string _elem189 = null;
                  _elem189 = iprot.ReadString();
                  ResourceList.Add(_elem189);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("EmoticonConfig");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.id) {
        field.Name = "id";
        field.Type = TType.I32;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Id);
        oprot.WriteFieldEnd();
      }
      if (__isset.packageId) {
        field.Name = "packageId";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(PackageId);
        oprot.WriteFieldEnd();
      }
      if (ResourceList != null && __isset.resourceList) {
        field.Name = "resourceList";
        field.Type = TType.List;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.String, ResourceList.Count));
          foreach (string _iter190 in ResourceList)
          {
            oprot.WriteString(_iter190);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("EmoticonConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",PackageId: ");
      sb.Append(PackageId);
      sb.Append(",ResourceList: ");
      sb.Append(ResourceList);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
