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
  public partial class DropListConfig : TBase
  {
    private int _dropListId;
    private int _dropLimitId;
    private List<DropItem> _dropItemList;

    public int DropListId
    {
      get
      {
        return _dropListId;
      }
      set
      {
        __isset.dropListId = true;
        this._dropListId = value;
      }
    }

    public int DropLimitId
    {
      get
      {
        return _dropLimitId;
      }
      set
      {
        __isset.dropLimitId = true;
        this._dropLimitId = value;
      }
    }

    public List<DropItem> DropItemList
    {
      get
      {
        return _dropItemList;
      }
      set
      {
        __isset.dropItemList = true;
        this._dropItemList = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool dropListId;
      public bool dropLimitId;
      public bool dropItemList;
    }

    public DropListConfig() {
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
            if (field.Type == TType.I32) {
              DropListId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.I32) {
              DropLimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.List) {
              {
                DropItemList = new List<DropItem>();
                TList _list85 = iprot.ReadListBegin();
                for( int _i86 = 0; _i86 < _list85.Count; ++_i86)
                {
                  DropItem _elem87 = new DropItem();
                  _elem87 = new DropItem();
                  _elem87.Read(iprot);
                  DropItemList.Add(_elem87);
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
      TStruct struc = new TStruct("DropListConfig");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.dropListId) {
        field.Name = "dropListId";
        field.Type = TType.I32;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DropListId);
        oprot.WriteFieldEnd();
      }
      if (__isset.dropLimitId) {
        field.Name = "dropLimitId";
        field.Type = TType.I32;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DropLimitId);
        oprot.WriteFieldEnd();
      }
      if (DropItemList != null && __isset.dropItemList) {
        field.Name = "dropItemList";
        field.Type = TType.List;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, DropItemList.Count));
          foreach (DropItem _iter88 in DropItemList)
          {
            _iter88.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("DropListConfig(");
      sb.Append("DropListId: ");
      sb.Append(DropListId);
      sb.Append(",DropLimitId: ");
      sb.Append(DropLimitId);
      sb.Append(",DropItemList: ");
      sb.Append(DropItemList);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
