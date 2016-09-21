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
  public partial class SystemDecorateTypeSortConfig : TBase
  {
    private List<SystemDecorateTypeSortInfo> _sortInfoList;

    public List<SystemDecorateTypeSortInfo> SortInfoList
    {
      get
      {
        return _sortInfoList;
      }
      set
      {
        __isset.sortInfoList = true;
        this._sortInfoList = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool sortInfoList;
    }

    public SystemDecorateTypeSortConfig() {
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
          case 1:
            if (field.Type == TType.List) {
              {
                SortInfoList = new List<SystemDecorateTypeSortInfo>();
                TList _list21 = iprot.ReadListBegin();
                for( int _i22 = 0; _i22 < _list21.Count; ++_i22)
                {
                  SystemDecorateTypeSortInfo _elem23 = new SystemDecorateTypeSortInfo();
                  _elem23 = new SystemDecorateTypeSortInfo();
                  _elem23.Read(iprot);
                  SortInfoList.Add(_elem23);
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
      TStruct struc = new TStruct("SystemDecorateTypeSortConfig");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (SortInfoList != null && __isset.sortInfoList) {
        field.Name = "sortInfoList";
        field.Type = TType.List;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, SortInfoList.Count));
          foreach (SystemDecorateTypeSortInfo _iter24 in SortInfoList)
          {
            _iter24.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("SystemDecorateTypeSortConfig(");
      sb.Append("SortInfoList: ");
      sb.Append(SortInfoList);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
