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
  public partial class DiyFaceDataConfig : TBase
  {
    private int _id;
    private int _modeId;
    private int _uiNormalValue;
    private int _uiValuePow;
    private int _uiValueMin;
    private List<DiyFaceDataCmdValueInfo> _cmdValueInfoList;

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

    public int ModeId
    {
      get
      {
        return _modeId;
      }
      set
      {
        __isset.modeId = true;
        this._modeId = value;
      }
    }

    public int UiNormalValue
    {
      get
      {
        return _uiNormalValue;
      }
      set
      {
        __isset.uiNormalValue = true;
        this._uiNormalValue = value;
      }
    }

    public int UiValuePow
    {
      get
      {
        return _uiValuePow;
      }
      set
      {
        __isset.uiValuePow = true;
        this._uiValuePow = value;
      }
    }

    public int UiValueMin
    {
      get
      {
        return _uiValueMin;
      }
      set
      {
        __isset.uiValueMin = true;
        this._uiValueMin = value;
      }
    }

    public List<DiyFaceDataCmdValueInfo> CmdValueInfoList
    {
      get
      {
        return _cmdValueInfoList;
      }
      set
      {
        __isset.cmdValueInfoList = true;
        this._cmdValueInfoList = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool modeId;
      public bool uiNormalValue;
      public bool uiValuePow;
      public bool uiValueMin;
      public bool cmdValueInfoList;
    }

    public DiyFaceDataConfig() {
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
              ModeId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.I32) {
              UiNormalValue = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.I32) {
              UiValuePow = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 50:
            if (field.Type == TType.I32) {
              UiValueMin = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 60:
            if (field.Type == TType.List) {
              {
                CmdValueInfoList = new List<DiyFaceDataCmdValueInfo>();
                TList _list277 = iprot.ReadListBegin();
                for( int _i278 = 0; _i278 < _list277.Count; ++_i278)
                {
                  DiyFaceDataCmdValueInfo _elem279 = new DiyFaceDataCmdValueInfo();
                  _elem279 = new DiyFaceDataCmdValueInfo();
                  _elem279.Read(iprot);
                  CmdValueInfoList.Add(_elem279);
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
      TStruct struc = new TStruct("DiyFaceDataConfig");
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
      if (__isset.modeId) {
        field.Name = "modeId";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ModeId);
        oprot.WriteFieldEnd();
      }
      if (__isset.uiNormalValue) {
        field.Name = "uiNormalValue";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(UiNormalValue);
        oprot.WriteFieldEnd();
      }
      if (__isset.uiValuePow) {
        field.Name = "uiValuePow";
        field.Type = TType.I32;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(UiValuePow);
        oprot.WriteFieldEnd();
      }
      if (__isset.uiValueMin) {
        field.Name = "uiValueMin";
        field.Type = TType.I32;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(UiValueMin);
        oprot.WriteFieldEnd();
      }
      if (CmdValueInfoList != null && __isset.cmdValueInfoList) {
        field.Name = "cmdValueInfoList";
        field.Type = TType.List;
        field.ID = 60;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, CmdValueInfoList.Count));
          foreach (DiyFaceDataCmdValueInfo _iter280 in CmdValueInfoList)
          {
            _iter280.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("DiyFaceDataConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",ModeId: ");
      sb.Append(ModeId);
      sb.Append(",UiNormalValue: ");
      sb.Append(UiNormalValue);
      sb.Append(",UiValuePow: ");
      sb.Append(UiValuePow);
      sb.Append(",UiValueMin: ");
      sb.Append(UiValueMin);
      sb.Append(",CmdValueInfoList: ");
      sb.Append(CmdValueInfoList);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
