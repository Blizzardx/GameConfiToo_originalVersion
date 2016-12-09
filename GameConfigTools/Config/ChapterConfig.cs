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
  public partial class ChapterConfig : TBase
  {
    private int _id;
    private int _nextChapterId;
    private int _nameMessageId;
    private int _firstStageId;
    private int _award1LimitId;
    private int _award1FuncId;
    private int _flag1Id;
    private int _award2LimitId;
    private int _award2FuncId;
    private int _flag2Id;
    private int _award3LimitId;
    private int _award3FuncId;
    private int _flag3Id;
    private string _mapResource;

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

    public int NextChapterId
    {
      get
      {
        return _nextChapterId;
      }
      set
      {
        __isset.nextChapterId = true;
        this._nextChapterId = value;
      }
    }

    public int NameMessageId
    {
      get
      {
        return _nameMessageId;
      }
      set
      {
        __isset.nameMessageId = true;
        this._nameMessageId = value;
      }
    }

    public int FirstStageId
    {
      get
      {
        return _firstStageId;
      }
      set
      {
        __isset.firstStageId = true;
        this._firstStageId = value;
      }
    }

    public int Award1LimitId
    {
      get
      {
        return _award1LimitId;
      }
      set
      {
        __isset.award1LimitId = true;
        this._award1LimitId = value;
      }
    }

    public int Award1FuncId
    {
      get
      {
        return _award1FuncId;
      }
      set
      {
        __isset.award1FuncId = true;
        this._award1FuncId = value;
      }
    }

    public int Flag1Id
    {
      get
      {
        return _flag1Id;
      }
      set
      {
        __isset.flag1Id = true;
        this._flag1Id = value;
      }
    }

    public int Award2LimitId
    {
      get
      {
        return _award2LimitId;
      }
      set
      {
        __isset.award2LimitId = true;
        this._award2LimitId = value;
      }
    }

    public int Award2FuncId
    {
      get
      {
        return _award2FuncId;
      }
      set
      {
        __isset.award2FuncId = true;
        this._award2FuncId = value;
      }
    }

    public int Flag2Id
    {
      get
      {
        return _flag2Id;
      }
      set
      {
        __isset.flag2Id = true;
        this._flag2Id = value;
      }
    }

    public int Award3LimitId
    {
      get
      {
        return _award3LimitId;
      }
      set
      {
        __isset.award3LimitId = true;
        this._award3LimitId = value;
      }
    }

    public int Award3FuncId
    {
      get
      {
        return _award3FuncId;
      }
      set
      {
        __isset.award3FuncId = true;
        this._award3FuncId = value;
      }
    }

    public int Flag3Id
    {
      get
      {
        return _flag3Id;
      }
      set
      {
        __isset.flag3Id = true;
        this._flag3Id = value;
      }
    }

    public string MapResource
    {
      get
      {
        return _mapResource;
      }
      set
      {
        __isset.mapResource = true;
        this._mapResource = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool nextChapterId;
      public bool nameMessageId;
      public bool firstStageId;
      public bool award1LimitId;
      public bool award1FuncId;
      public bool flag1Id;
      public bool award2LimitId;
      public bool award2FuncId;
      public bool flag2Id;
      public bool award3LimitId;
      public bool award3FuncId;
      public bool flag3Id;
      public bool mapResource;
    }

    public ChapterConfig() {
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
          case 11:
            if (field.Type == TType.I32) {
              NextChapterId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 12:
            if (field.Type == TType.I32) {
              NameMessageId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.I32) {
              FirstStageId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 50:
            if (field.Type == TType.I32) {
              Award1LimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 60:
            if (field.Type == TType.I32) {
              Award1FuncId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 70:
            if (field.Type == TType.I32) {
              Flag1Id = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 80:
            if (field.Type == TType.I32) {
              Award2LimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 90:
            if (field.Type == TType.I32) {
              Award2FuncId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 100:
            if (field.Type == TType.I32) {
              Flag2Id = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 110:
            if (field.Type == TType.I32) {
              Award3LimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 120:
            if (field.Type == TType.I32) {
              Award3FuncId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 130:
            if (field.Type == TType.I32) {
              Flag3Id = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 140:
            if (field.Type == TType.String) {
              MapResource = iprot.ReadString();
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
      TStruct struc = new TStruct("ChapterConfig");
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
      if (__isset.nextChapterId) {
        field.Name = "nextChapterId";
        field.Type = TType.I32;
        field.ID = 11;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(NextChapterId);
        oprot.WriteFieldEnd();
      }
      if (__isset.nameMessageId) {
        field.Name = "nameMessageId";
        field.Type = TType.I32;
        field.ID = 12;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(NameMessageId);
        oprot.WriteFieldEnd();
      }
      if (__isset.firstStageId) {
        field.Name = "firstStageId";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(FirstStageId);
        oprot.WriteFieldEnd();
      }
      if (__isset.award1LimitId) {
        field.Name = "award1LimitId";
        field.Type = TType.I32;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Award1LimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.award1FuncId) {
        field.Name = "award1FuncId";
        field.Type = TType.I32;
        field.ID = 60;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Award1FuncId);
        oprot.WriteFieldEnd();
      }
      if (__isset.flag1Id) {
        field.Name = "flag1Id";
        field.Type = TType.I32;
        field.ID = 70;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Flag1Id);
        oprot.WriteFieldEnd();
      }
      if (__isset.award2LimitId) {
        field.Name = "award2LimitId";
        field.Type = TType.I32;
        field.ID = 80;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Award2LimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.award2FuncId) {
        field.Name = "award2FuncId";
        field.Type = TType.I32;
        field.ID = 90;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Award2FuncId);
        oprot.WriteFieldEnd();
      }
      if (__isset.flag2Id) {
        field.Name = "flag2Id";
        field.Type = TType.I32;
        field.ID = 100;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Flag2Id);
        oprot.WriteFieldEnd();
      }
      if (__isset.award3LimitId) {
        field.Name = "award3LimitId";
        field.Type = TType.I32;
        field.ID = 110;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Award3LimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.award3FuncId) {
        field.Name = "award3FuncId";
        field.Type = TType.I32;
        field.ID = 120;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Award3FuncId);
        oprot.WriteFieldEnd();
      }
      if (__isset.flag3Id) {
        field.Name = "flag3Id";
        field.Type = TType.I32;
        field.ID = 130;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Flag3Id);
        oprot.WriteFieldEnd();
      }
      if (MapResource != null && __isset.mapResource) {
        field.Name = "mapResource";
        field.Type = TType.String;
        field.ID = 140;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(MapResource);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("ChapterConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",NextChapterId: ");
      sb.Append(NextChapterId);
      sb.Append(",NameMessageId: ");
      sb.Append(NameMessageId);
      sb.Append(",FirstStageId: ");
      sb.Append(FirstStageId);
      sb.Append(",Award1LimitId: ");
      sb.Append(Award1LimitId);
      sb.Append(",Award1FuncId: ");
      sb.Append(Award1FuncId);
      sb.Append(",Flag1Id: ");
      sb.Append(Flag1Id);
      sb.Append(",Award2LimitId: ");
      sb.Append(Award2LimitId);
      sb.Append(",Award2FuncId: ");
      sb.Append(Award2FuncId);
      sb.Append(",Flag2Id: ");
      sb.Append(Flag2Id);
      sb.Append(",Award3LimitId: ");
      sb.Append(Award3LimitId);
      sb.Append(",Award3FuncId: ");
      sb.Append(Award3FuncId);
      sb.Append(",Flag3Id: ");
      sb.Append(Flag3Id);
      sb.Append(",MapResource: ");
      sb.Append(MapResource);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
