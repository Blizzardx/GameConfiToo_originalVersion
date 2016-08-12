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
  public partial class ShockConfig : TBase
  {
    private int _id;
    private int _beginTimeMin;
    private int _beginTimeMax;
    private int _randomCountMin;
    private int _randomCountMax;
    private int _beginFuncId;
    private List<OptionElement> _optionList;

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

    public int BeginTimeMin
    {
      get
      {
        return _beginTimeMin;
      }
      set
      {
        __isset.beginTimeMin = true;
        this._beginTimeMin = value;
      }
    }

    public int BeginTimeMax
    {
      get
      {
        return _beginTimeMax;
      }
      set
      {
        __isset.beginTimeMax = true;
        this._beginTimeMax = value;
      }
    }

    public int RandomCountMin
    {
      get
      {
        return _randomCountMin;
      }
      set
      {
        __isset.randomCountMin = true;
        this._randomCountMin = value;
      }
    }

    public int RandomCountMax
    {
      get
      {
        return _randomCountMax;
      }
      set
      {
        __isset.randomCountMax = true;
        this._randomCountMax = value;
      }
    }

    public int BeginFuncId
    {
      get
      {
        return _beginFuncId;
      }
      set
      {
        __isset.beginFuncId = true;
        this._beginFuncId = value;
      }
    }

    public List<OptionElement> OptionList
    {
      get
      {
        return _optionList;
      }
      set
      {
        __isset.optionList = true;
        this._optionList = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool beginTimeMin;
      public bool beginTimeMax;
      public bool randomCountMin;
      public bool randomCountMax;
      public bool beginFuncId;
      public bool optionList;
    }

    public ShockConfig() {
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
              BeginTimeMin = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.I32) {
              BeginTimeMax = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.I32) {
              RandomCountMin = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 41:
            if (field.Type == TType.I32) {
              RandomCountMax = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 50:
            if (field.Type == TType.I32) {
              BeginFuncId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 60:
            if (field.Type == TType.List) {
              {
                OptionList = new List<OptionElement>();
                TList _list117 = iprot.ReadListBegin();
                for( int _i118 = 0; _i118 < _list117.Count; ++_i118)
                {
                  OptionElement _elem119 = new OptionElement();
                  _elem119 = new OptionElement();
                  _elem119.Read(iprot);
                  OptionList.Add(_elem119);
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
      TStruct struc = new TStruct("ShockConfig");
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
      if (__isset.beginTimeMin) {
        field.Name = "beginTimeMin";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(BeginTimeMin);
        oprot.WriteFieldEnd();
      }
      if (__isset.beginTimeMax) {
        field.Name = "beginTimeMax";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(BeginTimeMax);
        oprot.WriteFieldEnd();
      }
      if (__isset.randomCountMin) {
        field.Name = "randomCountMin";
        field.Type = TType.I32;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(RandomCountMin);
        oprot.WriteFieldEnd();
      }
      if (__isset.randomCountMax) {
        field.Name = "randomCountMax";
        field.Type = TType.I32;
        field.ID = 41;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(RandomCountMax);
        oprot.WriteFieldEnd();
      }
      if (__isset.beginFuncId) {
        field.Name = "beginFuncId";
        field.Type = TType.I32;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(BeginFuncId);
        oprot.WriteFieldEnd();
      }
      if (OptionList != null && __isset.optionList) {
        field.Name = "optionList";
        field.Type = TType.List;
        field.ID = 60;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, OptionList.Count));
          foreach (OptionElement _iter120 in OptionList)
          {
            _iter120.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("ShockConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",BeginTimeMin: ");
      sb.Append(BeginTimeMin);
      sb.Append(",BeginTimeMax: ");
      sb.Append(BeginTimeMax);
      sb.Append(",RandomCountMin: ");
      sb.Append(RandomCountMin);
      sb.Append(",RandomCountMax: ");
      sb.Append(RandomCountMax);
      sb.Append(",BeginFuncId: ");
      sb.Append(BeginFuncId);
      sb.Append(",OptionList: ");
      sb.Append(OptionList);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
