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
  public partial class StageWeatherPlanConfig : TBase
  {
    private int _id;
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
      public bool optionList;
    }

    public StageWeatherPlanConfig() {
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
            if (field.Type == TType.List) {
              {
                OptionList = new List<OptionElement>();
                TList _list121 = iprot.ReadListBegin();
                for( int _i122 = 0; _i122 < _list121.Count; ++_i122)
                {
                  OptionElement _elem123 = new OptionElement();
                  _elem123 = new OptionElement();
                  _elem123.Read(iprot);
                  OptionList.Add(_elem123);
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
      TStruct struc = new TStruct("StageWeatherPlanConfig");
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
      if (OptionList != null && __isset.optionList) {
        field.Name = "optionList";
        field.Type = TType.List;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, OptionList.Count));
          foreach (OptionElement _iter124 in OptionList)
          {
            _iter124.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("StageWeatherPlanConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",OptionList: ");
      sb.Append(OptionList);
      sb.Append(")");
      return sb.ToString();
    }

  }

}