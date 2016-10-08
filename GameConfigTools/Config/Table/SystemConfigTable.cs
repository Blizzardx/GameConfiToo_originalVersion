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

namespace Config.Table
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class SystemConfigTable : TBase
  {
    private Config.SystemRoomConfig _roomConfig;
    private Config.SystemDecorateTypeSortConfig _decorateTypeSrotConfig;
    private Config.SystemChatConfig _chatConfig;
    private Config.SystemCharacterConfig _characterConfig;
    private Config.SystemLoverConfig _loverConfig;

    public Config.SystemRoomConfig RoomConfig
    {
      get
      {
        return _roomConfig;
      }
      set
      {
        __isset.roomConfig = true;
        this._roomConfig = value;
      }
    }

    public Config.SystemDecorateTypeSortConfig DecorateTypeSrotConfig
    {
      get
      {
        return _decorateTypeSrotConfig;
      }
      set
      {
        __isset.decorateTypeSrotConfig = true;
        this._decorateTypeSrotConfig = value;
      }
    }

    public Config.SystemChatConfig ChatConfig
    {
      get
      {
        return _chatConfig;
      }
      set
      {
        __isset.chatConfig = true;
        this._chatConfig = value;
      }
    }

    public Config.SystemCharacterConfig CharacterConfig
    {
      get
      {
        return _characterConfig;
      }
      set
      {
        __isset.characterConfig = true;
        this._characterConfig = value;
      }
    }

    public Config.SystemLoverConfig LoverConfig
    {
      get
      {
        return _loverConfig;
      }
      set
      {
        __isset.loverConfig = true;
        this._loverConfig = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool roomConfig;
      public bool decorateTypeSrotConfig;
      public bool chatConfig;
      public bool characterConfig;
      public bool loverConfig;
    }

    public SystemConfigTable() {
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
            if (field.Type == TType.Struct) {
              RoomConfig = new Config.SystemRoomConfig();
              RoomConfig.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.Struct) {
              DecorateTypeSrotConfig = new Config.SystemDecorateTypeSortConfig();
              DecorateTypeSrotConfig.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.Struct) {
              ChatConfig = new Config.SystemChatConfig();
              ChatConfig.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.Struct) {
              CharacterConfig = new Config.SystemCharacterConfig();
              CharacterConfig.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 50:
            if (field.Type == TType.Struct) {
              LoverConfig = new Config.SystemLoverConfig();
              LoverConfig.Read(iprot);
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
      TStruct struc = new TStruct("SystemConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (RoomConfig != null && __isset.roomConfig) {
        field.Name = "roomConfig";
        field.Type = TType.Struct;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        RoomConfig.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (DecorateTypeSrotConfig != null && __isset.decorateTypeSrotConfig) {
        field.Name = "decorateTypeSrotConfig";
        field.Type = TType.Struct;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        DecorateTypeSrotConfig.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (ChatConfig != null && __isset.chatConfig) {
        field.Name = "chatConfig";
        field.Type = TType.Struct;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        ChatConfig.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (CharacterConfig != null && __isset.characterConfig) {
        field.Name = "characterConfig";
        field.Type = TType.Struct;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        CharacterConfig.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (LoverConfig != null && __isset.loverConfig) {
        field.Name = "loverConfig";
        field.Type = TType.Struct;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        LoverConfig.Write(oprot);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("SystemConfigTable(");
      sb.Append("RoomConfig: ");
      sb.Append(RoomConfig== null ? "<null>" : RoomConfig.ToString());
      sb.Append(",DecorateTypeSrotConfig: ");
      sb.Append(DecorateTypeSrotConfig== null ? "<null>" : DecorateTypeSrotConfig.ToString());
      sb.Append(",ChatConfig: ");
      sb.Append(ChatConfig== null ? "<null>" : ChatConfig.ToString());
      sb.Append(",CharacterConfig: ");
      sb.Append(CharacterConfig== null ? "<null>" : CharacterConfig.ToString());
      sb.Append(",LoverConfig: ");
      sb.Append(LoverConfig== null ? "<null>" : LoverConfig.ToString());
      sb.Append(")");
      return sb.ToString();
    }

  }

}
